namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class book_publisher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "PublisherId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Books", "PublisherId");
            AddForeignKey("dbo.Books", "PublisherId", "dbo.Publishers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropColumn("dbo.Books", "PublisherId");
            DropTable("dbo.Publishers");
        }
    }
}
