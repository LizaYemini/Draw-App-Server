using System;
using System.Data;
using DIContracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using DrawPicContracts.Interface.Dal;
using InfraContracts.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace ShareDal
{
    [Register(Policy.Transient, typeof(IShareDal))]
    public class ShareDalImpl : IShareDal
    {
        private readonly OracleConnection _conn;
        private readonly IInfraDal _infraDal;

        public ShareDalImpl(IInfraDal infraDal, IConnectionString connectionString)
        {
            _infraDal = infraDal;
            var strConn = connectionString.ConnectionString;
            _conn = new OracleConnection(strConn);
        }
        public DataSet CreateShare(CreateShareRequest request)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "CreateShare"
            };
            var param1 = _infraDal.GetParameter("Doc", OracleDbType.Varchar2, request.DocId);
            var param2 = _infraDal.GetParameter("User", OracleDbType.Varchar2, request.UserId);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            return _infraDal.ExecSpQuery(cmd);
        }

        public DataSet GetShareByDocId(GetShareByDocIdRequest request)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "GetShareByDocId"
            };
            var param1 = _infraDal.GetParameter("Id", OracleDbType.Varchar2, request.DocId);
            cmd.Parameters.Add(param1);
            return _infraDal.ExecSpQuery(cmd);
        }

        public DataSet GetShareByUserId(GetShareByUserIdRequest request)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "GetShareByUserId"
            };
            var param1 = _infraDal.GetParameter("Id", OracleDbType.Varchar2, request.UserId);
            cmd.Parameters.Add(param1);
            return _infraDal.ExecSpQuery(cmd);
        }
        public DataSet RemoveShare(RemoveShareRequest request)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "RemoveShare"
            };
            var param1 = _infraDal.GetParameter("Doc", OracleDbType.Varchar2, request.DocId);
            var param2 = _infraDal.GetParameter("User", OracleDbType.Varchar2, request.UserId);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            return _infraDal.ExecSpQuery(cmd);
        }
    }
}
