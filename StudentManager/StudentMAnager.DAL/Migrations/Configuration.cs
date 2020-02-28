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
                Name = "Group A1"
            };
            var course = new Course
            {
                Year = 1,
                IsActive = active,
                Id = courseId,
                Name = "Math",
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
                FirstName = "Ionescu",
                LastName = "Gabriel",
                Email = "ionescu.gabriel@gmail.com",
                Id = professorId,
                Country = "Romania",
                BirthDay = DateTime.Parse("01.01.1962"),
                Address1 = "Iasi",
                Address2 = "Salcamilor nr.25",
                City = "Iasi",
                Courses = new List<Course> { course }
            };

            var student = new Student
            {
                Id = studentId,
                StudentClassId = classId,
                IsActive = active,
                FirstName = "Popescu",
                LastName = "Ionut",
                Email = "ionut.popescu@gmail.com",
                Address1 = "Iasi",
                Address2 = "Merilor 25",
                BirthDay = DateTime.Parse("01.01.1986"),
                City = "Iasi",
                Country = "Romania",
                Year = 1,
                Courses = new List<Course> { course },
                Grades = new List<Grade> { nine }
            };

            var classId1 = Guid.NewGuid().ToString();
            var studentId1 = Guid.NewGuid().ToString();
            var courseId1 = Guid.NewGuid().ToString();
            var gradeId1 = Guid.NewGuid().ToString();
            var professorId1 = Guid.NewGuid().ToString();

            var sClass1 = new StudentClass
            {
                IsActive = active,
                Id = classId1,
                Name = "Group B2"
            };
            var course1 = new Course
            {
                Year = 1,
                IsActive = active,
                Id = courseId1,
                Name = "Web development",
                Credits = 5,
                Semester = 2
            };
            var nine1 = new Grade
            {
                Id = gradeId1,
                DateNote = DateTime.Today,
                Value = 9.5,
                CourseId = courseId1,
                StudentId = studentId1,
            };
            var professor1 = new Professor
            {
                IsActive = active,
                FirstName = "Sabin",
                LastName = "Cornelus",
                Email = "s.cornelus@gmail.com",
                Id = professorId1,
                Country = "Romania",
                BirthDay = DateTime.Parse("01.01.1988"),
                Address1 = "Iasi",
                Address2 = "Copou 65",
                City = "Iasi",
                Courses = new List<Course> { course1 }
            };

            var student1 = new Student
            {
                Id = studentId1,
                StudentClassId = classId1,
                IsActive = active,
                FirstName = "Stan",
                LastName = "Alex",
                Email = "alex.stan@gmail.com",
                Address1 = "Iasi",
                Address2 = "Bazei 2.2.p",
                BirthDay = DateTime.Parse("01.01.1995"),
                City = "Iasi",
                Country = "Romania",
                Year = 1,
                Courses = new List<Course> { course1 },
                Grades = new List<Grade> { nine1 }
            };


            context.Grades.AddOrUpdate(nine);
            context.Classes.AddOrUpdate(sClass);
            context.Courses.AddOrUpdate(course);
            context.Professors.AddOrUpdate(professor);
            context.Students.AddOrUpdate(student);


            context.Grades.AddOrUpdate(nine1);
            context.Classes.AddOrUpdate(sClass1);
            context.Courses.AddOrUpdate(course1);
            context.Professors.AddOrUpdate(professor1);
            context.Students.AddOrUpdate(student1);

        }
    }
}
