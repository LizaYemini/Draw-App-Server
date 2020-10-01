using DrawPicContracts.DTO;
using InfraContracts.DTO;
namespace DrawPicContracts.Interface
{
    public interface IValidateService
    {
        public Response ValidateId(ValidateIdRequest idRequest);
    }
}