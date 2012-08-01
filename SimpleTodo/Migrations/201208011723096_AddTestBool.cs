namespace SimpleTodo.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddTestBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("LogOnModels", "TestBool", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("LogOnModels", "TestBool");
        }
    }
}
