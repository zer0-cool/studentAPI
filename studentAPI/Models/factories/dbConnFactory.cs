using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace studentAPI.Models.factories
{
    public class dbConnFactory : IdbConnFactory
    {
            private readonly string _connectionString;

            public dbConnFactory(string connectionString)
            {
                _connectionString = connectionString;
            }

            public IDbConnection CreateConnection()
            {
                var conn = new SqlConnection(_connectionString);
                conn.Open();
                return conn;
            }
    }
}