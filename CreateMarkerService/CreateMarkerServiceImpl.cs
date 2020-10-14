using System;
using System.Text;
using DIContracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using DrawPicContracts.Interface.Dal;
using DrawPicContracts.Interface.WebSocket;
using InfraContracts.DTO;

namespace CreateMarkerService
{
    [Register(Policy.Transient, typeof(ICreateMarkerService))]
    public class CreateMarkerServiceImpl : ICreateMarkerService
    {
        private readonly IMarkerDal _dal;
        private readonly IMarkerWebSocket _markerWebSocket;
        public CreateMarkerServiceImpl(IMarkerDal dal, IMarkerWebSocket markerWebSocket)
        {
            _dal = dal;
            _markerWebSocket = markerWebSocket;
        }
        public Response CreateMarker(CreateMarkerRequest request)
        {
            try
            {
                Console.WriteLine(request);
                request.Marker.MarkerId = GetId(request.Marker.DocId);
                _dal.CreateMarker(request);
                CreateMarkerResponseOk ret = new CreateMarkerResponseOk
                {
                    Marker = request.Marker
                };

                _markerWebSocket.SendNewMarker(request.Marker);
                
                return ret;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }

        }

        private string GetId(string input)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var ticks = DateTime.Now.Ticks;
            //User+ticks 
            var bytes = System.Text.Encoding.ASCII.GetBytes(input + ticks);
            var hashBytes = md5.ComputeHash(bytes);
            //var output = System.Text.Encoding.UTF8.GetString(hashBytes);
            StringBuilder sb = new StringBuilder();
            foreach (var t in hashBytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
