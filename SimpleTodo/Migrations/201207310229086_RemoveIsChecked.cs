namespace SimpleTodo.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIsChecked : DbMigration
    {
        public override void Up()
        {
            DropColumn("TodoItems", "IsChecked");
        }
        
        public override void Down()
        {
            AddColumn("TodoItems", "IsChecked", c => c.Boolean(nullable: false, defaultValue: false));
        }
    }
}
