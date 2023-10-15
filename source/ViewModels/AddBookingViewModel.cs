using CommunityToolkit.Mvvm.ComponentModel;
using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models;
using DrasatHealthMobile.Services.PublicServices;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Windows.Input;

namespace DrasatHealthMobile.ViewModels;
public class AddBookingViewModel : ObservableObject, IQueryAttributable
{
    public AddBookingViewModel(IPublicService publicService)
    {
        this.publicService = publicService;

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        try
        {
            query.TryGetValue("docWPFromDocDetailsView", out doctorWorkPeriod);
            WorkPeriodMoel = doctorWorkPeriod as DoctorWorkPeriodModel;
            WorkPeriodMoel.DateName = WorkPeriodMoel.Date.ToShortDateString();
            OnPropertyChanged(nameof(WorkPeriodMoel));
            GetAllDoctorVisitPrice();
            GetAllTypesVisits();
        }
        catch (Exception){}
    }
    public ICommand TypesVisitSelectionChangedCommand => new Command<TypesVisitTranslation>(TypesVisitSelectionChangedEX);
    public ICommand SubmitBookingCommand => new Command(SubmitBookingEX);

    public DoctorWorkPeriodModel WorkPeriodMoel { get; set; }
    public List<TypesVisitTranslation> TypeVisits { get; set; }
    public DoctorVisitPriceModel VisitPriceModel { get; set; }
    public List<DoctorVisitPriceModel> VisitPrices { get; set; }
    public TypesVisitTranslation TypeVisitSelectedItem { get; set; }
    public string StatusReason { get; set; } = string.Empty;

    private readonly IPublicService publicService;
    private object doctorWorkPeriod = null;
    private int? TypesVisitId = null;

    void TypesVisitSelectionChangedEX(TypesVisitTranslation parameter = null)
    {
        if (parameter != null)
        {
            TypesVisitId = parameter.TypeVisitId;
            Refresh();
        }
        else
            TypesVisitId = null;
    }

    async void SubmitBookingEX()
    {
        try
        {
            var booking = new SendBookingModel()
            {
                PatientId = AppPreferences.GetUserId(),
                HospitalId = WorkPeriodMoel.HospitalId,
                SpecialtyId = WorkPeriodMoel.SpecialtyId,
                DoctorId = WorkPeriodMoel.DoctorId,
                ClinicId = WorkPeriodMoel.ClinicId,
                TypeVisitId = TypesVisitId,
                DayNumber = WorkPeriodMoel.DayId,
                WorkingPeriodId = WorkPeriodMoel.WorkingPeriodId,
                VisitingDate = WorkPeriodMoel.Date.ToUniversalTime(),
                BookingReason = StatusReason,
            };
            if(VisitPriceModel != null)
            {
                booking.Price = VisitPriceModel.Price;
                booking.PriceCategoryId = VisitPriceModel.PriceCategoryId;
            }
            var result = await publicService.PostBookingAsync("booking/add-body", booking);
            if (result != null & result.Success)
            {
                var navigationParameter = new Dictionary<string, object>
                {
                   // { "bookingDetailsModel", null },
                    { "bookingId", result.Id }
                };

                await Shell.Current.GoToAsync("BookingDetailsView", navigationParameter);
                await Alerts.ToastAlert(result?.Message.ToString());
            }
            else
                await Alerts.ToastAlert("Appointment reservation failed");
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(AddBookingViewModel), nameof(SubmitBookingEX), ex.Message);
        }
    }

    private void Refresh()
    {
        SelectPrice();
    }

    private async void GetAllTypesVisits()
    {
        try
        {
            var queryParam = "lang=" + Helper.Language;
            var result = await publicService.GetAllTypesVisitTranslationsAsync("TypesVisit/names", queryParam);
            if (result != null)
            {
                TypeVisits = result;
                OnPropertyChanged(nameof(TypeVisits));
                _ = Task.Run(async () =>
                {
                    await Task.Delay(500);
                    TypeVisitSelectedItem = TypeVisits.FirstOrDefault();
                    TypesVisitId = TypeVisitSelectedItem.TypeVisitId;
                    OnPropertyChanged(nameof(TypeVisitSelectedItem));
                });
            }
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(AddBookingViewModel), nameof(GetAllTypesVisits), ex.Message);
        }
    }

    private async void GetAllDoctorVisitPrice()
    {
        try
        {
            var queryParam = $"lang={Helper.Language}&docId={WorkPeriodMoel.DoctorId}";
            var result = await publicService.GetAllDoctorVisitPriceAsync("DoctorVisitPrice", queryParam);
            if (result != null)
            {
                VisitPrices = result;
            }
            SelectPrice();
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(AddBookingViewModel), nameof(GetAllDoctorVisitPrice), ex.Message);

        }
    }

    private async void SelectPrice()
    {
        try
        {
            if (!TypesVisitId.HasValue)
                TypesVisitId = 1;

            VisitPriceModel = VisitPrices.Where(x => x.TypeVisitId == TypesVisitId).FirstOrDefault();
            if (VisitPriceModel != null)
            {
                OnPropertyChanged(nameof(VisitPriceModel));
            }
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(AddBookingViewModel), nameof(SelectPrice), ex.Message);
        }

    }
}
