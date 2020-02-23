using StudentManager.DomainModels;
using StudentManager.web.ViewModels;
using StudentMAnager.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StudentManager.web.Controllers
{
    public class StudentController : Controller
    {
        ApplicationDbContext db;

        public StudentController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Student
        public async Task<ActionResult> Index()
        {
            var studentList = await db.Students.ToListAsync();

            var studentsDetailList = new List<StudentsViewModel>();

            foreach (var student in studentList)
            {
                studentsDetailList.Add(MapToModel(student));
            }
            return View(studentsDetailList);
        }


        // GET: Student/Details/5
        public async Task<ActionResult> DetailsAsync(string id)
        {
            var student = await db.Students.SingleOrDefaultAsync(x => x.Id == id);
            var model = MapToModelDetails(student);
            return View(model);
        }

        // GET: Student/Create
        public ActionResult CreateStudent()
        {
            var model = new StudentDetailsViewModel();
            return View(model);
        }

        // POST: Student/Create
        [HttpPost]
        public async Task<ActionResult> CreateStudent(StudentDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StudentDetailsViewModel();
                return View(viewModel);
            }

            var student = MapToStudent(model);
            student.Id = Guid.NewGuid().ToString();
            student.IsActive = true;

            try
            {
                db.Students.Add(student);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Student/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var student = await db.Students.SingleOrDefaultAsync(x => x.Id == id);
            var model = MapToModelDetails(student);

            return View(model);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, StudentDetailsViewModel model)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (!ModelState.IsValid)
            {
                var viewModel = new StudentDetailsViewModel();
                return View(viewModel);
            }
            var studentDb = await db.Students.SingleOrDefaultAsync(x => x.Id == id);
            // var model = MapToModelDetails(student);
            var student = ModifyStudentObject(model, studentDb);
            try
            {
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Edit");
            }
        }

        // GET: Student/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var studentDb = await db.Students.SingleOrDefaultAsync(x => x.Id == id);
            var model = MapToModelDetails(studentDb);
            
            return View(model);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id, StudentDetailsViewModel model)
        {
            db.Students.Remove(db.Students.Single(x => x.Id == id));
            
            try
            {
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        private StudentsViewModel MapToModel(Student student)
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
        private StudentDetailsViewModel MapToModelDetails(Student student)
        {
            var model = new StudentDetailsViewModel
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
                Grades = student.Grades,
                Courses = student.Courses,
                StudentClass = student.StudentClass,
                IsActive = student.IsActive
            };
            return model;
        }
        private Student MapToStudent(StudentDetailsViewModel model)
        {
            var student = new Student
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Year = model.Year,
                Email = model.Email,
                Country = model.Country,
                Address1 = model.Address1,
                Address2 = model.Address2,
                City = model.City,
                BirthDay = model.BirthDay,
                Courses = model.Courses,
                Grades = model.Grades,
                StudentClass = model.StudentClass,
                IsActive = model.IsActive
            };
            return student;
        }

        private Student ModifyStudentObject(StudentDetailsViewModel model, Student student)
        {
            if (student.FirstName != model.FirstName) { student.FirstName = model.FirstName; }
            if (student.LastName != model.LastName) { student.LastName = model.LastName; }
            if (student.Email != model.Email) { student.Email = model.Email; }
            if (student.Year != model.Year) { student.Year = model.Year; }
            if (student.Country != model.Country) { student.Country = model.Country; }
            if (student.Address1 != model.Address1) { student.Address1 = model.Address1; }
            if (student.Address2 != model.Address2) { student.Address2 = model.Address2; }
            if (student.City != model.City) { student.City = model.City; }
            if (student.IsActive != model.IsActive) { student.IsActive = model.IsActive; }

            return student;
        }
    }
}
