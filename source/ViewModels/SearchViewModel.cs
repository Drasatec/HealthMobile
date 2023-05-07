using CommunityToolkit.Mvvm.ComponentModel;
using DrasatHealthMobile.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DrasatHealthMobile.ViewModels;

public class SearchViewModel : ObservableObject
{
    public ObservableCollection<string> SpecialistsList { get; set; }

    int selectedSearshType = (int)SearchBy.specialist;

    public SearchViewModel()
    {
        SpecialistsList = new ObservableCollection<string>
        {
            "القلب",
            "الأطفال",
            "علاج طبيعي",
        };
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
        var t = text;
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

