using CSI_BE.Extensions.IdentityUsers;
using CSI_BE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CSI_BE.Controllers
{
    [ApiController]
    [Route("csi/conta")]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;    
        private readonly JwtSettings _jwtSettings;
        private readonly AppIdentityUser _identityUser;

        public AuthController(SignInManager<IdentityUser> signInManager, 
                              UserManager<IdentityUser> userManager, 
                              IOptions<JwtSettings> jwtSettings,
                              IAppIdentityUser user
                              )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            if (user.IsAuthenticated())
            {
                UserId = user.GetUserId();
            }
        }

        public Guid UserId { get; set; }
        public string UserName { get; set; }

        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Senha);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Ok(GerarJwt(user.Email));
            }
            return Problem("Falha ao registrar usuário");

        }


        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Senha, false, true);

            if (result.Succeeded)
            {
                return Ok(GerarJwt(loginUser.Email));
            }
            return Problem("Usuário ou senha incorretos");
        }

        private object GerarJwt(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Segredo);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Emissor,
                Audience = _jwtSettings.Audiencia,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });
            var encodedToken = tokenHandler.WriteToken(token);
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return new { Id = userIdClaim, 
                        token= encodedToken};
        }
    }
}
