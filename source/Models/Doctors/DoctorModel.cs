using DrasatHealthMobile.Helpers;

namespace DrasatHealthMobile.Models.Doctors;
public class DoctorModel
{
    public int Id { get; set; }

    public string CodeNumber { get; set; } = string.Empty;

    public byte? Gender { get; set; }

    public string Photo { get; set; }

    public byte? WorkingHours { get; set; }

    public byte? DocStatus { get; set; }

    public string Reason { get; set; }

    public bool IsAppearanceOnSite { get; set; }

    public string PhoneNumber { get; set; }

    public bool PhoneNumberAppearance { get; set; }

    public bool VisitPriceAppearance { get; set; }

    public bool IsDeleted { get; set; }

    public short? DoctorsDegreeId { get; set; }

    public int? NationalityId { get; set; }
    public List<DoctorTranslationModel> DoctorTranslations { get; set; }
    public string ImageUrl { get => Constants.ImageUri + "small/" + this.Photo; }
}
