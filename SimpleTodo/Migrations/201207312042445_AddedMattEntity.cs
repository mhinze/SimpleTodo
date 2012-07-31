using System;

namespace SimpleTodo.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedMattEntity : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("LogOnModels");
            DropPrimaryKey("TodoItems");
            AddColumn("LogOnModels", "Created", c => c.DateTime(nullable: false));
            AddColumn("LogOnModels", "Updated", c => c.DateTime(nullable: false));
            AddColumn("TodoItems", "Created", c => c.DateTime(nullable: false, defaultValue: DateTime.Now));
            AddColumn("TodoItems", "Updated", c => c.DateTime(nullable: false, defaultValue: DateTime.Now));
            AlterColumn("LogOnModels", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("TodoItems", "Id", c => c.Long(nullable: false, identity: true));
            DropColumn("LogOnModels", "DateCreated");
            DropColumn("TodoItems", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("TodoItems", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("LogOnModels", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("TodoItems", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("LogOnModels", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("TodoItems", "Updated");
            DropColumn("TodoItems", "Created");
            DropColumn("LogOnModels", "Updated");
            DropColumn("LogOnModels", "Created");
        }
    }
}
