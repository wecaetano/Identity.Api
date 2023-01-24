using System.Text.Json.Serialization;

namespace Identity.Core.DTO.Auth;

public record AuthTokenDTO
{
    [JsonPropertyName("token")]
    public string Token { get; set; }
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }
    [JsonPropertyName("expires_in")]
    public DateTime ExpiresIn { get; set; }
}
