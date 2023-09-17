namespace DrasatHealthMobile.Models.MedicalSpecialty;

public class SpecialtyTranslationModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string LangCode { get; set; }
    public int MedicalSpecialtyId { get; set; }
}
