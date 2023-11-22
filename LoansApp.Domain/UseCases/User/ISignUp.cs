using LoansApp.Domain.Dtos.User;
using LoansApp.Domain.Etities;
using LoansApp.Shared.Utils;

namespace LoansApp.Domain.UseCases.User
{
    public interface ISignUp
    {
        Task<Result<UserEntity>> Execute(SignUpInputDTO input);
    }
}