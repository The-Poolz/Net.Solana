using Net.Solana.Extensions.Models.TokenMint;

namespace Net.Solana.Extensions;

/// <summary>
/// Contains the method used to resolve mint public key addresses into TokenDef objects.
/// </summary>
public interface ITokenMintResolver
{
    /// <summary>
    /// Resolve a mint public key address into a TokenDef object.
    /// </summary>
    /// <param name="tokenMint"></param>
    /// <returns>An instance of the TokenDef containing known info about this token or a constructed unknown entry.</returns>
    TokenDef Resolve(string tokenMint);

}