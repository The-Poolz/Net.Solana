#pragma warning disable CS1591
namespace Net.Solana.KeyStore.Exceptions;

public class DecryptionException : Exception
{
    internal DecryptionException(string msg) : base(msg)
    {
    }
}