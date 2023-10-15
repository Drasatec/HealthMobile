using CommunityToolkit.Mvvm.ComponentModel;
using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models;
using DrasatHealthMobile.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace DrasatHealthMobile.ViewModels;

public class SearchViewModel : ObservableObject
{
    private readonly MockService mock = new();
    public ObservableCollection<Specialist> SpecialistsList { get; set; } = new();
    //int selectedSearshType = (int)SearchBy.specialist;

    public SearchViewModel()
    {
        Task.Run(() => GetSpecialists());
    }

    private void GetSpecialists()
    {
        foreach (var item in mock.ListSpecialists)
        {
           SpecialistsList.Add(item);
        }
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
        
    }

    private void SelectSearchType(int type)
    {
        if (type == (int)SearchBy.specialist)
        {
            //selectedSearshType = (int)SearchBy.specialist;
        }
        else
        {
            //selectedSearshType = (int)SearchBy.doctor;
        }
    }
}

