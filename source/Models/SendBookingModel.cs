namespace DrasatHealthMobile.Models;

public class SendBookingModel
{
    public int PatientId { get; set; }
    public int HospitalId { get; set; }
    public int SpecialtyId { get; set; }
    public int ClinicId { get; set; }
    public int DoctorId { get; set; }
    public int WorkingPeriodId { get; set; }
    public int? TypeVisitId { get; set; }
    public int PriceCategoryId { get; set; }
    public object CurrencyId { get; set; }
    //public int BookingStatusId { get; set; }
    public int Price { get; set; }
    public DateTime VisitingDate { get; set; }
    public int DayNumber { get; set; }
    public string BookingReason { get; set; }
}
