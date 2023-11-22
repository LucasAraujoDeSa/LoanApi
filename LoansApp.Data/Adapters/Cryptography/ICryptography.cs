namespace LoansApp.Data.Adapters.Cryptography
{
    public interface ICryptography
    {
        string Hash(string plaintext);
        bool Compare(string hash, string plaintext);
    }
}