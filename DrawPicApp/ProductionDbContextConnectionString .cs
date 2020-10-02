using DrawPicContracts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrawPicApp
{
    public class ProductionDbContextConnectionString : IConnectionString
    {
        public ProductionDbContextConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; }
    }
}
