using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Identity.Core.DTO.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Nome é Obrigatório!")]
        [JsonProperty("username")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email é Obrigatório!")]
        [JsonProperty("email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password é Obrigatório")]
        [JsonProperty("password")]
        public string? Password { get; set; }
    }
}
