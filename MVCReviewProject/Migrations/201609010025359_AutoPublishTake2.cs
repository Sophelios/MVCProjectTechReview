namespace MVCReviewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoPublishTake2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.techReviews", "Published", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.techReviews", "Published");
        }
    }
}
