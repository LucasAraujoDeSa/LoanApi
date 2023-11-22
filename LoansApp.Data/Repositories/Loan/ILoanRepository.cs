using LoansApp.Domain.Etities;

namespace LoansApp.Data.Repositories.Loan
{
    public interface ILoanRepository
    {
        Task Save(LoanEntity input);
        IList<LoanEntity> GetAll(string userId);
    }
}