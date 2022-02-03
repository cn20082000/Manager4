using System.Data.Entity.Migrations;

namespace Manager4.common
{
    public sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Manager4.common.DatabaseContext";
        }
    }
}
