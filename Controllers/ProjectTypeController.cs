using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using TrabalhoFinal.Filters;

namespace TrabalhoFinal.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class ProjectTypeController : Controller
    {
        private DataModelContext db = new DataModelContext();

        //
        // GET: /ProjectType/

        public ActionResult Index()
        {
            return View(db.ProjectTypes.ToList());
        }

        //
        // GET: /ProjectType/Details/5

        public ActionResult Details(int id = 0)
        {
            ProjectType projecttype = db.ProjectTypes.Find(id);
            if (projecttype == null)
            {
                return HttpNotFound();
            }
            return View(projecttype);
        }

        //
        // GET: /ProjectType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ProjectType/Create

        [HttpPost]
        public ActionResult Create(ProjectType projecttype)
        {
            if (ModelState.IsValid)
            {
                db.ProjectTypes.Add(projecttype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projecttype);
        }

        //
        // GET: /ProjectType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProjectType projecttype = db.ProjectTypes.Find(id);
            if (projecttype == null)
            {
                return HttpNotFound();
            }
            return View(projecttype);
        }

        //
        // POST: /ProjectType/Edit/5

        [HttpPost]
        public ActionResult Edit(ProjectType projecttype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projecttype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projecttype);
        }

        //
        // GET: /ProjectType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProjectType projecttype = db.ProjectTypes.Find(id);
            if (projecttype == null)
            {
                return HttpNotFound();
            }
            return View(projecttype);
        }

        //
        // POST: /ProjectType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectType projecttype = db.ProjectTypes.Find(id);
            db.ProjectTypes.Remove(projecttype);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}