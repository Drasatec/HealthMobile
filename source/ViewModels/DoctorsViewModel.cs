using CommunityToolkit.Mvvm.ComponentModel;
using DrasatHealthMobile.Models;
using DrasatHealthMobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrasatHealthMobile.ViewModels;

public class DoctorsViewModel : ObservableObject
{
    private MockService mock = new();

    public ObservableCollection<Doctor> Doctors { get; set; } = new();

    public DoctorsViewModel()
    {
        GetDoctors();
    }

    private async Task GetDoctors()
    {
       await Task.Run(() =>
        {
            Doctors.Clear();
            foreach (var item in mock.ListDoctors)
            {
                Doctors.Add(item);
            }
        });
    }
}
