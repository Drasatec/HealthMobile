using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DrasatHealthMobile.ViewModels;

public class SpecialtiesViewModel : ObservableObject
{
    public ObservableCollection<string> SpecialistsList { get; set; }

    public ICommand SearchBoxTypingCommand => new Command<string>(SearchBoxTyping);

    public SpecialtiesViewModel()
    {
        SpecialistsList = new ObservableCollection<string>
        {
            "جراحة القلب والصدر",
            "الأطفال",
            "علاج طبيعي",
            "جراجة المخ والاعصاب والنفسية والعصبية",
            "الأطفال",
            "الكلية",
            "العظام",
            "الباطن",
            "المخ والاعصاب",
            "ازالة الالم",
            "النساء والتوليد",
            "التناسلية",
        };
    }

    private void SearchBoxTyping(string text)
    {
        var t = text;
    }
}
