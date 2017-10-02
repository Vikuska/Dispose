using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDate
{
    public class DatabaseState : IDisposable
    {
        protected SqlConnection _connection;
        private bool _disposed;

        public virtual string GetDate()
        {
            if(_disposed)
                throw new ObjectDisposedException("DatabaseState");

            if(_connection==null)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["master"];
                _connection = new SqlConnection(connectionString.ConnectionString);
                _connection.Open();
            }

            using (var command = _connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT GETDATE()";
                return command.ExecuteScalar().ToString();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                //_connection.Close();
                _connection.Dispose();
                _connection = null;
            }
            _disposed = true;
        }
    }
}
