using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CSI_BE.Extensions.IdentityUsers
{
    public class AppIdentityUser : IAppIdentityUser
    {

        private readonly IHttpContextAccessor _accessor;

        public AppIdentityUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Guid GetUserId()
        {
            if (!IsAuthenticated()) return Guid.Empty;

            var claim = _accessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(claim)) 
                claim = _accessor.HttpContext?.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            return claim is null ? Guid.Empty : Guid.Parse(claim);
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext?.User.Identity is { IsAuthenticated : true};
        }
    }
}
