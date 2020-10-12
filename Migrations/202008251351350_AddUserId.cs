namespace MyHealth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserId : DbMigration
    {
        public override void Up()
        {
            Sql("alter table BmiCalculators add UserId int");
        }
        
        public override void Down()
        {
        }
    }
}
