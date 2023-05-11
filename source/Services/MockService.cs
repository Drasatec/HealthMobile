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

        return list.Where(x=>x.FullName.Contains(text)).ToList();
    }
    public List<Doctor> ListDoctors = new List<Doctor>()
    {

            new Doctor(){ Id =1 , FullName = "محمد علاء الدين",         Headline="أخصائي النساء التوليد",         Price=500,Currency="فرنك",Photo="doctor1", Gender=1,About=""},
            new Doctor(){ Id =2 , FullName = "إبراهيم سامح حجازي",     Headline="أخصائي القلب والصدر  ",         Price=300,Currency="فرنك",Photo="doctor1", Gender=1,About=""},
            new Doctor(){ Id =3 , FullName = "شريف ابراهيم طه النجار", Headline="استشاري العمود الفقري",         Price=250,Currency="فرنك",Photo="doctor1", Gender=1,About=""},
            new Doctor(){ Id =4 , FullName = "حسام موافي",             Headline="استاذ في الاعصا والعضلات",        Price=400,Currency="فرنك",Photo="doctor1", Gender=1,About=""},
            new Doctor(){ Id =5 , FullName = "أسماء السيد الغندوري",    Headline="مدرس مساعد في الكلية والمسالك", Price=300.99,Currency="فرنك",Photo="doctor4", Gender=2,About=""},
    };

}
