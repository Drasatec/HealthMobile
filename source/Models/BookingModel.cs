namespace DrasatHealthMobile.Models;

public class BookingModel
{
    public int Id { get; set; }
    public string BookingNumber { get; set; }
    public int PatientId { get; set; }
    public int HospitalId { get; set; }
    public int SpecialtyId { get; set; }
    public int DoctorId { get; set; }
    public int WorkingPeriodId { get; set; }
    public int TypeVisitId { get; set; }
    public int ClinicId { get; set; }
    public int PriceCategoryId { get; set; }
    public object CurrencyCode { get; set; }
    public int BookingStatusId { get; set; }
    public string StatusReason { get; set; }
    public int Price { get; set; }
    public int DayNumber { get; set; }
    public DateTime VisitingDate { get; set; }
    public DateTime CreateOn { get; set; }
    public string BookingReason { get; set; }
    public string BookingStatus { get; set; }
    public string Clinic { get; set; }
    public object Currency { get; set; }
    public string Doctor { get; set; }
    public string Hospital { get; set; }
    public string Patient { get; set; }
    public object PriceCategory { get; set; }
    public string Specialty { get; set; }
    public string TypeVisit { get; set; }
    public string WorkingPeriod { get; set; }

    public string VisitDate { get => VisitingDate.ToShortDateString(); }

    public string Success { get; set; }
    public string Message { get; set; }
    public string Photo { get; set; }


}
