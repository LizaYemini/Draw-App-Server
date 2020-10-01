using System;
using System.Data;
using Contracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace ShareDal
{
    [Register(Policy.Transient, typeof(IShareDal))]
    public class ShareDalImpl : IShareDal
    {
        private readonly OracleConnection _conn;
        private readonly IInfraDal _infraDal;

        public ShareDalImpl(IInfraDal infraDal)
        {
            _infraDal = infraDal;
            var strConn =
                "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=CTL;Password=1234;";
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
