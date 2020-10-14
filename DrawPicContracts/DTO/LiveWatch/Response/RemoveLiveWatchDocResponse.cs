namespace DrawPicContracts.DTO.LiveWatch.Response
{
    public class RemoveLiveWatchDocResponse: InfraContracts.DTO.Response
    {
        public string DocId { get; set; }
        public string UserId { get; set; }
    }
}