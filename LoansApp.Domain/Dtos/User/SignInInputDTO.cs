namespace LoansApp.Domain.Dtos.User
{
    public class SignInInputDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}