using StudentManager.DomainModels;
using System;
using System.Collections.Generic;

namespace StudentMAnager.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentMAnager.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentMAnager.DAL.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var active = true;
            var classId = Guid.NewGuid().ToString();
            var studentId = Guid.NewGuid().ToString();
            var courseId = Guid.NewGuid().ToString();
            var gradeId = Guid.NewGuid().ToString();
            var professorId = Guid.NewGuid().ToString();

            var sClass = new StudentClass
            {
                IsActive = active,
                Id = classId,
                Name = "Clasa A"
            };
            var course = new Course
            {
                Year = 1,
                IsActive = active,
                Id = courseId,
                Name = "Ceva",
                Credits = 5,
                Semester = 2
            };
            var nine = new Grade
            {
                Id = gradeId,
                DateNote = DateTime.Today,
                Value = 9.5,
                CourseId = courseId,
                StudentId = studentId,
            };
            var professor = new Professor
            {
                IsActive = active,
                FirstName = "Bla",
                LastName = "Blu",
                Email = "blablu@zzz.ccc",
                Id = professorId,
                Country = "Laciupakabra",
                BirthDay = DateTime.Parse("01.01.1962"),
                Address1 = "alt",
                Address2 = "Kiki",
                City = "hahaha",
                Courses = new List<Course> { course }
            };

            var student = new Student
            {
                Id = studentId,
                StudentClassId = classId,
                IsActive = active,
                FirstName = "Gigi",
                LastName = "Kent",
                Email = "GK@bbb.com",
                Address1 = "Undeva",
                Address2 = "departe",
                BirthDay = DateTime.Parse("01.01.1986"),
                City = "Kentia",
                Country = "Kentania",
                Year = 1,
                Courses = new List<Course> { course },
                Grades = new List<Grade> { nine }
            };

            context.Grades.AddOrUpdate(nine);
            context.Classes.AddOrUpdate(sClass);
            context.Courses.AddOrUpdate(course);
            context.Professors.AddOrUpdate(professor);
            context.Students.AddOrUpdate(student);

        }
    }
}
