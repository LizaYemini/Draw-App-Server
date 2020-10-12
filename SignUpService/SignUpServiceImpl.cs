using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using System;
using DIContracts;
using InfraContracts.DTO;

namespace SignUpService
{
    [Register(Policy.Transient, typeof(ISignUpService))]
    public class SignUpServiceImpl: ISignUpService
    {
        private readonly IUserDal _userDal;

        public SignUpServiceImpl(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public Response SignUp(SignUpRequest request)
        {
            try
            {
                var ds = _userDal.GetUser(request.Id);
                var tbl = ds.Tables[0];
                SignUpResponse ret = new SignUpResponseEmailExists();
                var count = tbl.Rows.Count;
                if (tbl.Rows.Count != 1)
                {
                    _userDal.CreateUser(request);
                    ret = new SignUpResponseOk();
                }

                return ret;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }
    }
}
