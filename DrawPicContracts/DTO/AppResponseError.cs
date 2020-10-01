using InfraContracts.DTO;

namespace DrawPicContracts.DTO
{
    public class AppResponseError : Response
    {
        public AppResponseError(string msg)
        {
            Message = msg;
        }

        public string Message { get; }
    }
}