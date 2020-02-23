namespace StudentMAnager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCourses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        ClassId = c.String(nullable: false, maxLength: 128),
                        ClassName = c.String(),
                    })
                .PrimaryKey(t => t.ClassId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.String(nullable: false, maxLength: 128),
                        Value = c.Double(nullable: false),
                        DateNote = c.DateTime(nullable: false),
                        CourseId = c.String(maxLength: 128),
                        StudentId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.GradeId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            AddColumn("dbo.Students", "StudentClassId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Students", "StudentClassId");
            AddForeignKey("dbo.Students", "StudentClassId", "dbo.StudentClasses", "ClassId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudentClassId", "dbo.StudentClasses");
            DropForeignKey("dbo.Grades", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Grades", "CourseId", "dbo.Courses");
            DropIndex("dbo.Grades", new[] { "StudentId" });
            DropIndex("dbo.Grades", new[] { "CourseId" });
            DropIndex("dbo.Students", new[] { "StudentClassId" });
            DropColumn("dbo.Students", "StudentClassId");
            DropTable("dbo.Grades");
            DropTable("dbo.StudentClasses");
        }
    }
}
