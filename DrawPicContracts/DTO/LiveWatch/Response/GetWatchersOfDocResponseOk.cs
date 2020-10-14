namespace DrawPicContracts.DTO.LiveWatch.Response
{
    public class GetWatchersOfDocResponseOk: GetWatchersOfDocResponse
    {
        public string[] UserIds { get; set; }
    }
}