namespace DrawPicContracts.DTO
{
    public class GetDocByDocIdResponseOk: GetDocByDocIdResponse
    {
        public DocumentDto Document { get; set; }
    }
}