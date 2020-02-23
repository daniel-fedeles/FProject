namespace StudentMAnager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedemail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Professors", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Professors", "Email");
            DropColumn("dbo.Students", "Email");
        }
    }
}
