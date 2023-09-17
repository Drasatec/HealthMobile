using DrasatHealthMobile.Helpers;

namespace DrasatHealthMobile.Models.Doctors;
public class DoctorModel
{
    public int Id { get; set; }
    public string CodeNumber { get; set; }
    public int Gender { get; set; }
    public object Photo { get; set; }
    public object WorkingHours { get; set; }
    public object DocStatus { get; set; }
    public object Reason { get; set; }
    public bool IsAppearanceOnSite { get; set; }
    public object PhoneNumber { get; set; }
    public bool PhoneNumberAppearance { get; set; }
    public bool VisitPriceAppearance { get; set; }
    public bool IsDeleted { get; set; }
    public int DoctorsDegreeId { get; set; }
    public object NationalityId { get; set; }
    public List<DoctorTranslationModel> DoctorTranslations { get; set; }
    public string ImageUrl { get => Constants.ImageUri + "small/" + this.Photo; }
}
