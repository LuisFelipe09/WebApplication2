using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace WebApplication2.Models
{
    public class MySqlInitializer : IDatabaseInitializer<ApplicationDbContext>
    {
        public void InitializeDatabase(ApplicationDbContext context)
        {
            
            if (!context.Database.Exists())
            {
                // if database did not exist before - create it
                context.Database.Create();
            }
            else
            {

                var migrationHistoryTableExists = context.Database.SqlQuery<string>
                                 ("SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'IdentityMySQLDatabase' AND table_name = '__MigrationHistory'").FirstOrDefault();

                if (migrationHistoryTableExists.Equals("0"))
                {
                    context.Database.Delete();
                    context.Database.Create();
                }

            }
        }
    }
}