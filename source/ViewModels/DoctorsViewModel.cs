using CommunityToolkit.Mvvm.ComponentModel;
using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models.Doctors;
using DrasatHealthMobile.Services;
using DrasatHealthMobile.Services.PublicServices;
using System.Windows.Input;

namespace DrasatHealthMobile.ViewModels;

public class DoctorsViewModel : ObservableObject, IQueryAttributable
{
    public DoctorsViewModel(IPublicService publicService)
    {
        this.publicService = publicService;
    }
    // this is the first method runing after constructor
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        query.TryGetValue("Id", out specialtyId);
        GetAll();
    }
    public ICommand SearchBoxTypingCommand => new Command<string>(SearchBoxTyping);

    public List<DoctorModel> Doctors { get; set; } = new();

    private MockService mock = new();
    private readonly IPublicService publicService;
    private List<DoctorModel> DoctorsTemp = new();
    private object specialtyId = null;

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
        // Create query parameters
        var queryParams = new Dictionary<string, string>
            {
                { "lang", Helper.Language },
                { "page", "1" },
                { "pageSize", "10" },
            };
        queryParams.Add("specialtyId", specialtyId as string ?? "");

        //if (specialtyId != null)
        //    queryParams.Add("specialtyId", (string)specialtyId);

        var result = await publicService.GetAllDoctorsAsync("Doctor/all", queryParams);
        Doctors = DoctorsTemp = result.Data;
        OnPropertyChanged(nameof(Doctors));
    }

    //private void GetDoctors()
    //{
    //   Task.Run(() =>
    //    {
    //        Doctors.Clear();
    //        foreach (var item in mock.ListDoctors)
    //        {
    //            Doctors.Add(item);
    //        }
    //    });
    //}
}
