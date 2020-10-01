using DrawPicContracts.DTO;
using InfraContracts.DTO;

namespace DrawPicContracts.Interface
{
    public interface ISignInService
    {
        Response SignIn(SignInRequest request);
    }
}