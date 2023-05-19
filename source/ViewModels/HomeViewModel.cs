using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrasatHealthMobile.ViewModels;

public class HomeViewModel : ObservableObject
{
    public List<string> ListOfHospitals { get; set; } = new List<string>()
    {
        "hos1",
        "hos2",
        "hos3",
        "hos4",
    };
    public List<string> ListOfServices { get; set; } = new List<string>()
    {
        "العيادات",
        "الخدمات",
        "الأطباء",
    };

    public HomeViewModel()
    {
        
    }
}
