using LoansApp.Data.Adapters.Cryptography;
using LoansApp.Data.Repositories.User;
using LoansApp.Domain.Dtos.User;
using LoansApp.Domain.Etities;
using LoansApp.Domain.UseCases.User;
using LoansApp.Shared.Utils;

namespace LoansApp.Data.UseCases.User
{
    public class SignIn : ISignIn
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptography _cryptography;
        private readonly IToken _token;

        public SignIn(
            IUserRepository userRepository,
            ICryptography cryptography,
            IToken token
        )
        {
            _userRepository = userRepository;
            _cryptography = cryptography;
            _token = token;
        }

        public async Task<Result<SignInOutputDTO>> Execute(SignInInputDTO input)
        {
            UserEntity? user = await _userRepository.GetByEmail(input.Email);

            if (user == null)
            {
                return Result<SignInOutputDTO>.OperationalError(
                    content: null,
                    message: "email or password invalid"
                );
            }

            bool isValidPassword = _cryptography.Compare(user.Password, input.Password);

            if (isValidPassword is false)
            {
                return Result<SignInOutputDTO>.OperationalError(
                    content: null,
                    message: "email or password invalid"
                );
            }

            string acessToken = _token.Generate(user.Id);

            SignInOutputDTO result = new()
            {
                AccessToken = acessToken
            };

            return Result<SignInOutputDTO>.Ok(
                content: result,
                message: "user signIn success"
            );
        }
    }
}