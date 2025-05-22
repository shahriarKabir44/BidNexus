using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BidNexus.Jsons.Custom.Other;
using BidNexus.Models;
using Microsoft.IdentityModel.Tokens;
namespace BidNexus.Utils
{

    public class JwtHelper
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly IConfiguration _config;

        public JwtHelper(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(UserAccount user)
        {
            var jwtSettings = _config.GetSection("Jwt").Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Key);

            var claims = new[]
            {
                new Claim("userId", user.Id.ToString()),
                new Claim("UserName", user.UserName),
                new Claim("UserTypeEnumId", user.UserTypeEnumId.ToString()),
                new Claim("FullName", user.FullName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpireMinutes),
               signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
