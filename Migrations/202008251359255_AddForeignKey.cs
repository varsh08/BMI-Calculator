namespace MyHealth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKey : DbMigration
    {
        public override void Up()
        {
            Sql("alter table BmiCalculators add foreign key(UserId) references Registers(Id)");
        }
        
        public override void Down()
        {
        }
    }
}
