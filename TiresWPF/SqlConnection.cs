using System;

namespace Tutorial.SqlConn
{
    internal class SqlConnection
    {
        private string connString;

        public SqlConnection(string connString)
        {
            this.connString = connString;
        }

        public static implicit operator System.Data.SqlClient.SqlConnection(SqlConnection v)
        {
            throw new NotImplementedException();
        }
    }
}