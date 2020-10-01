namespace DrawPicContracts.DTO
{
    public class GetShareByDocIdResponseOk: GetShareByDocIdResponse
    {
        public  string[] UsersIds { get; set; }
    }
}