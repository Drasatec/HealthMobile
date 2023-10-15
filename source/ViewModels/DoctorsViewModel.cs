using CommunityToolkit.Mvvm.ComponentModel;
using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Languages;
using DrasatHealthMobile.Models;
using DrasatHealthMobile.Models.Doctors;
using DrasatHealthMobile.Services.PublicServices;
using System.Windows.Input;

namespace DrasatHealthMobile.ViewModels;

public class DoctorsViewModel : ObservableObject, IQueryAttributable
{
    public DoctorsViewModel(IPublicService publicService)
    {
        this.publicService = publicService;
        _=GetAllWeekdays();
        _=GetAllDoctorsDegrees();

    }

    // this is the second method, it runing after constructor
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        query.TryGetValue("Id", out specialtyId);
        Filter = new FilterQueryParam();
        _ = GetAll();
    }
    public ICommand SearchBoxTypingCommand => new Command<string>(SearchBoxTypingEX);
    public ICommand DoctorSelectionChangedCommand => new Command<DoctorModel>(DoctorSelectionChangedEX);
    public ICommand DaysSelectionChangedCommand => new Command<Weekday>(DaysSelectionChangedEX);
    public ICommand DegreesSelectionChangedCommand => new Command<DoctorsDegree>(DegreeSelectionChangedEX);
    public ICommand NextPageCommand => new Command(NextPageEX);

    public FilterQueryParam Filter { get; set; }
    public List<DoctorModel> Doctors { get; set; } = new();
    public DoctorModel DoctorSelected { get; set; }
    public List<Weekday> Weekdays { get; set; } = new();
    public List<DoctorsDegree> DoctorsDegrees { get; set; } = new();
    public bool IsRefreshing { get => isRefreshing; set => SetProperty(ref isRefreshing, value); }

    public async void Refresh()
    {
        await GetAll();
    }

    private readonly IPublicService publicService;
    private List<DoctorModel> DoctorsTemp = new();
    private object specialtyId = null;
    private bool isRefreshing = false;

    async void SearchBoxTypingEX(string text)
    {
        try
        {
            if (string.IsNullOrEmpty(text))
            {
                Doctors = DoctorsTemp;
                OnPropertyChanged(nameof(Doctors));
                return;
            }
            var queryParams = new Dictionary<string, string>
                {
                    { "lang", Helper.Language },
                    { "searchTerm", text },
                    { "page", "" },
                    { "pageSize", "" },
                };
            var result = await publicService.GetAllDoctorsAsync("Doctor/search", queryParams);
            Doctors = result.Data;
            OnPropertyChanged(nameof(Doctors));
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(DoctorsViewModel), nameof(SearchBoxTypingEX), ex.Message);
        }
    }

    async void DoctorSelectionChangedEX(DoctorModel parameter)
    {
        try
        {
            if (DoctorSelected == null)
                return;
            var navigationParameter = new Dictionary<string, object>
            {
                { "doctorModel", parameter }
            };

            await Shell.Current.GoToAsync("DoctorDetailsView", navigationParameter);
            DoctorSelected = null;
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(DoctorsViewModel), nameof(DoctorSelectionChangedEX), ex.Message);
        }
    }

    async void DaysSelectionChangedEX(Weekday parameter)
    {
        try
        {
            if (parameter != null)
            {
                if (parameter.WeekdayId != null)
                    Filter.DayId = parameter.WeekdayId;
                else
                    Filter.DayId = null;
            }
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(DoctorsViewModel), nameof(DaysSelectionChangedEX), ex.Message);
        }
    }

    async void DegreeSelectionChangedEX(DoctorsDegree parameter)
    {
        try
        {
            if (parameter != null)
            {
                if (parameter.DoctorDegreeId > 0)
                    Filter.DegreeId = parameter.DoctorDegreeId;
                else
                    Filter.DegreeId = null;
            }
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(DoctorsViewModel), nameof(DegreeSelectionChangedEX), ex.Message);
        }
    }

    void NextPageEX()
    {

    }

    private async Task GetAll()
    {
        try
        {
            IsRefreshing = true;
            var queryParams = new Dictionary<string, string>
                {
                    { "lang", Helper.Language },
                    //{ "page", "1" },
                    //{ "pageSize", "10" },
                    { "status", "active" },
                };
            queryParams.Add("specialtyId", specialtyId as string ?? "");
            queryParams.Add("hosId", Filter.HosId.HasValue ? Filter.HosId.Value.ToString() : "");
            queryParams.Add("dayId", Filter.DayId.HasValue ? Filter.DayId.Value.ToString() : "");
            queryParams.Add("genderId", Filter.GenderId.HasValue ? Filter.GenderId.Value.ToString() : "");
            queryParams.Add("degreeId", Filter.DegreeId.HasValue ? Filter.DegreeId.Value.ToString() : "");

            var result = await publicService.GetAllDoctorsAsync("Doctor/all", queryParams);
            Doctors = DoctorsTemp = result.Data;
            OnPropertyChanged(nameof(Doctors));
            IsRefreshing = false;
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(DoctorsViewModel), nameof(GetAll), ex.Message);
        }
    }


    private async Task GetAllWeekdays()
    {
        try
        {
            var queryParam = "lang=" + Helper.Language;
            var result = await publicService.GetAllWeekdaysAsync("Weekday/names", queryParam);
            if (result != null)
            {
                Weekdays = result;
                Weekdays.Insert(0, new Weekday() { WeekdayId = null, Name = AppResources.public_SelectAll });
            }
            OnPropertyChanged(nameof(Weekdays));
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(DoctorsViewModel), nameof(GetAllWeekdays), ex.Message);
        }
    }

    private async Task GetAllDoctorsDegrees()
    {
        try
        {
            var queryParam = "lang=" + Helper.Language;
            var result = await publicService.GetAllDoctorsDegreesAsync("DoctorsDegree/names", queryParam);
            if (result != null)
            {
                DoctorsDegrees = result;
                DoctorsDegrees.Insert(0, new DoctorsDegree() { DoctorDegreeId = 0, DegreeName = AppResources.public_SelectAll });
            }
            OnPropertyChanged(nameof(DoctorsDegrees));
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(DoctorsViewModel), nameof(GetAllDoctorsDegrees), ex.Message);
        }
    }
}

public class FilterQueryParam
{
    public string Lang { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }

    public string Status { get; set; } = "active";

    public bool AppearanceOnSite { get; set; }

    public int? HosId { get; set; }

    public int SpecialtyId { get; set; }

    public byte? GenderId { get; set; }

    public byte? DayId { get; set; }

    public short? DegreeId { get; set; }
}
