#pragma warning disable CS1591
namespace Net.Solana.KeyStore.Exceptions;

public class InvalidKdfException : Exception
{
    public InvalidKdfException(string kdf) : base("Invalid kdf:" + kdf)
    {
    }
}