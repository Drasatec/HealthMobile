namespace DrasatHealthMobile.Models;

public class DoctorVisitPriceModel
{
    public int Id { get; set; }
    public string DoctorName { get; set; }
    public string PriceCategory { get; set; }
    public string TypeVisit { get; set; }
    public string PriceCurrency { get; set; }
    public int Price { get; set; }
    public int DoctorId { get; set; }
    public int PriceCategoryId { get; set; }
    public int TypeVisitId { get; set; }
}
