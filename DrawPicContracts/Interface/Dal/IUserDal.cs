using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DrawPicContracts.DTO;

namespace DrawPicContracts.Interface.Dal
{
    public interface IUserDal
    {
        public DataSet GetUser(string userName);
        public DataSet CreateUser(SignUpRequest request);
        public DataSet GetAllUsers();
    }
}
