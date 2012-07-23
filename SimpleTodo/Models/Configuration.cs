using System.Data.Entity.Migrations;
using SimpleTodo.Models;

namespace SimpleTodo.Models
{
    public class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration ()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }

}