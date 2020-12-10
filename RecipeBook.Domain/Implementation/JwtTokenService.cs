using RecipeBook.DataAccess.Entities;
using RecipeBook.Domain.Abstraction;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RecipeBook.Domain.Implementation
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public JwtTokenService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public string CreateToken(User user)
        {
           

            var roles = _userManager.GetRolesAsync(user).Result;

            var claims = new List<Claim>
            {
                new Claim("id",user.Id),
                new Claim("email",user.Email),

            };
            foreach (var item in roles)
            {
                claims.Add(new Claim("role", item));
            }

            var jwtTokenSecretKey = _configuration.GetValue<string>("SecretPhrase");

            var siginInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenSecretKey));

            var siginInCredential = new SigningCredentials(siginInKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(signingCredentials: siginInCredential, claims: claims, expires: DateTime.Now.AddDays(3));
            return new JwtSecurityTokenHandler().WriteToken(jwt);

        }
        public string GetUserId(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            string id = "";
            foreach (var item in tokenS.Claims)
            {
                id=item.Value;
                break;
            }
            return id;
        }
    }
}
