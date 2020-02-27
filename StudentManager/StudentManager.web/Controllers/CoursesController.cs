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
    public class CoursesController : Controller
    {
        private ApplicationDbContext db;
        private Mappers map;

        public CoursesController()
        {
            db = ApplicationDbContext.Create();
            map = new Mappers();
        }
        // GET: Courses
        public async Task<ActionResult> Index()
        {
            var courses = await db.Courses.ToListAsync();
            var modelList = new List<CourseViewModel>();
            foreach (var course in courses)
            {
                modelList.Add(map.MapToCourseModel(course));
            }

            return View(modelList);
        }

        // GET: Courses/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var course = await db.Courses
                .Include(p => p.Professor.Select(prof => prof.Courses))
                .Include(s => s.Students.Select(stud => stud.Courses))
                .SingleOrDefaultAsync(x => x.Id == id);

            var model = map.MapToCourseModel(course);
            return View(model);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            var model = new CourseViewModel();
            return View(model);
        }

        // POST: Courses/Create
        [HttpPost]
        public async Task<ActionResult> Create(CourseViewModel model)
        {
            var course = map.MapToCourse(model);
            course.Id = Guid.NewGuid().ToString();

            try
            {
                db.Courses.Add(course);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Courses/Edit/5
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

        // GET: Courses/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Courses/Delete/5
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
    }
}
