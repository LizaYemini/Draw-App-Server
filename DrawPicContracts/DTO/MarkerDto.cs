namespace DrawPicContracts.DTO
{
    public class MarkerDto
    {
        public string DocId { get; set; }
        public string MarkerId { get; set; }
        public string MarkerType { get; set; }
        public string ForColor { get; set; }
        public string BackColor { get; set; }
        public string UserId { get; set; }

        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

    }
}