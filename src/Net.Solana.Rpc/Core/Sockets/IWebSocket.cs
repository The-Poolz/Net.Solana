using System.Net.WebSockets;

namespace Net.Solana.Rpc.Core.Sockets;

public interface IWebSocket : IDisposable
{
    WebSocketState State { get; }
    string CloseStatusDescription { get; }
    WebSocketCloseStatus? CloseStatus { get; }
    Task ConnectAsync(Uri uri, CancellationToken cancellationToken);
    Task CloseAsync(CancellationToken cancellationToken);
    ValueTask SendAsync(ReadOnlyMemory<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken);
    Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken);
    ValueTask<ValueWebSocketReceiveResult> ReceiveAsync(Memory<byte> buffer, CancellationToken cancellationToken);
}