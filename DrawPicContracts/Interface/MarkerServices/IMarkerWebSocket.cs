using System.Threading.Tasks;
using DrawPicContracts.DTO;
using InfraContracts.Interfaces;

namespace DrawPicContracts.Interface.WebSocket
{
    public interface IMarkerWebSocket
    {
        public IInfraMessengerWS InfraMessenger { get; set; }

        public Task AddConnection(System.Net.WebSockets.WebSocket socket);

        public Task RemoveConnection(System.Net.WebSockets.WebSocket socket);

        //public Task SendNewMarker(CreateMarkerResponseOk marker);

        public Task SendNewMarker(MarkerDto marker);
        public Task SendRemoveMarker(string markerId);
    }
}