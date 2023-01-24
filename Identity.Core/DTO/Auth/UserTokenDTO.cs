using Newtonsoft.Json;

namespace Identity.Core.DTO.Auth;

public class UserTokenDTO
{
    [JsonProperty("user_claims")]
    public IList<string> UserClaims { get; set; } = new List<string>();
    [JsonProperty("user_roles")]
    public object UserRoles { get; set; }
    [JsonProperty("user_company_access")]
    public object UserCompanyAccess { get; set; }
}
