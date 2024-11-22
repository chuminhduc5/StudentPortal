using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Interfaces;
using api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace api.Service
{
    // public class TokenService : ITokenService
    // {
    //     private readonly SymmetricSecurityKey _key;
    //     private readonly string _issuer;
    //     private readonly string _audience;
    //
    //     public TokenService(IConfiguration config)
    //     {
    //         var tokenKey = config["SigningKey"];
    //         if (string.IsNullOrEmpty(tokenKey))
    //             throw new ArgumentNullException("SigningKey", "SigningKey không được thiết lập trong cấu hình.");
    //
    //         _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
    //         _issuer = config["JWT:Issuer"];
    //         _audience = config["JWT:Audience"];
    //     }
    //
    //     public string CreateToken(AppUser user)
    //     {
    //         var claims = new[]
    //         {
    //             new Claim(JwtRegisteredClaimNames.Sub, user.Id),
    //             new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName ?? string.Empty)
    //         };
    //
    //         var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
    //
    //         var tokenDescriptor = new SecurityTokenDescriptor
    //         {
    //             Subject = new ClaimsIdentity(claims),
    //             Expires = DateTime.Now.AddDays(7),
    //             SigningCredentials = creds,
    //             Issuer = _issuer,
    //             Audience = _audience
    //         };
    //
    //         var tokenHandler = new JwtSecurityTokenHandler();
    //         var token = tokenHandler.CreateToken(tokenDescriptor);
    //
    //         return tokenHandler.WriteToken(token);
    //     }
    // }
    
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config) // Đưa cấu hình Config vào
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }
        public string CreateToken(AppUser user)
        {
            // Kiểm tra nếu user là null
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var claims = new List<Claim>
            {
                // new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), 
                // new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim("StudentCode", user.UserName)
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature); 
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };
            // Xử lý token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}