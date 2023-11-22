using LoansApp.Domain.Dtos.User;
using LoansApp.Shared.Utils;

namespace LoansApp.Domain.UseCases.User
{
    public interface ISignIn
    {
        Task<Result<SignInOutputDTO>> Execute(SignInInputDTO input);
    }
}