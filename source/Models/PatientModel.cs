namespace DrasatHealthMobile.Models;

public class PatientModel
{
    public int Id { get; set; }

    public DateTime? BirthDate { get; set; }

    public byte? NationalId { get; set; }

    public byte? Ssn { get; set; }

    public string BloodType { get; set; }

    public byte? PatientStatus { get; set; }

    public string Photo { get; set; }

    public int? SsntypeId { get; set; }

    public bool IsDeleted { get; set; }

    public int? ClientId { get; set; }

    public int? ClientGroupId { get; set; }

    public short? NationalityId { get; set; }

    public short? GenderId { get; set; }

    public short? ReligionId { get; set; }

    public short? MaritalStatusId { get; set; }

    public List<PatientTranslation> PatientTranslations { get; set; }
}

public class PatientTranslation
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public string Occupation { get; set; }

    public string Address { get; set; }

    public string LangCode { get; set; }

    public int? PatientId { get; set; }
}
