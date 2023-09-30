using CommunityToolkit.Mvvm.ComponentModel;
using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models;
using DrasatHealthMobile.Models.Doctors;
using DrasatHealthMobile.Services.PublicServices;
using DrasatHealthMobile.Views.Templates;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace DrasatHealthMobile.ViewModels;

public class DoctorDetailsViewModel : ObservableObject, IQueryAttributable
{
    public DoctorDetailsViewModel(IPublicService publicService)
    {
        this.publicService = publicService;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        query.TryGetValue("doctorModel", out doctorDetails);
        DoctorDetails = doctorDetails as DoctorModel;
        OnPropertyChanged(nameof(DoctorDetails));
        Filter = new DoctorWorkPeriodQueryParams();
        DocWorksList = new ObservableCollection<DoctorWorkPeriodModel>();
        GetAllDoctorWorkPeriod();
        GetAllHospitals();
    }

    public ObservableCollection<DoctorWorkPeriodModel> DocWorksList { get; set; }
    public List<HospitalTranslation> Hospitals { get; set; }
    public DoctorModel DoctorDetails { get; set; }


    public ICommand OpenBottomSheetCommand => new Command(OpenBottomSheetEX);
    public ICommand InsertBookingAppointmentsCommand => new Command(InsertBookingAppointmentsEX);
    public ICommand HospitalSelectionCommand => new Command<HospitalTranslation>(HospitalSelectionEX);
    public ICommand ScheduleSelectionChangedCommand => new Command<DoctorWorkPeriodModel>(ScheduleSelectionChangedEX);

    private object doctorDetails;
    private readonly IPublicService publicService;
    private DoctorWorkPeriodQueryParams Filter;
    private SelectHospitalBottomSheet bottomSheet;
    private List<DoctorWorkPeriodModel> lastList;
    private List<DoctorWorkPeriodModel> allWorkPeriod = new List<DoctorWorkPeriodModel>();


    // methods Excute commands
    void HospitalSelectionEX(HospitalTranslation parameter)
    {
        if (parameter != null)
        {
            if (parameter.HospitalId > 0)
                Filter.HosId = parameter.HospitalId;
            else
                Filter.HosId = null;
        }
    }
    
    async void ScheduleSelectionChangedEX(DoctorWorkPeriodModel parameter)
    {
        try
        {
            parameter.Headline = DoctorDetails.DoctorTranslations[0]?.Headline;
            var navigationParameter = new Dictionary<string, object>
            {
                { "docWPFromDocDetailsView", parameter }
            };
            await Shell.Current.GoToAsync("AddBookingView", navigationParameter);
        }
        catch (Exception ex)
        {
            await Helpers.Helper.DisplayAlert(nameof(DoctorDetailsViewModel), nameof(ScheduleSelectionChangedEX), ex.Message);

        }
    }
    async void OpenBottomSheetEX()
    {
        bottomSheet = new SelectHospitalBottomSheet(Hospitals);
        // Show the sheet
        bottomSheet.Dismissed += async (s, e) =>
        {
            var hos = bottomSheet.GetValueMy();
            if (hos != null)
            {
                Filter.HosId = hos.HospitalId;
                Refresh();
                await Helpers.Helper.ToastAlert(hos.Name);
            }
        };
        await bottomSheet.ShowAsync();
    }
    void InsertBookingAppointmentsEX()
    { 
        var lls = new List<DoctorWorkPeriodModel>(lastList.Count);
        foreach (var item in lastList)
        {
            var sss = new DoctorWorkPeriodModel()
            {
                Date = item.Date.AddDays(7),
                Id = item.Id,
                ClinicId = item.ClinicId,
                DayId = item.DayId,
                DoctorId = item.DoctorId,
                HospitalId = item.HospitalId,
                SpecialtyId = item.SpecialtyId,
                WorkingPeriodId = item.WorkingPeriodId,
                WorkingPeriod = item.WorkingPeriod,
                Doctor = item.Doctor,
                Hospital = item.Hospital,
            };
            sss.DateName = sss.Date.ToShortDateString();
            lls.Add(sss);
        }
        lastList.Clear();
        foreach (var item in lls)
        {
            lastList.Add(item);
            DocWorksList.Add(item);
        }
        //OnPropertyChanged(nameof(DocWorksList));
    }

