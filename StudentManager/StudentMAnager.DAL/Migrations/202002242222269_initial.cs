﻿namespace StudentMAnager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Year = c.Int(nullable: false),
                        StudentClassId = c.String(maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BirthDay = c.DateTime(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentClasses", t => t.StudentClassId)
                .Index(t => t.StudentClassId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Semester = c.Int(nullable: false),
                        Credits = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Value = c.Double(nullable: false),
                        DateNote = c.DateTime(nullable: false),
                        CourseId = c.String(maxLength: 128),
                        StudentId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BirthDay = c.DateTime(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProfessorCourse",
                c => new
                    {
                        ProfessorRedId = c.String(nullable: false, maxLength: 128),
                        CourseRefId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProfessorRedId, t.CourseRefId })
                .ForeignKey("dbo.Professors", t => t.ProfessorRedId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseRefId, cascadeDelete: true)
                .Index(t => t.ProfessorRedId)
                .Index(t => t.CourseRefId);
            
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        StudentRedId = c.String(nullable: false, maxLength: 128),
                        CourseRefId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.StudentRedId, t.CourseRefId })
                .ForeignKey("dbo.Students", t => t.StudentRedId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseRefId, cascadeDelete: true)
                .Index(t => t.StudentRedId)
                .Index(t => t.CourseRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Students", "StudentClassId", "dbo.StudentClasses");
            DropForeignKey("dbo.Grades", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCourse", "CourseRefId", "dbo.Courses");
            DropForeignKey("dbo.StudentCourse", "StudentRedId", "dbo.Students");
            DropForeignKey("dbo.ProfessorCourse", "CourseRefId", "dbo.Courses");
            DropForeignKey("dbo.ProfessorCourse", "ProfessorRedId", "dbo.Professors");
            DropForeignKey("dbo.Grades", "CourseId", "dbo.Courses");
            DropIndex("dbo.StudentCourse", new[] { "CourseRefId" });
            DropIndex("dbo.StudentCourse", new[] { "StudentRedId" });
            DropIndex("dbo.ProfessorCourse", new[] { "CourseRefId" });
            DropIndex("dbo.ProfessorCourse", new[] { "ProfessorRedId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Grades", new[] { "StudentId" });
            DropIndex("dbo.Grades", new[] { "CourseId" });
            DropIndex("dbo.Students", new[] { "StudentClassId" });
            DropTable("dbo.StudentCourse");
            DropTable("dbo.ProfessorCourse");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Professors");
            DropTable("dbo.Grades");
            DropTable("dbo.Courses");
            DropTable("dbo.Students");
            DropTable("dbo.StudentClasses");
        }
    }
}
