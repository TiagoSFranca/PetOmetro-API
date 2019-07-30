using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PetOmetro.Application.Interfaces.Services;
using PetOmetro.Application.Settings.Models;
using PetOmetro.Common.Enums;
using PetOmetro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetOmetro.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly AppSettings _appSettings;

        public JwtService(IOptions<AppSettings> appSettingsOptions)
        {
            _appSettings = appSettingsOptions.Value;
        }

        public List<Claim> GetUserClaims(Usuario usuario)
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

        public string GetToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(GetUserClaims(usuario)),
                Expires = DateTime.Now.AddDays(_appSettings.JWTSettings.Expiration),
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}
