using Dapper;
using System.Collections.Generic;
using System.Data;

namespace Practicas.Models
{
    public abstract class DapperBaseContext
    {
        protected abstract IDbConnection Connection { get; }
        protected IEnumerable<T> Exec<T>(string command)
        {
            IEnumerable<T> result = null;
            using (var conn = Connection)
            {
                conn.Open();
                result = conn.Query<T>(command, commandType: CommandType.Text);
            }

            return result;
        }

        protected IEnumerable<T> Exec<T>(string command, object parameters)
        {
            IEnumerable<T> result = null;
            using (var conn = Connection)
            {
                conn.Open();
                result = conn.Query<T>(command, parameters, commandType: CommandType.Text);
            }

            return result;
        }
    }
}