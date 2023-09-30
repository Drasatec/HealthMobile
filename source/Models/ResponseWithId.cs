namespace DrasatHealthMobile.Models;
public class ResponseWithId
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public int Id { get; set; }
}

public class Response
{
    public bool Success { get; set; }
    public string Message { get; set; }
}
