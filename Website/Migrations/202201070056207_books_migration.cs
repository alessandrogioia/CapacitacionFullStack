namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class books_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        ISBN = c.String(maxLength: 13),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
