namespace Rss4Mobi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationmember : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "GUID", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "GUID", c => c.String());
        }
    }
}
