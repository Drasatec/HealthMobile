using DrasatHealthMobile.Models;
using System.Linq;

namespace DrasatHealthMobile.Services;
public class MockService
{
    public IEnumerable<Doctor> LocalDoctors(string text)
    {
        var list = new List<Doctor>()
        {
            new Doctor(){ Id =1 , FullName = "محمد علاء الدين",         Headline="أخصائي النساء التوليد",         Price=500,Currency="فرنك",Photo="doctor1", Gender=1,About=""},
            new Doctor(){ Id =2 , FullName = "إبراهيم سامح حجازي",     Headline="أخصائي القلب والصدر  ",         Price=300,Currency="فرنك",Photo="doctor1", Gender=1,About=""},
            new Doctor(){ Id =3 , FullName = "شريف ابراهيم طه النجار", Headline="استشاري العمود الفقري",         Price=250,Currency="فرنك",Photo="doctor1", Gender=1,About=""},
            new Doctor(){ Id =4 , FullName = "حسام موافي",             Headline="استاذ في الاعصا والعضلات",        Price=400,Currency="فرنك",Photo="doctor1", Gender=1,About=""},
            new Doctor(){ Id =5 , FullName = "أسماء السيد الغندوري",    Headline="مدرس مساعد في الكلية والمسالك", Price=300.99,Currency="فرنك",Photo="doctor4", Gender=2,About=""},
        };

        return list.Where(x => x.FullName.Contains(text)).ToList();
    }
    public List<Doctor> ListDoctors = new List<Doctor>()
    {

            new Doctor(){ Id =1 , FullName = "محمد علاء الدين",         Headline="أخصائي النساء التوليد",         Price=500,Currency="فرنك",Photo="doctor1", Gender=1,About=""},
            new Doctor(){ Id =2 , FullName = "إبراهيم سامح حجازي",     Headline="أخصائي القلب والصدر  ",         Price=300,Currency="فرنك",Photo="doctor1", Gender=1,About=""},
            new Doctor(){ Id =3 , FullName = "شريف ابراهيم طه النجار", Headline="استشاري العمود الفقري",         Price=250,Currency="فرنك",Photo="doctor1", Gender=1,About=""},
            new Doctor(){ Id =4 , FullName = "حسام موافي",             Headline="استاذ في الاعصا والعضلات",        Price=400,Currency="فرنك",Photo="doctor1", Gender=1,About=""},
            new Doctor(){ Id =5 , FullName = "أسماء السيد الغندوري",    Headline="مدرس مساعد في الكلية والمسالك", Price=300.99,Currency="فرنك",Photo="doctor4", Gender=2,About=""},
    };
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
