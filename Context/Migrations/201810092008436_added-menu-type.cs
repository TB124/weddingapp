namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmenutype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "MenuType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "MenuType");
        }
    }
}
