using Net.Solana.Wallet;

namespace Net.Solana.Programs.Abstract;

/// <summary>
/// Base Program interface.
/// </summary>
public interface Program
{
    /// <summary>
    /// The program's key
    /// </summary>
    PublicKey ProgramIdKey { get; }
    /// <summary>
    /// The name of the program
    /// </summary>
    string ProgramName { get; }
}