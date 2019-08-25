using IdentityModel;
using Microsoft.AspNetCore.Http;
using PetOmetro.Common.Helpers;
using PetOmetro.Identity.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PetOmetro.Identity.IdentityServer
{
    public class IdentityServerAuthService : IIdentityServerAuthService
    {
        private readonly IHttpContextAccessor _accessor;

        public IdentityServerAuthService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public int? Id => ConvertHelper.ConvertStringToNullableInt(GetClaims(JwtClaimTypes.Subject).FirstOrDefault()?.Value);

        #region [ Métodos Auxiliares ]

        private IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        private IEnumerable<Claim> GetClaims(string claimType)
        {
            return GetClaimsIdentity().Where(e => e.Type.ToLower().Equals(claimType.ToLower())).ToList();
        }

        #endregion
    }
}
