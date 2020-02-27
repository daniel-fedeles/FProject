using StudentManager.web.HellperMethods;
using StudentManager.web.ViewModels;
using StudentMAnager.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StudentManager.web.Controllers
{
    [Authorize]
    public class ProfessorsController : Controller
    {
        private ApplicationDbContext db;
        private Mappers map;

        public ProfessorsController()
        {
            db = new ApplicationDbContext();
            map = new Mappers();
        }
        // GET: Professors
        public async Task<ActionResult> Index()
        {
            var professorsList = await db.Professors.ToListAsync();
            var professorsDetailsList = new List<ProfessorsViewModel>();
            foreach (var professor in professorsList)
            {
                professorsDetailsList.Add(map.MapToProfessorModel(professor));
            }
            return View(professorsDetailsList);
        }

        // GET: Professors/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var professor = await db.Professors.SingleOrDefaultAsync(x => x.Id == id);
            var model = map.MapToProfessorModelDetails(professor);
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
            var professor = map.MapToProfessor(model);
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
                return View("Error");
            }
        }

        // GET: Professors/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var professor = await db.Professors.SingleOrDefaultAsync(x => x.Id == id);
            var model = map.MapToProfessorModelDetails(professor);
            return View(model);
        }

        // POST: Professors/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, ProfessorDetailsViewModel model)
        {
            var professor = await db.Professors.SingleOrDefaultAsync(x => x.Id == id);
            var modify = map.ModifyProfessorObject(model, professor);
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

        // GET: Professors/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var professor = await db.Professors.SingleOrDefaultAsync(x => x.Id == id);
            var model = map.MapToProfessorModelDetails(professor);
            return View(model);
        }

        // POST: Professors/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id, ProfessorDetailsViewModel collection)
        {
            db.Professors.Remove(db.Professors.Single(x => x.Id == id));

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


    }
}
