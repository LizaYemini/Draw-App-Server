namespace DrawPicContracts.DTO
{
    public class GetMarkersResponseOk: GetMarkersResponse
    {
        public MarkerDto[] Markers { get; set; }
    }
}