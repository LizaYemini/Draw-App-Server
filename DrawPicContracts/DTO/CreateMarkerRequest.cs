namespace DrawPicContracts.DTO
{
    public class CreateMarkerRequest
    {
        public string DocId { get; set; }
        public string MarkerId { get; set; }
        public string MarkerType { get; set; }
        public string ForColor { get; set; }
        public string BackColor { get; set; }
        public string UserId { get; set; }

        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}