using LoansApp.Data.Adapters.Cryptography;
using LoansApp.Data.Adapters.Validators;
using LoansApp.Data.Repositories.User;
using LoansApp.Data.UseCases.User;
using LoansApp.Domain.UseCases.User;
using LoansApp.Infra.Adapters.Cryptography;
using LoansApp.Infra.Adapters.Validators;
using LoansApp.Infra.Database.Repositories.User;

namespace LoansApp.Api.Dependecies.User
{
    public class UserDependecies
    {
        public static void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IToken, JwtAdapter>();
            builder.Services.AddTransient<IEmailValidator, EmailValidator>();
            builder.Services.AddTransient<ICryptography, BcryptAdapter>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<ISignUp, SignUp>();
            builder.Services.AddTransient<ISignIn, SignIn>();
        }
    }
}