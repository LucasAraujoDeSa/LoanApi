using LoansApp.Data.Repositories.Loan;
using LoansApp.Domain.Etities;
using LoansApp.Domain.UseCases.Loan;
using LoansApp.Shared.Utils;

namespace LoansApp.Data.UseCases.Loan
{
    public class GetLoans : IGetLoans
    {
        private readonly ILoanRepository _loansRepository;

        public GetLoans(ILoanRepository loansRepository)
        {
            _loansRepository = loansRepository;
        }

        public Result<IList<LoanEntity>> Execute(string userId)
        {
            IList<LoanEntity> loans = _loansRepository.GetAll(userId);

            return Result<IList<LoanEntity>>.Ok(
                message: "list of loans",
                content: loans
            );
        }
    }
}