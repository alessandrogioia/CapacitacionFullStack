namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class book_photo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Photo");
        }
    }
}
