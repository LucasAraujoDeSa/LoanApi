using LoansApp.Data.Repositories.Loan;
using LoansApp.Data.UseCases.Loan;
using LoansApp.Domain.UseCases.Loan;
using LoansApp.Infra.Database.Repositories.Loan;

namespace LoansApp.Api.Dependecies.Loan
{
    public class LoanDependecies
    {
        public static void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ILoanRepository, LoanRepository>();
            builder.Services.AddTransient<ICreateLoanRequest, CreateLoanRequest>();
            builder.Services.AddTransient<IGetLoans, GetLoans>();
        }
    }
}