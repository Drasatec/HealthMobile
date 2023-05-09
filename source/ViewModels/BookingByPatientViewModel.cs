using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrasatHealthMobile.ViewModels;

public class BookingByPatientViewModel : ObservableObject
{
    private string radioButtonVisitTypeSelectedValue;
    public string RadioButtonGroupSelectedValue
    {
        get => radioButtonVisitTypeSelectedValue;
        set => SetProperty(ref radioButtonVisitTypeSelectedValue, value);
    }
    public BookingByPatientViewModel()
    {

    }
}
