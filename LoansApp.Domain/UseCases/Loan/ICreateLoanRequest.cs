using LoansApp.Domain.Dtos.Loan;
using LoansApp.Domain.Etities;
using LoansApp.Shared.Utils;

namespace LoansApp.Domain.UseCases.Loan
{
    public interface ICreateLoanRequest
    {
        Task<Result<LoanEntity>> Execute(
            CreateLoanRequestInputDTO input,
            string userId
        );
    }
}
