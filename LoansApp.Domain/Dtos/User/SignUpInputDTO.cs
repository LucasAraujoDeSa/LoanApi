namespace LoansApp.Domain.Dtos.User
{
    public class SignUpInputDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime Birth { get; set; }
        public string NationalIdentifier { get; set; } = null!;
    }
}