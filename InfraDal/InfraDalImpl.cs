using InfraContracts.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace InfraDal
{
    public class InfraDalImpl: IInfraDal
    {
        public DataSet ExecSpQuery(OracleCommand cmd)
        {
            var retval = new DataSet();
            var outParam = new OracleParameter();
            cmd.CommandType = CommandType.StoredProcedure;
            outParam.ParameterName = "p_RETVAL";
            outParam.OracleDbType = OracleDbType.RefCursor;
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(retval);
            return retval;
        }

        public OracleParameter GetParameter(string paramName, OracleDbType paramType
            , object paramValue)
        {
           return new OracleParameter
            {
                ParameterName = paramName,
                OracleDbType = paramType,
                Value = paramValue
            };
        }
    }
}
