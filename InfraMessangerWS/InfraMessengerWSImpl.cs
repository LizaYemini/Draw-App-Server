using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using InfraContracts.Interfaces;

namespace InfraMessengerWS
{
    public class InfraMessengerWSImpl: IInfraMessengerWS
    {
        private Dictionary<string, WebSocket> _connections = new Dictionary<string, WebSocket>();

        public async Task AddConnection(string id, WebSocket socket)
        {
            _connections.TryAdd(id, socket);
        }

        public string GetConnectionId(WebSocket socket)
        {
            return _connections.FirstOrDefault(x => x.Value == socket).Key;
        }

        public WebSocket GetConnectionSocket(string id)
        {
            _connections.TryGetValue(id, out var socket);
            return socket;
        }

        public async Task RemoveConnection(string id)
        {
            _connections.TryGetValue(id, out var socket);
            _connections.Remove(id);
            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "socket connection closed",
            CancellationToken.None);
        }

        public async Task Send(string msg, params WebSocket[] socketsToSendTo)
        {
            var sockets = socketsToSendTo.Where(s => s.State == WebSocketState.Open);
            foreach (var theSocket in sockets)
            {
                var stringAsBytes = System.Text.Encoding.ASCII.GetBytes(msg);
                var byteArraySegment = new ArraySegment<byte>(stringAsBytes, 0, stringAsBytes.Length);
                await theSocket.SendAsync(byteArraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        public async Task SendAll(string msg)
        {
            await Send(msg, _connections.Values.ToArray());
        }
    }
}
