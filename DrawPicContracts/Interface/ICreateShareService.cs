using DrawPicContracts.DTO;
using InfraContracts.DTO;

namespace DrawPicContracts.Interface
{
    public interface ICreateShareService
    {
        Response CreateShare(CreateShareRequest request);
    }
}