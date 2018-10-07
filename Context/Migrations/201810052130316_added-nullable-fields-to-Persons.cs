namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednullablefieldstoPersons : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Person", "PersonGroupId", "dbo.PersonGroup");
            DropForeignKey("dbo.Person", "TableId", "dbo.Table");
            DropIndex("dbo.Person", new[] { "TableId" });
            DropIndex("dbo.Person", new[] { "PersonGroupId" });
            AlterColumn("dbo.Person", "TableId", c => c.Int());
            AlterColumn("dbo.Person", "PersonGroupId", c => c.Int());
            CreateIndex("dbo.Person", "TableId");
            CreateIndex("dbo.Person", "PersonGroupId");
            AddForeignKey("dbo.Person", "PersonGroupId", "dbo.PersonGroup", "Id");
            AddForeignKey("dbo.Person", "TableId", "dbo.Table", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "TableId", "dbo.Table");
            DropForeignKey("dbo.Person", "PersonGroupId", "dbo.PersonGroup");
            DropIndex("dbo.Person", new[] { "PersonGroupId" });
            DropIndex("dbo.Person", new[] { "TableId" });
            AlterColumn("dbo.Person", "PersonGroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.Person", "TableId", c => c.Int(nullable: false));
            CreateIndex("dbo.Person", "PersonGroupId");
            CreateIndex("dbo.Person", "TableId");
            AddForeignKey("dbo.Person", "TableId", "dbo.Table", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Person", "PersonGroupId", "dbo.PersonGroup", "Id", cascadeDelete: true);
        }
    }
}
