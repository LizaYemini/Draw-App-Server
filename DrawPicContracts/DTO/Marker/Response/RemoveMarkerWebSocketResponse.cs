using InfraContracts.DTO;
using Newtonsoft.Json;

namespace DrawPicContracts.DTO
{
    public class RemoveMarkerWebSocketResponse: Response
    {
        [JsonProperty(PropertyName = "markerId")]
        public string MarkerId { get; set; }
    }
}