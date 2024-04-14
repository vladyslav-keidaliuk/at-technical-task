namespace Business.Models;

public class LoginFailTotalParams
{
    public string? UserName { get; set; }

    public int? FailCount { get; set; }

    public int? FetchLimit { get; set; }
}