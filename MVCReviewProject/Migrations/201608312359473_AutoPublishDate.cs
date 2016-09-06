namespace MVCReviewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoPublishDate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.techReviews", "Published");
        }
        
        public override void Down()
        {
            AddColumn("dbo.techReviews", "Published", c => c.DateTime(nullable: false));
        }
    }
}
