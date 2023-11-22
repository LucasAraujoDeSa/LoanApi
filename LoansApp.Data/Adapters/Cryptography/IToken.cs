namespace LoansApp.Data.Adapters.Cryptography
{
    public interface IToken
    {
        string Generate(string id);
    }
}