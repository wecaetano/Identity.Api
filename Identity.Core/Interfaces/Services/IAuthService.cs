using System.IdentityModel.Tokens.Jwt;

namespace Identity.Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<JwtSecurityToken?> Authenticate(string userName, string password);
    }
}
