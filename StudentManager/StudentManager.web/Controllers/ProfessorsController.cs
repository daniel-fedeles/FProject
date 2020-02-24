using StudentManager.DomainModels;
using StudentManager.web.ViewModels;
using StudentMAnager.DAL;
using System;
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
            var professorsDetailsList = new List<ProfessorsViewModel>();
            foreach (var professor in professorsList)
            {
                professorsDetailsList.Add(MapToModel(professor));
            }
            return View(professorsDetailsList);
        }

        // GET: Professors/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var professor = await db.Professors.SingleOrDefaultAsync(x => x.Id == id);
            var model = MapToModelDetails(professor);
            return View(model);
        }

        // GET: Professors/Create
        public ActionResult Create()
        {
            var model = new ProfessorDetailsViewModel();
            return View(model);
        }

        // POST: Professors/Create
        [HttpPost]
        public async Task<ActionResult> Create(ProfessorDetailsViewModel model)
        {
            var professor = MapToProfessor(model);
            professor.Id = Guid.NewGuid().ToString();
            professor.IsActive = true;

            try
            {
                db.Professors.Add(professor);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Professors/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var professor = await db.Professors.SingleOrDefaultAsync(x => x.Id == id);
            var model = MapToModelDetails(professor);
            return View(model);
        }

        // POST: Professors/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, ProfessorDetailsViewModel model)
        {
            var professor = await db.Professors.SingleOrDefaultAsync(x => x.Id == id);
            var modify = ModifyProfessorObject(model, professor);
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
        private Professor MapToProfessor(ProfessorDetailsViewModel model)
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

        private Professor ModifyProfessorObject(ProfessorDetailsViewModel model, Professor professor)
        {
            if (professor.FirstName != model.FirstName) { professor.FirstName = model.FirstName; }
            if (professor.LastName != model.LastName) { professor.LastName = model.LastName; }
            if (professor.Email != model.Email) { professor.Email = model.Email; }
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
