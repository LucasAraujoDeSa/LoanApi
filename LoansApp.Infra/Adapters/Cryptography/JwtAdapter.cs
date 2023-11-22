using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LoansApp.Data.Adapters.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LoansApp.Infra.Adapters.Cryptography
{
    public class JwtAdapter : IToken
    {
        private readonly IConfiguration _configuration;
        public JwtAdapter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Generate(string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _configuration["keys:auth"];
            var key = Encoding.ASCII.GetBytes(secret is not null ? secret : string.Empty);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]{
                    new Claim(type: "id", value: id)
                }),
                Expires = DateTime.Now.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}