using System;
using Contracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.DTO;

namespace ValidateService
{
    [Register(Policy.Transient, typeof(IValidateService))]
    public class ValidateServiceImpl : IValidateService
    {
        private readonly IUserDal _userDal;
        public ValidateServiceImpl(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public Response ValidateId(ValidateIdRequest request)
        {
            try
            {
                var ds = _userDal.GetUser(request.Id);
                var tbl = ds.Tables[0];
                SignUpResponse ret = new SignUpResponseEmailExists();
                var count = tbl.Rows.Count;
                if (tbl.Rows.Count != 1)
                {
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
