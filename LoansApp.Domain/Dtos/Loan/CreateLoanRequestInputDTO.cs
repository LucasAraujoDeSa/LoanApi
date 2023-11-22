namespace LoansApp.Domain.Dtos.Loan
{
    public class CreateLoanRequestInputDTO
    {
        public string Description { get; set; } = null!;
        public float Amount { get; set; }
    }
}