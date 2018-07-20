using System.Data;
using System.Data.SqlClient;

namespace Practicas.Models
{
    public class DapperContext:DapperBaseContext
    {
        protected override IDbConnection Connection => new SqlConnection("data source=LEON-LAPTOP1\\SQLEXPRESS;;Integrated Security=SSPI;initial catalog=Clients");
    }
}