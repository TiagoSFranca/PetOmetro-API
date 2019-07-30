using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PetOmetro.Application.Interfaces.Services;
using PetOmetro.Application.Settings.Models;
using PetOmetro.Common.Enums;
using PetOmetro.Common.Helpers;
using PetOmetro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace PetOmetro.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly AppSettings _appSettings;

        public JwtService(IHttpContextAccessor accessor, IOptions<AppSettings> appSettingsOptions)
        {
            _accessor = accessor;
            _appSettings = appSettingsOptions.Value;
        }

        public int? Id => ConvertHelper.ConvertStringToNullableInt(GetClaims(ClaimTypeEnum.Id).FirstOrDefault()?.Value);
        public string Login => GetClaims(ClaimTypeEnum.Login).FirstOrDefault()?.Value;

        public string GetToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(CreateUserClaims(usuario)),
                Expires = DateTime.Now.AddDays(_appSettings.JWTSettings.Expiration),
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }

        #region [ Métodos Auxiliares ]

        private IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        private IEnumerable<Claim> GetClaims(string claimType)
        {
            return GetClaimsIdentity().Where(e => e.Type.ToLower().Equals(claimType.ToLower())).ToList();
        }

        private List<Claim> CreateUserClaims(Usuario usuario)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypeEnum.Id, usuario.Id.ToString()),
                new Claim(ClaimTypeEnum.Login, usuario.Login),
                new Claim(ClaimTypeEnum.Nome, usuario.Nome),
                new Claim(ClaimTypeEnum.Sobrenome, usuario.Sobrenome),
            };

            return claims;
        }

        #endregion
    }
}
