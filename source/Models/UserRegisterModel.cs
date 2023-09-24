
namespace DrasatHealthMobile.Models;
public class UserRegisterModel
{
    public string FullName { get; set; }
    public int GenderId { get; set; }
    public int NationalityId { get; set; }
    public int MaritalStatusId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string PhoneNumber { get; set; }
    public string CallingCode { get; set; }
    public string BirthDate { get; set; }
    public string Address { get; set; }
    public string LangCode { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public bool EmailConfirmed { get; set; }

}

