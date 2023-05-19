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
    public ObservableCollection<SpecialtyViewModel> SpecialistsList { get; set; }

    public ICommand SearchBoxTypingCommand => new Command<string>(SearchBoxTyping);

    public SpecialtiesViewModel()
    {
        SpecialistsList = new ObservableCollection<SpecialtyViewModel>
        {
            new (){Id = 1, Name="جراحة القلب والصدر" },
            new (){Id = 2, Name="الأطفال"},
            new (){Id = 3, Name="علاج طبيعي"},
            new (){Id = 4, Name="جراجة المخ والاعصاب والنفسية والعصبية"},
            new (){Id = 5, Name="الأطفال"},
            new (){Id = 6, Name="الكلية"},
            new (){Id = 7, Name="العظام"},
            new (){Id = 8, Name="الباطن"},
            new (){Id = 9, Name="المخ والاعصاب"},
            new (){Id = 10, Name="ازالة الالم"},
            new (){Id = 11, Name="الأطفال"},
            new (){Id = 12, Name="النساء والتوليد"},
            new (){Id = 13, Name="التناسلية"},
            new (){Id = 14, Name="جراحة القلب والصدر"},
            new (){Id = 15, Name="الأطفال"},
            new (){Id = 16, Name="علاج طبيعي"},
            new (){Id = 17, Name="الكلية"},

        };
    }

    private void SearchBoxTyping(string text)
    {
        var t = text;
    }
}
