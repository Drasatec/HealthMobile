namespace alrahmacare00.Models.Hospital;

public class HospitalTranslation
{
    public int id { get; set; }
    public string name { get; set; }
    public object address { get; set; }
    public object description { get; set; }
    public int hospitalId { get; set; }
    public string langCode { get; set; }
}
