using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql
{
    public class DatabaseState : IDisposable
    {
        private SqlConnection _connection;

        public string GetDate()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection("Server=(local);Database=master;Integrated Security=SSPI;Max pool size=215;Connection Timeout=2;App=Teest;");
                _connection.Open();
            }

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT getdate()";
                return command.ExecuteScalar().ToString();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            var action = disposing ? "Disposing" : "Finalizing";
            Console.WriteLine(string.Format("{0}, SqlConnection: {1}", action, _connection.GetHashCode().ToString()));
            if (disposing)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        ~DatabaseState()
        {
            Dispose(false);
        }
    }
}
