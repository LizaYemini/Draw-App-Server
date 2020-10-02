using System;
using System.Data;
using Contracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace MarkerDal
{
    [Register(Policy.Transient, typeof(IMarkerDal))]
    public class MarkerDalImpl : IMarkerDal
    {
        private readonly OracleConnection _conn;
        private readonly IInfraDal _infraDal;

        public MarkerDalImpl(IInfraDal infraDal, IConnectionString connectionString)
        {
            _infraDal = infraDal;
            var strConn = connectionString.ConnectionString;
            _conn = new OracleConnection(strConn);
        }
        public DataSet CreateMarker(CreateMarkerRequest request)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "CreateMarker"
            };
            var param1 = _infraDal.GetParameter("DocId", OracleDbType.Varchar2, request.DocId);
            var param2 = _infraDal.GetParameter("OutMarkerId", OracleDbType.Varchar2, request.MarkerId);
            var param3 = _infraDal.GetParameter("MarkerType", OracleDbType.Varchar2, request.MarkerType);
            var param4 = _infraDal.GetParameter("ForColor", OracleDbType.Varchar2, request.ForColor);
            var param5 = _infraDal.GetParameter("BackColor", OracleDbType.Varchar2, request.BackColor);
            var param6 = _infraDal.GetParameter("UserId", OracleDbType.Varchar2, request.UserId);
            var param7 = _infraDal.GetParameter("LocationX", OracleDbType.Double, request.LocationX);
            var param8 = _infraDal.GetParameter("LocationY", OracleDbType.Double, request.LocationY);
            var param9 = _infraDal.GetParameter("Width", OracleDbType.Double, request.Width);
            var param10 = _infraDal.GetParameter("Height", OracleDbType.Double, request.Height);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);
            cmd.Parameters.Add(param9);
            cmd.Parameters.Add(param10);
            return _infraDal.ExecSpQuery(cmd);
        }

        public DataSet GetMarkers(GetMarkersRequest request)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "GetMarkers"
            };
            var param1 = _infraDal.GetParameter("Id", OracleDbType.Varchar2, request.DocId);
            cmd.Parameters.Add(param1);
            return _infraDal.ExecSpQuery(cmd);
        }

        public DataSet RemoveMarker(RemoveMarkerRequest request)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "RemoveMarker"
            };
            var param1 = _infraDal.GetParameter("Id", OracleDbType.Varchar2, request.MarkerId);
            cmd.Parameters.Add(param1);
            return _infraDal.ExecSpQuery(cmd);
        }

        public DataSet UpdateMarker(CreateMarkerRequest request)
        {
            var cmd = new OracleCommand
            {
                Connection = _conn,
                CommandText = "UpdateMarker"
            };
            var param1 = _infraDal.GetParameter("DocIdn", OracleDbType.Varchar2, request.DocId);
            var param2 = _infraDal.GetParameter("MarkerIdn", OracleDbType.Varchar2, request.MarkerId);
            var param3 = _infraDal.GetParameter("MarkerTypen", OracleDbType.Varchar2, request.MarkerType);
            var param4 = _infraDal.GetParameter("ForColorn", OracleDbType.Varchar2, request.ForColor);
            var param5 = _infraDal.GetParameter("BackColorn", OracleDbType.Varchar2, request.BackColor);
            var param6 = _infraDal.GetParameter("UserIdn", OracleDbType.Varchar2, request.UserId);
            var param7 = _infraDal.GetParameter("LocationXn", OracleDbType.Double, request.LocationX);
            var param8 = _infraDal.GetParameter("LocationYn", OracleDbType.Double, request.LocationY);
            var param9 = _infraDal.GetParameter("Widthn", OracleDbType.Double, request.Width);
            var param10 = _infraDal.GetParameter("Heightn", OracleDbType.Double, request.Height);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);
            cmd.Parameters.Add(param9);
            cmd.Parameters.Add(param10);
            return _infraDal.ExecSpQuery(cmd);
        }
    }
}
