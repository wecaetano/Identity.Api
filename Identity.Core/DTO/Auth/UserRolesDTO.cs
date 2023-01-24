using Newtonsoft.Json;

namespace Identity.Core.DTO.Auth;

public class UserRolesDTO
{
    [JsonProperty("app")]
    public string App { get; set; }
    [JsonProperty("roles")]
    public IList<string> Roles { get; set; } = new List<string>();
}
