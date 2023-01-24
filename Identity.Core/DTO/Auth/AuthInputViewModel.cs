using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Identity.Core.DTO.Auth;

[SwaggerSchema(Description = "Input para realizar autenticação.")]
public record AuthInputViewModel
{
    [Required]
    [JsonProperty("name")]
    [SwaggerSchema(Description = "Nome de usuário")]
    public string Name { get; init; }

    [Required]
    [JsonProperty("passwrod_hash")]
    [SwaggerSchema(Description = "Senha")]
    public string PasswordHash { get; init; }
}