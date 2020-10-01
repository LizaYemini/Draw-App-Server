namespace DrawPicContracts.DTO
{
    public class GetDocsByOwnerIdResponseOk: GetDocsByOwnerIdResponse
    {
        public DocumentDto[] Documents { get; set; }
    }
}