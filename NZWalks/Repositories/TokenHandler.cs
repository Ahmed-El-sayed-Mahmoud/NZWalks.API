using Microsoft.IdentityModel.Tokens;
using NZWalks.API.Models.Domain;
using NZWalks.Models.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalks.API.Repositories
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<string> CreateTokenAsync(User user,IList<string>Roles)
        {
            Console.WriteLine("Reached Token Generationn");

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            foreach(var role in Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
                Console.WriteLine(role.ToString());
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(15),
                signingCredentials: credentials);

            return  new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
