using MySql.Data.Entity;
using System.Data.Entity;

namespace WebApplication2.Models
{
    public class MySqlConfiguration : DbConfiguration
    {
        public MySqlConfiguration()
        {
            SetHistoryContext(
            MySqlProviderInvariantName.ProviderName, (conn, schema) => new MySqlHistoryContext(conn, schema));
        }
    }
}