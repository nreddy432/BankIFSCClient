namespace BankIFSCClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBankDistrictField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banks", "District", c => c.String());
            DropColumn("dbo.Banks", "Distruct");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Banks", "Distruct", c => c.String());
            DropColumn("dbo.Banks", "District");
        }
    }
}
