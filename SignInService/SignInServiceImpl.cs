using System;
using DIContracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using DrawPicContracts.Interface.Dal;
using InfraContracts.DTO;

namespace SignInService
{
    [Register(Policy.Transient, typeof(ISignInService))]
    public class SignInServiceImpl : ISignInService
    {
        private readonly IUserDal _drawPicUserDal;

        public SignInServiceImpl(IUserDal drawPicUserDal)
        {
            _drawPicUserDal = drawPicUserDal;
        }

        public Response SignIn(SignInRequest request)
        {
            try
            {
                var ds = _drawPicUserDal.GetUser(request.Id);
                var tbl = ds.Tables[0];
                SignInResponse retval = new SignInResponseEmailNotExists();
                if (tbl.Rows.Count == 1)
                    if (request.Id == (string)tbl.Rows[0][0])
                        retval = new SignInResponseOk();
                return retval;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }
    }
}