using Newtonsoft.Json;

namespace Identity.Core.DTO.Auth;

public class UserCompanyAccesssDTO
{
    [JsonProperty("branch")]
    public string Branch { get; set; }
    [JsonProperty("ip_range")]
    public IList<string> IpRange { get; set; } = new List<string>();
}
