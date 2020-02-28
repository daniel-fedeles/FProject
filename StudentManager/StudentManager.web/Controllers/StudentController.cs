using log4net;
using Newtonsoft.Json;
using StudentManager.web.HellperMethods;
using StudentManager.web.ViewModels;
using StudentMAnager.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StudentManager.web.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        protected ILog _log;
        ApplicationDbContext db;
        private Mappers map;
        public StudentController()
        {
            db = new ApplicationDbContext();
            map = new Mappers();
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        // GET: Student
        public async Task<ActionResult> Index()
        {
            var studentList = await db.Students.ToListAsync();

            var studentsDetailList = new List<StudentsViewModel>();

            foreach (var student in studentList)
            {
                studentsDetailList.Add(map.MapToStudentModel(student));
            }
            _log.Info(JsonConvert.SerializeObject(studentsDetailList));
            return View(studentsDetailList);
        }


        // GET: Student/Details/5
        public async Task<ActionResult> DetailsAsync(string id)
        {
            var student = await db.Students
                .Include(c => c.Courses)
                .Include(sc => sc.StudentClass)
                .SingleOrDefaultAsync(x => x.Id == id);
            var model = map.MapToStudentModelDetails(student);
            // model.StudentClass = await db.Classes.SingleOrDefaultAsync(x => x.Id == student.StudentClassId);


            var grades = await db.Grades.ToListAsync();


            _log.Info(JsonConvert.SerializeObject(model));
            _log.Info(JsonConvert.SerializeObject(model.Courses));
            _log.Info(JsonConvert.SerializeObject(model.StudentClass));
            return View(model);
        }

        // GET: Student/Create
        public async Task<ActionResult> CreateStudent()
        {


            var model = new StudentDetailsViewModel
            {
                StudentClasses = await db.Classes.ToListAsync(),
                Courses = await db.Courses.ToListAsync()
            };

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

            var student = map.MapToStudent(model);
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

            var student = await db.Students
                .Include(c => c.Courses)
                .Include(sc => sc.StudentClass)
                .SingleOrDefaultAsync(x => x.Id == id);
            var model = map.MapToStudentModelDetails(student);
            var studentClasses = await db.Classes.ToListAsync();
            model.StudentClasses = studentClasses;

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
            var student = map.ModifyStudentObject(model, studentDb);

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
            var model = map.MapToStudentModelDetails(studentDb);

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

    }
}
