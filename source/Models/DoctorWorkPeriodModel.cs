namespace DrasatHealthMobile.Models;

public class DoctorWorkPeriodModel
{
    public int Id { get; set; }
    public int HospitalId { get; set; }
    public int SpecialtyId { get; set; }
    public int ClinicId { get; set; }
    public int DoctorId { get; set; }
    public int WorkingPeriodId { get; set; }
    public int DayId { get; set; }

    public string Hospital { get; set; }
    public string Clinic { get; set; }
    public string Doctor { get; set; }
    public string WorkingPeriod { get; set; }
    public string DayName { get; set; }

    //public List<string> WorkingPeriods { get; set; } = new List<string>(10);
    public DateTime Date { get; set; }
    public string DateName { get; set; }
    public string DocFullName { get; set; }
    public string Headline { get; set; }


}
