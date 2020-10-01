namespace DrawPicContracts.DTO
{
    public class UpdateDocumentRequest
    {
        public string Owner { get; set; }
        public string ImageUrl { get; set; }
        public string DocumentName { get; set; }
        public string DocId { get; set; }
    }
}