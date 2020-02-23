using StudentManager.DomainModels;
using StudentManager.web.ViewModels;
using StudentMAnager.DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StudentManager.web.Controllers
{
    public class ProfessorsController : Controller
    {
        private ApplicationDbContext db;

        public ProfessorsController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Professors
        public async Task<ActionResult> Index()
        {
            var professorsList = await db.Professors.ToListAsync();
            var professorsDetailsList = new List<ProfessorDetailsViewModel>();
            return View();
        }

        // GET: Professors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Professors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professors/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Professors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Professors/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Professors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Professors/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ProfessorsViewModel MapToModel(Professor professor)
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
        private ProfessorDetailsViewModel MapToModelDetails(Professor professor)
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
        private Professor MapToStudent(ProfessorDetailsViewModel model)
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
