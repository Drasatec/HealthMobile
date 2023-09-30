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
        GetAllWeekdays();
        GetAllDoctorsDegrees();

    }

    // this is the first method runing after constructor
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        query.TryGetValue("Id", out specialtyId);
        Filter = new FilterQueryParam();
        GetAll();
    }
    public ICommand SearchBoxTypingCommand => new Command<string>(SearchBoxTyping);
    public ICommand DaysSelectionChangedCommand => new Command<Weekday>(DaysSelectionChangedEX);
    public ICommand DegreesSelectionChangedCommand => new Command<DoctorsDegree>(DegreeSelectionChangedEX);
    public ICommand DoctorSelectionChangedCommand => new Command<DoctorModel>(DoctorSelectionChangedEX);
    public FilterQueryParam Filter { get; set; }

    public List<DoctorModel> Doctors { get; set; } = new();
    public DoctorModel DoctorSelected { get; set; }
    public List<Weekday> Weekdays { get; set; } = new();
    public List<DoctorsDegree> DoctorsDegrees { get; set; } = new();
    private readonly IPublicService publicService;
    private List<DoctorModel> DoctorsTemp = new();
    private object specialtyId = null;

    void DaysSelectionChangedEX(Weekday parameter)
    {
        if (parameter != null)
        {
            if (parameter.WeekdayId != null)
                Filter.DayId = parameter.WeekdayId;
            else
                Filter.DayId = null;
        }
    }

    void DegreeSelectionChangedEX(DoctorsDegree parameter)
    {
        if (parameter != null)
        {
            if (parameter.DoctorDegreeId > 0)
                Filter.DegreeId = parameter.DoctorDegreeId;
            else
                Filter.DegreeId = null;
        }
    }
    
    async void DoctorSelectionChangedEX(DoctorModel parameter)
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




    private void CollectFiltering()
    {
        var queryParams = new Dictionary<string, string>
            {
                { "lang", Helper.Language },
                { "page", "1" },
                { "pageSize", "10" },
                { "status", "active" },
            };
        queryParams.Add("specialtyId", specialtyId as string ?? "");
        queryParams.Add("hosId", Filter.HosId.HasValue ? Filter.HosId.Value.ToString() : "");
        queryParams.Add("dayId", Filter.DayId.HasValue ? Filter.DayId.Value.ToString() : "");
        queryParams.Add("genderId", Filter.GenderId.HasValue ? Filter.GenderId.Value.ToString() : "");
        queryParams.Add("degreeId", Filter.DegreeId.HasValue ? Filter.DegreeId.Value.ToString() : "");
    }

    private async void SearchBoxTyping(string text)
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

    private async void GetAll()
    {
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

        //if (specialtyId != null)
        //    queryParams.Add("specialtyId", (string)specialtyId);

        var result = await publicService.GetAllDoctorsAsync("Doctor/all", queryParams);
        Doctors = DoctorsTemp = result.Data;
        OnPropertyChanged(nameof(Doctors));
    }
    public void Refresh()
    {
        GetAll();
    }
    private async void GetAllWeekdays()
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

    private async void GetAllDoctorsDegrees()
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
}

public class FilterQueryParam
{
    public string Lang { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }

    public string Status { get; set; }

    public bool AppearanceOnSite { get; set; }

    public int? HosId { get; set; }

    public int SpecialtyId { get; set; }

    public byte? GenderId { get; set; }

    public byte? DayId { get; set; }

    public short? DegreeId { get; set; }
}

//public record FilterQueryParam(string Lang, int Page, int PageSize, string Status, bool AppearanceOnSite, int? HosId, int SpecialtyId, byte? GenderId, byte? DayId, short? DegreeId);
