using DrasatHealthMobile.Models;
using System.Linq;

namespace DrasatHealthMobile.Services;
public class MockService
{
    
    public List<Specialist> ListSpecialists = new List<Specialist>()
    {
        new Specialist(){ Id =1 , Name ="جراحة القلب والصدر"},
        new Specialist(){ Id =1 , Name ="الأطفال"},
        new Specialist(){ Id =1 , Name ="الكشف عن أمراض القلب، وتصلب الشرايين وارتفاع الكولستيرول"},
        new Specialist(){ Id =1 , Name ="علاج طبيعي"},
        new Specialist(){ Id =1 , Name ="جراجة المخ والاعصاب والنفسية والعصبية "},
        new Specialist(){ Id =1 , Name ="الأطفال"},
        new Specialist(){ Id =1 , Name ="الكلية"},
        new Specialist(){ Id =1 , Name ="المخ والاعصاب"},
        new Specialist(){ Id =1 , Name ="ازالة الالم"},
        new Specialist(){ Id =1 , Name ="النساء والتوليد"},
        new Specialist(){ Id =1 , Name ="التناسلية"},
        new Specialist(){ Id =1 , Name = "العظام"},
        new Specialist(){ Id =1 , Name ="الباطن"},
    };

}
