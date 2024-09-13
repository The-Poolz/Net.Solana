#pragma warning disable CS1591
namespace Net.Solana.KeyStore.Crypto;

public interface IRandomBytesGenerator
{


    byte[] GenerateRandomInitializationVector();
    byte[] GenerateRandomSalt();
}