namespace StudentMAnager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Professors", "Prof_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Students", "Stud_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Students", new[] { "Stud_Id" });
            DropIndex("dbo.Professors", new[] { "Prof_Id" });
            AddColumn("dbo.Students", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Students", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Professors", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Professors", "LastName", c => c.String(nullable: false));
            DropColumn("dbo.Students", "Stud_Id");
            DropColumn("dbo.Professors", "Prof_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Professors", "Prof_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Students", "Stud_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Professors", "LastName");
            DropColumn("dbo.Professors", "FirstName");
            DropColumn("dbo.Students", "LastName");
            DropColumn("dbo.Students", "FirstName");
            CreateIndex("dbo.Professors", "Prof_Id");
            CreateIndex("dbo.Students", "Stud_Id");
            AddForeignKey("dbo.Students", "Stud_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Professors", "Prof_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
