using System;
using System.Data;
using DIContracts;
using DrawPicContracts.DTO.LiveWatch;
using DrawPicContracts.Interface;
using DrawPicContracts.Interface.Dal;
using InfraContracts.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace LiveWatchDocsDal
{
    [Register(Policy.Transient, typeof(ILiveWatchDocsDal))]
    public class LiveWatchDocsDalImpl : ILiveWatchDocsDal
    {
        private readonly OracleConnection _conn;
        private readonly IInfraDal _infraDal;

        public LiveWatchDocsDalImpl(IInfraDal infraDal, IConnectionString connectionString)
        {
            _infraDal = infraDal;
            var strConn = connectionString.ConnectionString;
            _conn = new OracleConnection(strConn);
        }

        public DataSet CreateLiveWatchDoc(CreateLiveWatchDocRequest request)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "CreateLiveWatchDoc"
            };
            var param1 = _infraDal.GetParameter("Doc", OracleDbType.Varchar2, request.DocId);
            var param2 = _infraDal.GetParameter("User", OracleDbType.Varchar2, request.UserId);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            return _infraDal.ExecSpQuery(cmd);
        }

        public DataSet GetWatchersOfDoc(GetWatchersOfDocRequest request)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "GetWatchersOfDoc"
            };
            var param1 = _infraDal.GetParameter("Id", OracleDbType.Varchar2, request.DocId);
            cmd.Parameters.Add(param1);
            return _infraDal.ExecSpQuery(cmd);
        }

        public DataSet RemoveLiveWatchDoc(RemoveLiveWatchDocRequest request)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "RemoveLiveWatchDoc"
            };
            var param1 = _infraDal.GetParameter("Doc", OracleDbType.Varchar2, request.DocId);
            var param2 = _infraDal.GetParameter("User", OracleDbType.Varchar2, request.UserId);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            return _infraDal.ExecSpQuery(cmd);
        }
    }
}
