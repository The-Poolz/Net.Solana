using System.Text.Json.Serialization;

namespace Net.Solana.Rpc.Models;

/// <summary>
/// Holds an error result.
/// </summary>
public class ErrorResult
{
    /// <summary>
    /// The error string.
    /// </summary>
    [JsonPropertyName("err")]
    public TransactionError Error { get; set; }
}