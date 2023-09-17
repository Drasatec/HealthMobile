namespace DrasatHealthMobile.Models.Doctors;
public class DoctorTranslationModel 
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Headline { get; set; }
    public string About { get; set; }
    public int DoctorId { get; set; }
    public string LangCode { get; set; }
}
