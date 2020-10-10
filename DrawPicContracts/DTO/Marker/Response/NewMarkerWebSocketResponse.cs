using InfraContracts.DTO;
using Newtonsoft.Json;

namespace DrawPicContracts.DTO
{
    public class NewMarkerWebSocketResponse: Response
    {
        [JsonProperty(PropertyName = "marker")]
        public MarkerDto Marker { get; set; }
    }
}