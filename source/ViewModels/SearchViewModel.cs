using CommunityToolkit.Mvvm.ComponentModel;
using DrasatHealthMobile.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DrasatHealthMobile.ViewModels;

public class SearchViewModel : ObservableObject
{

    int selectedSearshBy = (int)SearchBy.specialist;

    public SearchViewModel()
    {

    }
    public ICommand UserStoppedTypingCommand => new Command<string>(UserStoppedTyping);
    public ICommand SelectSearchTypeCommand => new Command<int>(SelectSearchType);
    private string searchText;
    public string SearchText
    {
        get => searchText;
        set => SetProperty(ref searchText, value);
    }

    private void UserStoppedTyping(string text)
    {
        GeneralHepler.DisplayAlert();
    }

    private void SelectSearchType(int type)
    {
        if (type == (int)SearchBy.specialist)
        {

        }
        else
        {

        }
    }
}

