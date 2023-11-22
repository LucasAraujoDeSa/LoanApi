using LoansApp.Data.Adapters.Cryptography;
using LoansApp.Data.Adapters.Validators;
using LoansApp.Data.Repositories.User;
using LoansApp.Domain.Dtos.User;
using LoansApp.Domain.Etities;
using LoansApp.Domain.UseCases.User;
using LoansApp.Shared.Utils;

namespace LoansApp.Data.UseCases.User
{
    public class SignUp : ISignUp
    {
        private readonly ICryptography _cryptography;
        private readonly IUserRepository _userRepository;
        private readonly IEmailValidator _emailValidator;

        public SignUp(
            ICryptography cryptography,
            IUserRepository userRepository,
            IEmailValidator emailValidator
        )
        {
            _cryptography = cryptography;
            _userRepository = userRepository;
            _emailValidator = emailValidator;
        }

        public async Task<Result<UserEntity>> Execute(SignUpInputDTO input)
        {
            bool isValidEmail = _emailValidator.Validate(input.Email);

            if (isValidEmail is false)
            {
                return Result<UserEntity>.OperationalError(
                    content: null,
                    message: "email with wrong format"
                );
            }

            bool isInUse = await _userRepository.CheckIfEmailAlreadyInUse(input.Email);

            if (isInUse is true)
            {
                return Result<UserEntity>.OperationalError(
                    content: null,
                    message: "email already in use"
                );
            }

            string newPassword = _cryptography.Hash(input.Password);

            UserEntity newUser = new(
                firstName: input.FirstName,
                lastName: input.LastName,
                fullName: input.FullName,
                birth: input.Birth,
                nationalIdentifier: input.NationalIdentifier,
                email: input.Email,
                password: newPassword
            );

            await _userRepository.Save(newUser);

            newUser.Password = string.Empty;

            return Result<UserEntity>.Created(
                content: newUser,
                message: "user created"
            );
        }
    }
}