    List<DoctorWorkPeriodModel> list = new List<DoctorWorkPeriodModel>()
    {
        new DoctorWorkPeriodModel {Id = 1,HospitalId = 1,SpecialtyId = 1,ClinicId = 1,DoctorId = 1,WorkingPeriodId = 1,DayId = 0,
            Hospital = "زهراء",Clinic = "مخ",Doctor = "محمد",WorkingPeriod = "صباحية",DayName = "" },

        new DoctorWorkPeriodModel {Id = 1,HospitalId = 1,SpecialtyId = 1,ClinicId = 1,DoctorId = 1,WorkingPeriodId = 2,DayId = 1,
            Hospital = "زهراء",Clinic = "مخ",Doctor = "محمد",WorkingPeriod = "صباحية",DayName = "" },

        new DoctorWorkPeriodModel {Id = 1,HospitalId = 1,SpecialtyId = 1,ClinicId = 1,DoctorId = 1,WorkingPeriodId = 1,DayId = 2,
            Hospital = "زهراء",Clinic = "مخ",Doctor = "محمد",WorkingPeriod = "",DayName = "" },

        new DoctorWorkPeriodModel {Id = 1,HospitalId = 1,SpecialtyId = 1,ClinicId = 1,DoctorId = 1,WorkingPeriodId = 1,DayId = 3,
            Hospital = "زهراء",Clinic = "مخ",Doctor = "محمد",WorkingPeriod = "",DayName = "" },

        new DoctorWorkPeriodModel {Id = 1,HospitalId = 1,SpecialtyId = 1,ClinicId = 1,DoctorId = 1,WorkingPeriodId = 2,DayId = 4,
            Hospital = "زهراء",Clinic = "مخ",Doctor = "محمد",WorkingPeriod = "",DayName = "" },

        new DoctorWorkPeriodModel {Id = 1,HospitalId = 1,SpecialtyId = 1,ClinicId = 1,DoctorId = 1,WorkingPeriodId = 1,DayId = 5,
            Hospital = "زهراء",Clinic = "مخ",Doctor = "محمد",WorkingPeriod = "",DayName = "" },

        new DoctorWorkPeriodModel {Id = 1,HospitalId = 1,SpecialtyId = 1,ClinicId = 1,DoctorId = 1,WorkingPeriodId = 1,DayId = 6,
            Hospital = "زهراء",Clinic = "مخ",Doctor = "محمد",WorkingPeriod = "",DayName = "" },


    };


    void Refresh()
    {
        GetAllDoctorWorkPeriod();
    }

    async void GetAllDoctorWorkPeriod()
    {
        var queryParams = new Dictionary<string, string>
            {
                { "lang", Helper.Language },
                //{ "page", "1" },
                //{ "pageSize", "10" },
                { "docId",  DoctorDetails.Id.ToString()},
            };
        queryParams.Add("hosId", Filter.HosId.HasValue ? Filter.HosId.Value.ToString() : "");
        allWorkPeriod = await publicService.GetAllDoctorWorkPeriodAsync("DoctorWorkPeriod", queryParams);
        HandelTimetable();
    }

    async void GetAllHospitals()
    {
        var queryParam = $"doctorId={DoctorDetails.Id}&lang={Helper.Language}";
        Hospitals = await publicService.GetAllHospitalsTranslationsAsync("Hospital/names", queryParam);
        OnPropertyChanged(nameof(Hospitals));
    }

    void HandelTimetable()
    {
        //Sunday      0	
        //Monday      1
        //Tuesday     2	
        //Wednesday   3	 اربع
        //Thursday    4	
        //Friday	  5	
        //Saturday    6

        var today = DateTime.Now.Date.ToUniversalTime();
        var todyNume = ((int)today.DayOfWeek);
        DocWorksList.Clear();

        var start = allWorkPeriod.Where(x => x.DayId >= todyNume).OrderBy(d => d.DayId).ToList();
        var end = allWorkPeriod.Where(x => x.DayId < todyNume).OrderBy(d => d.DayId).ToList();

        foreach (var item in start)
        {
            DocWorksList.Add(item);
        }

        foreach (var item in end)
        {
            DocWorksList.Add(item);
        }

        lastList = new List<DoctorWorkPeriodModel>(DocWorksList.Count);

        foreach (var item in DocWorksList)
        {
            if (item.DayId == todyNume) //4
            {
                item.Date = today;
                item.DateName = "اليوم";
            }

            if (item.DayId == (todyNume + 1) % 7)  //5
            {
                item.Date = today.AddDays(1);
                item.DateName = "غدا";
            }

            if (item.DayId == (todyNume + 2) % 7)
            {
                item.Date = today.AddDays(2);
                item.DateName = item.Date.ToShortDateString();
            }

            if (item.DayId == (todyNume + 3) % 7)
            {
                item.Date = today.AddDays(3);
                item.DateName = item.Date.ToShortDateString();
            }

            if (item.DayId == (todyNume + 4) % 7)
            {
                item.Date = today.AddDays(4);
                item.DateName = item.Date.ToShortDateString();
            }
            if (item.DayId == (todyNume + 5) % 7)
            {
                item.Date = today.AddDays(5);
                item.DateName = item.Date.ToShortDateString();
            }
            if (item.DayId == (todyNume + 6) % 7) // 10 = 3
            {
                item.Date = today.AddDays(6);
                item.DateName = item.Date.ToShortDateString();
            }
            lastList.Add(item);
        }
        OnPropertyChanged(nameof(DocWorksList));
    }
}

public class DoctorWorkPeriodQueryParams
{
    public string Lang { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }

    public int? HosId { get; set; }

    public int SpecialtyId { get; set; }

    public int DocId { get; set; }

    public int PeriodId { get; set; }

    public byte? DayId { get; set; }
}


/*
  for (int i = 0; i < list.Count; i++)
        {
            var item = list[i];
            item.WorkingPeriods.Add(item.WorkingPeriod);

            for (int k = i + 1; k < list.Count; k++)
            {
                var index = list[k];
                if (item.DayId == index.DayId)
                {
                    item.WorkingPeriods.Add(index.WorkingPeriod);
                    list.Remove(index);
                }
            }
        }
*/
