using System.Data;
using Contracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace UserDal
{
    [Register(Policy.Transient, typeof(IUserDal))]
    public class UserDalImpl : IUserDal
    {
        private readonly OracleConnection _conn;
        private readonly IInfraDal _infraDal;

        public UserDalImpl(IInfraDal infraDal, IConnectionString connectionString)
        {
            _infraDal = infraDal;
            var strConn = connectionString.ConnectionString;
            _conn = new OracleConnection(strConn);
        }

        public DataSet CreateUser(SignUpRequest request)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "CreateUser"
            };
            var param1 = _infraDal.GetParameter("ID", OracleDbType.Varchar2, request.Id);
            var param2 = _infraDal.GetParameter("NAME", OracleDbType.Varchar2, request.Name);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            return _infraDal.ExecSpQuery(cmd);
        }

        public DataSet GetAllUsers()
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "GetAllUsers"
            };
            return _infraDal.ExecSpQuery(cmd);
        }

        public DataSet GetUser(string userName)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "GetUser"
            };
            var param = _infraDal.GetParameter("ID", OracleDbType.Varchar2, userName);
            cmd.Parameters.Add(param);
            return _infraDal.ExecSpQuery(cmd);
        }
    }
}