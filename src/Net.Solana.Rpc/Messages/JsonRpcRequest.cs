using System.Text.Json.Serialization;

namespace Net.Solana.Rpc.Messages;

/// <summary>
/// Rpc request message.
/// </summary>
public class JsonRpcRequest : JsonRpcBase
{
    /// <summary>
    /// The request method.
    /// </summary>
    public string Method { get; }

    /// <summary>
    /// The method parameters list.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IList<object> Params { get; }

    public JsonRpcRequest(int id, string method, IList<object> parameters)
    {
        Params = parameters;
        Method = method;
        Id = id;
        Jsonrpc = "2.0";
    }
}