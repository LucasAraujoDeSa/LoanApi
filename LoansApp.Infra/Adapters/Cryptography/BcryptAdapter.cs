using LoansApp.Data.Adapters.Cryptography;
using Bcrypt = BCrypt.Net.BCrypt;

namespace LoansApp.Infra.Adapters.Cryptography
{
    public class BcryptAdapter : ICryptography
    {
        public bool Compare(string hash, string plaintext)
        {
            bool isEqual = Bcrypt.Verify(plaintext, hash);

            return isEqual;
        }

        public string Hash(string plaintext)
        {
            string hash = Bcrypt.HashPassword(plaintext);

            return hash;
        }
    }
}