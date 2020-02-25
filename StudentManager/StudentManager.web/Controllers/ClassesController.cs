using StudentManager.DomainModels;
using StudentManager.web.HellperMethods;
using StudentManager.web.ViewModels;
using StudentMAnager.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StudentManager.web.Controllers
{
    public class ClassesController : Controller
    {
        private ApplicationDbContext db;
        private Mappers map;
        public ClassesController()
        {
            db = new ApplicationDbContext();
            map = new Mappers();
        }
        // GET: Classes
        public async Task<ActionResult> Index()
        {
            var classList = await db.Classes.ToListAsync();
            var modelList = new List<ClassViewModel>();

            foreach (var c in classList)
            {
                modelList.Add(MapToModel(c));
            }


            return View(modelList);
        }

        // GET: Classes/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var sClass = await db.Classes.SingleOrDefaultAsync(x => x.Id == id);

            var students = await db.Students.ToListAsync();
            var model = MapToModel(sClass);
            foreach (var student in students)
            {
                if (sClass != null && student.StudentClassId == sClass.Id)
                {
                    var s = map.MapToStudentModel(student);
                    model.Students.Add(s);

                }
            }


            return View(model);
        }

        // GET: Classes/Create
        public ActionResult Create()
        {
            var model = new ClassViewModel();
            return View(model);
        }

        // POST: Classes/Create
        [HttpPost]
        public async Task<ActionResult> Create(ClassViewModel model)
        {
            var sClass = new StudentClass();
            sClass.Id = Guid.NewGuid().ToString();
            sClass.Name = model.ClassName;
            sClass.IsActive = true;
            try
            {
                db.Classes.Add(sClass);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Classes/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var sClass = await db.Classes.SingleOrDefaultAsync(x => x.Id == id);
            var model = MapToModel(sClass);
            return View(model);
        }

        // POST: Classes/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, ClassViewModel model)
        {
            var sClass = await db.Classes.SingleOrDefaultAsync(x => x.Id == id);
            if (sClass != null)
            {
                if (sClass.Name != model.ClassName)
                {
                    sClass.Name = model.ClassName;
                }

                if (sClass.IsActive != model.IsActive)
                {
                    sClass.IsActive = model.IsActive;
                }
            }

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

        // GET: Classes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Classes/Delete/5
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

        private ClassViewModel MapToModel(StudentClass sClass)
        {
            var model = new ClassViewModel();
            model.Id = sClass.Id;
            model.ClassName = sClass.Name;
            if (sClass.Students != null)
            {
                model.NrOfStudentsAllocated = sClass.Students.Count;
            }
            model.IsActive = sClass.IsActive;

            return model;
        }
    }
}
