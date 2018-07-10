namespace BankIFSCClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationsToBank : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Banks", "IFSCCode", c => c.String(maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Banks", "IFSCCode", c => c.String());
        }
    }
}
