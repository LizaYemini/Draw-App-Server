namespace DrawPicContracts.DTO.LiveWatch.Response
{
    public class GetWatchersOfDocResponseOk: GetWatchersOfDocResponse
    {
        public string[] UsersIds { get; set; }
    }
}