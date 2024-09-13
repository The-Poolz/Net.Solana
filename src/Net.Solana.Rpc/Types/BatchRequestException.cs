using Net.Solana.Rpc.Core.Http;
using Net.Solana.Rpc.Messages;

namespace Net.Solana.Rpc.Types;

/// <summary>
/// Encapsulates the batch request failure that is relayed to all callbacks
/// </summary>
public class BatchRequestException : ApplicationException
{
    /// <summary>
    /// The RPC result that failed
    /// </summary>
    public RequestResult<JsonRpcBatchResponse> RpcResult;

    /// <summary>
    /// Contructs a BatchRequestException based on the JsonRpcBatchResponse result.
    /// </summary>
    /// <param name="result"></param>
    public BatchRequestException(RequestResult<JsonRpcBatchResponse> result) : base($"Batch request failure - {result.Reason}")
    {
        RpcResult = result;
    }

}