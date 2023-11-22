using LoansApp.Data.Repositories.Loan;
using LoansApp.Data.Repositories.User;
using LoansApp.Domain.Dtos.Loan;
using LoansApp.Domain.Enums;
using LoansApp.Domain.Etities;
using LoansApp.Domain.UseCases.Loan;
using LoansApp.Shared.Utils;

namespace LoansApp.Data.UseCases.Loan
{
    public class CreateLoanRequest : ICreateLoanRequest
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoanRepository _loanRepository;

        public CreateLoanRequest(
            IUserRepository userRepository,
            ILoanRepository loanRepository
        )
        {
            _userRepository = userRepository;
            _loanRepository = loanRepository;
        }

        public async Task<Result<LoanEntity>> Execute(
            CreateLoanRequestInputDTO input,
            string userId
        )
        {
            bool userExist = await _userRepository.CheckIfExist(userId);

            if (userExist is false)
            {
                return Result<LoanEntity>.OperationalError(
                    message: "user not exist",
                    content: null
                );
            }

            LoanEntity loan = new(
                ownerId: userId,
                amount: input.Amount,
                closedAt: null,
                openedAt: DateTime.UtcNow,
                status: LoanStatus.UNDER_ANALYSIS.ToString(),
                description: input.Description
            );

            await _loanRepository.Save(loan);

            return Result<LoanEntity>.Created(
                message: "loan request was created",
                content: loan
            );
        }
    }
}