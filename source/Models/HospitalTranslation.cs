namespace DrasatHealthMobile.Models;
public class HospitalTranslation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public object Address { get; set; }
    public object Description { get; set; }
    public int HospitalId { get; set; }
    public string LangCode { get; set; }
}
