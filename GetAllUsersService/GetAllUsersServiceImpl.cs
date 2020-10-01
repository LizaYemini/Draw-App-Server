using System;
using System.Collections.Generic;
using Contracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.DTO;

namespace GetAllUsersService
{
    [Register(Policy.Transient, typeof(IGetAllUsersService))]
    public class GetAllUsersServiceImpl : IGetAllUsersService
    {
        private IUserDal _dal;

        public GetAllUsersServiceImpl(IUserDal dal)
        {
            _dal = dal;
        }

        public Response GetAllUsers()
        {
            //DocumentDto[] docs;
            List<string> usersList = new List<string>();

            try
            {
                var dataSet = _dal.GetAllUsers();
                var table = dataSet.Tables[0];
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    string temp = table.Rows[i]["UserId"].ToString();
                    usersList.Add(temp);
                }

                GetAllUsersResponse ret = new GetAllUsersResponseOk
                {
                    Users = usersList.ToArray()
                };

                return ret;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }
    }
}
