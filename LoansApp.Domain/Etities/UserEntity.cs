namespace LoansApp.Domain.Etities
{
    public class UserEntity
    {
        public string Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birth { get; set; }
        public string NationalIdentifier { get; set; }
        public UserEntity(
            string firstName,
            string lastName,
            string fullName,
            string email,
            string password,
            DateTime birth,
            string nationalIdentifier
        )
        {
            Id = Guid.NewGuid().ToString();
            FirstName = firstName;
            LastName = lastName;
            FullName = fullName;
            Email = email;
            Password = password;
            Birth = birth;
            NationalIdentifier = nationalIdentifier;
        }

    }
}