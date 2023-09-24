namespace DrasatHealthMobile.Models.Countries;
public class CountryModel
{
    public int Id { get; set; }
    public string CallingCode { get; set; }
    public int NumberOfDigits { get; set; }
    public string CountryCode { get; set; }
    public string CurrencyCode { get; set; }
    public string CurrencySymbol { get; set; }
    public string NationalFlag { get; set; }
    public object Longitude { get; set; }
    public object Latitude { get; set; }
    public List<CountriesTranslation> CountriesTranslations { get; set; }
}
public class CountriesTranslation
{
    public int Id { get; set; }
    public string CountryName { get; set; }
    public string CurrencyName { get; set; }
    public string CapitalName { get; set; }
    public int CountryId { get; set; }
    public string LangCode { get; set; }
}
