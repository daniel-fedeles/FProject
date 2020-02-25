using StudentManager.DomainModels;
using StudentManager.web.ViewModels;

namespace StudentManager.web.HellperMethods
{
    public class Mappers
    {
        public StudentsViewModel MapToStudentModel(Student student)
        {
            var model = new StudentsViewModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Year = student.Year,
                Email = student.Email,
                Country = student.Country,
                Address1 = student.Address1,
                Address2 = student.Address2,
                City = student.City,
                BirthDay = student.BirthDay,
                IsActive = student.IsActive
            };
            return model;
        }
        public StudentDetailsViewModel MapToModelDetails(Student student)
        {
            var model = new StudentDetailsViewModel();
            model.Id = student.Id;
            model.FirstName = student.FirstName;
            model.LastName = student.LastName;
            model.Year = student.Year;
            model.Email = student.Email;
            model.Country = student.Country;
            model.Address1 = student.Address1;
            model.Address2 = student.Address2;
            model.City = student.City;
            model.BirthDay = student.BirthDay;
            model.Grades = student.Grades;
            model.Courses = student.Courses;
            model.StudentClassId = student.StudentClassId;
            model.IsActive = student.IsActive;
            return model;
        }
        public Student MapToStudent(StudentDetailsViewModel model)
        {
            var student = new Student();
            student.Id = model.Id;
            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.Year = model.Year;
            student.Email = model.Email;
            student.Country = model.Country;
            student.Address1 = model.Address1;
            student.Address2 = model.Address2;
            student.City = model.City;
            student.BirthDay = model.BirthDay;
            student.Courses = model.Courses;
            student.Grades = model.Grades;
            student.StudentClassId = model.StudentClassId.ToString();
            student.IsActive = model.IsActive;

            return student;
        }

        public Student ModifyStudentObject(StudentDetailsViewModel model, Student student)
        {
            if (student.FirstName != model.FirstName) { student.FirstName = model.FirstName; }
            if (student.LastName != model.LastName) { student.LastName = model.LastName; }
            if (student.Email != model.Email) { student.Email = model.Email; }
            if (student.Year != model.Year) { student.Year = model.Year; }
            if (student.BirthDay != model.BirthDay) { student.BirthDay = model.BirthDay; }
            if (student.Country != model.Country) { student.Country = model.Country; }
            if (student.Address1 != model.Address1) { student.Address1 = model.Address1; }
            if (student.Address2 != model.Address2) { student.Address2 = model.Address2; }
            if (student.City != model.City) { student.City = model.City; }
            if (student.IsActive != model.IsActive) { student.IsActive = model.IsActive; }

            return student;
        }

        public ProfessorsViewModel MapToProfessorModel(Professor professor)
        {
            var model = new ProfessorsViewModel
            {
                Id = professor.Id,
                FirstName = professor.FirstName,
                LastName = professor.LastName,
                Email = professor.Email,
                Country = professor.Country,
                Address1 = professor.Address1,
                Address2 = professor.Address2,
                City = professor.City,
                BirthDay = professor.BirthDay,
                IsActive = professor.IsActive,

            };
            return model;
        }
        public ProfessorDetailsViewModel MapToModelDetails(Professor professor)
        {
            var model = new ProfessorDetailsViewModel
            {
                Id = professor.Id,
                FirstName = professor.FirstName,
                LastName = professor.LastName,
                Email = professor.Email,
                Country = professor.Country,
                Address1 = professor.Address1,
                Address2 = professor.Address2,
                City = professor.City,
                BirthDay = professor.BirthDay,
                Courses = professor.Courses,
                IsActive = professor.IsActive,
            };
            return model;
        }
        public Professor MapToProfessor(ProfessorDetailsViewModel model)
        {
            var student = new Professor
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Country = model.Country,
                Address1 = model.Address1,
                Address2 = model.Address2,
                City = model.City,
                BirthDay = model.BirthDay,
                Courses = model.Courses,
                IsActive = model.IsActive
            };
            return student;
        }

        public Professor ModifyProfessorObject(ProfessorDetailsViewModel model, Professor professor)
        {
            if (professor.FirstName != model.FirstName) { professor.FirstName = model.FirstName; }
            if (professor.LastName != model.LastName) { professor.LastName = model.LastName; }
            if (professor.Email != model.Email) { professor.Email = model.Email; }
            if (professor.BirthDay != model.BirthDay) { professor.BirthDay = model.BirthDay; }
            if (professor.Country != model.Country) { professor.Country = model.Country; }
            if (professor.Address1 != model.Address1) { professor.Address1 = model.Address1; }
            if (professor.Address2 != model.Address2) { professor.Address2 = model.Address2; }
            if (professor.City != model.City) { professor.City = model.City; }
            if (professor.Courses != model.Courses) { professor.Courses = model.Courses; }
            if (professor.IsActive != model.IsActive) { professor.IsActive = model.IsActive; }

            return professor;
        }
    }
}