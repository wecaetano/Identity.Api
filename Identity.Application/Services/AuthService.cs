using Identity.Core.DTO.Auth;
using Identity.Core.Entities;
using Identity.Core.Interfaces.Repositories;
using Identity.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ISqlServerRepository<User> _sqlUserRepository;
        private readonly ISqlServerRepository<UserCompanyAccess> _userCompanyAccessRepository;
        private readonly ISqlServerRepository<UserClaim> _userClaimsRepository;
        private readonly ISqlServerRepository<UserRole> _userRolesRepository;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;




        public AuthService(ISqlServerRepository<User> sqlUserRepository,
                           IConfiguration configuration,
                           ISqlServerRepository<UserCompanyAccess> userGenericRepository,
                           ISqlServerRepository<UserClaim> userClaimsRepository,
                           ISqlServerRepository<UserRole> userRolesRepository,
                           IUserRepository userRepository,
                           UserManager<User> userManager,
                           RoleManager<Role> roleManager,
                           SignInManager<User> signInManager)
        {
            _sqlUserRepository = sqlUserRepository;
            _configuration = configuration;
            _userCompanyAccessRepository = userGenericRepository;
            _userClaimsRepository = userClaimsRepository;
            _userRolesRepository = userRolesRepository;
            _userRepository = userRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<JwtSecurityToken> Authenticate(string userName, string password)
        {
            //User user = _sqlUserRepository.Query.FirstOrDefault(u => u.Id == "0E7AFD4F-DCFE-4671-B265-59F9F37F17E0")!;

            User user = await _userManager.FindByNameAsync(userName);

            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var s = "";
            }


            var userRoles = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);

            var authClaims = new List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim(ClaimTypes.Name, user.UserName),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            authClaims.AddRange(userClaims);

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new System.Security.Claims.Claim(ClaimTypes.Role, userRole));
            }

            foreach (var userClaim in userClaims)
            {
                authClaims.Add(new System.Security.Claims.Claim("Claim", userClaim.Value));
            }



            var token = GetToken(authClaims);


            //if (user == null)
            //    throw new ApplicationException("Login ou senha inválidos!");

            //var exprires = DateTime.UtcNow.AddHours(1);

            //var jwtToken = GenerateToken(user);

            //AuthTokenDTO authToken = new()
            //{
            //    TokenType = "Bearer",
            //    Token = jwtToken,
            //    ExpiresIn = exprires
            //};

            await _signInManager.SignInAsync(user, true);

            return token;
        }

        /// <summary>
        /// Generate JWT Token
        /// </summary>
        /// <param name="user"></param>
        /// <param name="expiresIn"></param>
        /// <returns></returns>
        private string GenerateToken(User user, double expiresIn = 1)
        {
            var jwtSection = _configuration.GetSection("Auth:Secret");

            var secret = jwtSection.Value;

            var key = Encoding.UTF8.GetBytes(secret);

            var userToken = GetUserToken(user);

            var tokenDescriptor = new JwtSecurityToken("", "", Array.Empty<System.Security.Claims.Claim>(), null, DateTime.UtcNow.AddHours(expiresIn), new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));
            tokenDescriptor.Payload.Add("UserId", user.Id);
            tokenDescriptor.Payload.Add("User", userToken);

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.WriteToken(tokenDescriptor);

            return jwtToken;
        }

        /// <summary>
        /// Get userTokenDTO object with claims informations
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private UserTokenDTO GetUserToken(User user)
        {

            var userToken = new UserTokenDTO();

            //Retrieve the userClaims for specifica user
            var userClaims = _userClaimsRepository.Query.Where(u => u.UserId == "F3366E5E-ABA6-49C7-9BE7-484A9292C0C6").Select(u => u.ClaimValue).ToList();

            //Retrieve the userRoles for specifica user
            var userRoles = _userRolesRepository.Query.Where(r => r.UserId == "F3366E5E-ABA6-49C7-9BE7-484A9292C0C6").Select(r => new
            {
                App = "",
                Roles = ""
            });

            //Retrieve the CompanyAccess for specifica user
            var userCompanyAccess = _userCompanyAccessRepository.Query.Where(c => c.UserId == user.Id)
                                                            .Select(c => new
                                                            {
                                                                Branch = c.Branch.Code,
                                                                IpRange = c.Branch.BranchIps.Select(i => i.Range)
                                                            });

            userToken.UserClaims = userClaims;
            userToken.UserRoles = userRoles;
            userToken.UserCompanyAccess = userCompanyAccess;

            return userToken;
        }

        private JwtSecurityToken GetToken(List<System.Security.Claims.Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
