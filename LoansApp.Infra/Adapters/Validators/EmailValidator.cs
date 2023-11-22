using System.Text.RegularExpressions;
using LoansApp.Data.Adapters.Validators;

namespace LoansApp.Infra.Adapters.Validators
{
    public class EmailValidator : IEmailValidator
    {
        public bool Validate(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            Regex regex = new Regex(pattern);
            Match match = regex.Match(email);

            return match.Success;
        }
    }
}