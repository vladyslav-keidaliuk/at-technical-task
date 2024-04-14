using Newtonsoft.Json;

namespace Business.Models;

public class UserLoginFailTotal
{
    public int Id { get; set; }

    public string UserName { get; set; }

    [JsonProperty("fail_count")]
    public int FailCount { get; set; }
}