namespace LibraryBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initilaize_model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbstractItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        AuthorName = c.String(),
                        ItemPrice = c.Double(nullable: false),
                        PublicationDate = c.DateTime(nullable: false),
                        Discount = c.Int(nullable: false),
                        PriceAfterDiscount = c.Double(nullable: false),
                        BookType = c.Int(),
                        RecordType = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AbstractItems");
        }
    }
}
