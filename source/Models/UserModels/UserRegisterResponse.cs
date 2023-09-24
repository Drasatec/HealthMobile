namespace DrasatHealthMobile.Models.UserModels;

public class UserRegisterResponse
{
    public bool Success { get; set; }
    public bool IsAuthenticated { get; set; }
    public string Message { get; set; }
    public ResponseUserAccount UserAccount { get; set; }
    public string Token { get; set; }
    public DateTime? ExpiresOn { get; set; }
}

public class ResponseUserAccount
{
    public int userId { get; set; }
    public string userName { get; set; }
    public string phoneNumber { get; set; }
    public string email { get; set; }
    public bool emailConfirmed { get; set; }
    public bool phoneNumberConfirmed { get; set; }
    public string userType { get; set; }
}

