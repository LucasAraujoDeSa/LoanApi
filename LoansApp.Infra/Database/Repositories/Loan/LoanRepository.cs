using LoansApp.Data.Repositories.Loan;
using LoansApp.Domain.Etities;
using Microsoft.EntityFrameworkCore;

namespace LoansApp.Infra.Database.Repositories.Loan
{
    public class LoanRepository : ILoanRepository
    {
        private readonly DatabaseContext _dbContext;

        public LoanRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<LoanEntity> GetAll(string userId)
        {
            IList<LoanEntity> loans = _dbContext.Loan
                .Where(loan => loan.OwnerId == userId)
                .Include(loanOwner => loanOwner.Owner).ToList();

            return loans;
        }

        public async Task Save(LoanEntity input)
        {
            _dbContext.Loan.Add(input);
            await _dbContext.SaveChangesAsync();
        }
    }
}