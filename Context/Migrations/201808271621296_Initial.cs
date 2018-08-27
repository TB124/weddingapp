namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gift = c.Int(nullable: false),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TableId = c.Int(nullable: false),
                        PersonGroupId = c.Int(nullable: false),
                        Gift = c.Int(nullable: false),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonGroup", t => t.PersonGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Table", t => t.TableId, cascadeDelete: true)
                .Index(t => t.TableId)
                .Index(t => t.PersonGroupId);
            
            CreateTable(
                "dbo.Table",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Max_Person = c.Int(nullable: false),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "TableId", "dbo.Table");
            DropForeignKey("dbo.Person", "PersonGroupId", "dbo.PersonGroup");
            DropIndex("dbo.Person", new[] { "PersonGroupId" });
            DropIndex("dbo.Person", new[] { "TableId" });
            DropTable("dbo.Table");
            DropTable("dbo.Person");
            DropTable("dbo.PersonGroup");
        }
    }
}
