
namespace DrawPicContracts.DTO
{
    public class GetShareByUserIdResponseOk: GetShareByUserIdResponse
    {
        public string[] DocsIds { get; set; }
    }
}