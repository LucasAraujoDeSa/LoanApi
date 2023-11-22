using LoansApp.Domain.Etities;
using LoansApp.Shared.Utils;

namespace LoansApp.Domain.UseCases.Loan
{
    public interface IGetLoans
    {
        Result<IList<LoanEntity>> Execute(string userId);
    }
}