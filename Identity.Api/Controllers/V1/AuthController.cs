using Identity.Core.DTO.Auth;
using Identity.Core.Entities;
using Identity.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.IdentityModel.Tokens.Jwt;

namespace Identity.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public AuthController(IAuthService authService, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _authService = authService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Realiza autenticação gerando um JWT que permite acessá-lo.
        /// </summary>
        [HttpPost("generate_token")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Authenticate([FromBody] AuthInputViewModel inputViewModel)
        {
            var jwt = await _authService.Authenticate(inputViewModel.Name, inputViewModel.PasswordHash);

            if (jwt is null)
            {
                return Unauthorized();
            }

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(jwt),
                expiration = jwt.ValidTo
            });
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);

            User user = new User();
            if (userExists == null)
            {
                user.Email = model.Email;
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.UserName = model.Username;
                user.DataSourceId = 1;
                user.PersonId = 1;

                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                user = userExists;
            }

            if (!await _roleManager.RoleExistsAsync("Admin"))
                await _roleManager.CreateAsync(new Role() { Name = "Admin", DataSourceId = 1 });
            if (!await _roleManager.RoleExistsAsync("User"))
                await _roleManager.CreateAsync(new Role() { Name = "User", DataSourceId = 1 });

            if (await _roleManager.RoleExistsAsync("Admin"))
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            if (await _roleManager.RoleExistsAsync("Admin"))
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            return Ok();
        }
    }
}
