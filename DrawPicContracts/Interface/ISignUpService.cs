using DrawPicContracts.DTO;
using InfraContracts.DTO;

namespace DrawPicContracts.Interface
{
    public interface ISignUpService
    {
        Response SignUp(SignUpRequest request);
    }
}