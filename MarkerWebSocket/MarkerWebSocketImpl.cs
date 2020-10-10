using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface.WebSocket;
using InfraContracts.Interfaces;
using Newtonsoft.Json;

namespace MarkerWebSocket
{
    [Register(Policy.Singleton, typeof(IMarkerWebSocket))]
    public class MarkerWebSocketImpl : IMarkerWebSocket
    {
        public IInfraMessengerWS InfraMessenger { get; set; }

        public MarkerWebSocketImpl(IInfraMessengerWS infraMessenger)
        {
            InfraMessenger = infraMessenger;
        }
        public async Task AddConnection(WebSocket socket)
        {
            string id = Guid.NewGuid().ToString();
            await InfraMessenger.AddConnection(id, socket);

        }

        public async Task RemoveConnection(WebSocket socket)
        {
            string id = InfraMessenger.GetConnectionId(socket);
            await InfraMessenger.RemoveConnection(id);
        }

        public async Task SendNewMarker(MarkerDto marker)
        {
            
            NewMarkerWebSocketResponse response = new NewMarkerWebSocketResponse
            {
                Marker = marker
            };
            
            string msg = JsonConvert.SerializeObject(response);
            await InfraMessenger.SendAll(msg);
        }

        public Task SendRemoveMarker(string markerId)
        {
            throw new NotImplementedException();
        }

        public async Task TestSendMsg(String msg)
        {
            await InfraMessenger.SendAll(msg);
        }
    }
}
