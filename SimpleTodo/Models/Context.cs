using System.Data.Entity;
using System.Data.Entity.Migrations;
using SimpleTodo.Models;

public class Context : DbContext
{
    public DbSet<LogOnModel> Users { get; set; }
    public DbSet<TodoList> Lists { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>());
    }
}

public class Configuration : DbMigrationsConfiguration<Context>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = true;
        AutomaticMigrationDataLossAllowed = true;
    }
}