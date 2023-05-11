using CommunityToolkit.Mvvm.ComponentModel;
using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models;
using DrasatHealthMobile.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace DrasatHealthMobile.ViewModels;

public class SearchViewModel : ObservableObject
{
    private MockService mock = new();
    public ObservableCollection<string> SpecialistsList { get; set; } = new();
    public ObservableCollection<Doctor> Doctors { get; set; }=new();
    int selectedSearshType = (int)SearchBy.specialist;

    public SearchViewModel()
    {
        Task.Run(() => GetDoctors());
    }

    private void GetDoctors()
    {
        foreach (var item in mock.ListDoctors)
        {
            Doctors.Add(item);
        }
        // OnPropertyChanged("Doctors");
    }

    public ICommand SearchBoxTypingCommand => new Command<string>(SearchBoxTyping);
    public ICommand SelectSearchTypeCommand => new Command<int>(SelectSearchType);

    private string searchText;
    public string SearchText
    {
        get => searchText;
        set => SetProperty(ref searchText, value);
    }


    private void SearchBoxTyping(string text)
    {
        Doctors.Clear();
        foreach (var item in mock.LocalDoctors(text))
        {
            Doctors.Add(item);
        }
    }

    private void SelectSearchType(int type)
    {
        if (type == (int)SearchBy.specialist)
        {
            selectedSearshType = (int)SearchBy.specialist;
        }
        else
        {
            selectedSearshType = (int)SearchBy.doctor;
        }
    }
}

