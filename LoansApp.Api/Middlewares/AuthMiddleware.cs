
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using LoansApp.Data.Repositories.User;
using LoansApp.Domain.Etities;
using Microsoft.IdentityModel.Tokens;

namespace LoansApp.Api.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserRepository repo, IConfiguration configuration)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            Console.WriteLine(token);

            if (token is not null)
                await attachUserToContext(context, repo, configuration, token);

            await _next(context);
        }

        private async Task attachUserToContext(HttpContext context, IUserRepository repo, IConfiguration configuration, string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = configuration["keys:auth"];
            if (secret is null) return;
            var key = Encoding.ASCII.GetBytes(secret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);


            var jwtToken = (JwtSecurityToken)validatedToken;
            var id = jwtToken.Claims.First(x => x.Type == "id").Value;

            UserEntity? user = await repo.GetById(id);
            context.Items["User"] = user;
        }
    }
}