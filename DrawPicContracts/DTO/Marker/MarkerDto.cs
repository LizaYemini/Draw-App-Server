using Newtonsoft.Json;

namespace DrawPicContracts.DTO
{
    public class MarkerDto
    {
        [JsonProperty(PropertyName = "docId")]
        public string DocId { get; set; }

        [JsonProperty(PropertyName = "markerId")]
        public string MarkerId { get; set; }

        [JsonProperty(PropertyName = "markerType")]
        public string MarkerType { get; set; }

        [JsonProperty(PropertyName = "forColor")]
        public string ForColor { get; set; }

        [JsonProperty(PropertyName = "backColor")]
        public string BackColor { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "locationX")]
        public double LocationX { get; set; }

        [JsonProperty(PropertyName = "locationY")]
        public double LocationY { get; set; }

        [JsonProperty(PropertyName = "width")]
        public double Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public double Height { get; set; }

    }
}