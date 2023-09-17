using DrasatHealthMobile.Helpers;
using System.Text.Json.Serialization;

namespace DrasatHealthMobile.Models.MedicalSpecialty;
public class SpecialtyModel
{
    public int Id { get; set; }
    public string Photo { get; set; }
    public string CodeNumber { get; set; }
    public bool IsDeleted { get; set; }
    public bool Appearance { get; set; }
    public object Reason { get; set; }
    [JsonPropertyName("medicalSpecialtyTranslations")]
    public List<SpecialtyTranslationModel> SpecialtyTranslations { get; set; }
    public string ImageUrl { get => Constants.ImageUri + "small/" + this.Photo; }

}
