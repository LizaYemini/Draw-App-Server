using DrawPicContracts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrawPicApp
{
    public class ProductionDbContextConnectionString : IConnectionString
    {
        public ProductionDbContextConnectionString()
        {
            ConnectionString =
                "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=CTL;Password=1234;";
        }
        public ProductionDbContextConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; }
    }
}
