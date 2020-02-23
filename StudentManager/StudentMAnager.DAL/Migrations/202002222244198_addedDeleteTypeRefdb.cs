namespace StudentMAnager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDeleteTypeRefdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentClasses", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Courses", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Professors", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Professors", "IsActive");
            DropColumn("dbo.Courses", "IsActive");
            DropColumn("dbo.Students", "IsActive");
            DropColumn("dbo.StudentClasses", "IsActive");
        }
    }
}
