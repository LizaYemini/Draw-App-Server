using System;
using System.Data;
using Contracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace DocumentsDal
{
    [Register(Policy.Transient, typeof(IDocumentsDal))]
    public class DocumentsDalImpl : IDocumentsDal
    {
        private readonly OracleConnection _conn;
        private readonly IInfraDal _infraDal;

        public DocumentsDalImpl(IInfraDal infraDal)
        {
            _infraDal = infraDal;
            var strConn =
                "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=CTL;Password=1234;";
            _conn = new OracleConnection(strConn);
        }
        public DataSet AddDocument(AddDocumentRequest request, string docId)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "AddDocument "
            };
            var param1 = _infraDal.GetParameter("OwnerID", OracleDbType.Varchar2, request.Owner);
            var param2 = _infraDal.GetParameter("ImageUrl", OracleDbType.Varchar2, request.ImageUrl);
            var param3 = _infraDal.GetParameter("DocumentName", OracleDbType.Varchar2, request.DocumentName);
            var param4 = _infraDal.GetParameter("DocId", OracleDbType.Varchar2, docId);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            return _infraDal.ExecSpQuery(cmd);
        }

        public DataSet UpdateDocument(UpdateDocumentRequest request)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "UpdateDocument"
            };
            var param1 = _infraDal.GetParameter("OwnerN", OracleDbType.Varchar2, request.Owner);
            var param2 = _infraDal.GetParameter("ImageUrlN", OracleDbType.Varchar2, request.ImageUrl);
            var param3 = _infraDal.GetParameter("DocumentNameN", OracleDbType.Varchar2, request.DocumentName);
            var param4 = _infraDal.GetParameter("IdN", OracleDbType.Varchar2, request.DocId);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            return _infraDal.ExecSpQuery(cmd);
        }

        public DataSet RemoveDocument(RemoveDocumentRequest request)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "RemoveDocument"
            };
            var param1 = _infraDal.GetParameter("Id", OracleDbType.Varchar2, request.DocId);
            cmd.Parameters.Add(param1);
            return _infraDal.ExecSpQuery(cmd);
        }

        public DataSet GetDocsByOwnerId(GetDocsByOwnerIdRequest request)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "GetDocsByOwnerId"
            };
            var param1 = _infraDal.GetParameter("Id", OracleDbType.Varchar2, request.Owner);
            cmd.Parameters.Add(param1);
            return _infraDal.ExecSpQuery(cmd);
        }

        public DataSet GetDocByDocId(GetDocByDocIdRequest request)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "GetDocByDocId"
            };
            var param1 = _infraDal.GetParameter("Id", OracleDbType.Varchar2, request.DocId);
            cmd.Parameters.Add(param1);
            return _infraDal.ExecSpQuery(cmd);
        }
    }
}
