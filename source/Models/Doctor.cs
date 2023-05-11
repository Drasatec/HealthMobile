namespace DrasatHealthMobile.Models;
public class Doctor
{
    public int Id { get; set; }
    public string Photo { get; set; }
    public string FullName { get; set; }
    public string Headline { get; set; } 
    public double Price { get; set; }
    public string Currency { get; set; }
    public string DegreeName { get; set; } 
    public byte Gender { get; set; }
    public string About { get; set; }
}
