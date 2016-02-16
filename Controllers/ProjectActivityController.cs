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
    public class ProjectActivityController : Controller
    {
        private DataModelContext db = new DataModelContext();

        //
        // GET: /ProjectActivity/

        public ActionResult Index()
        {
            var projectactivities = db.ProjectActivities.Include(p => p.UserProfile).Include(p => p.ProjectType);
            return View(projectactivities.ToList());
        }

        //
        // GET: /ProjectActivity/Details/5

        public ActionResult Details(int id = 0)
        {
            ProjectActivity projectactivity = db.ProjectActivities.Find(id);
            if (projectactivity == null)
            {
                return HttpNotFound();
            }
            return View(projectactivity);
        }

        //
        // GET: /ProjectActivity/Create

        public ActionResult Create()
        {
            ViewBag.OwnerUserID = new SelectList(db.UserProfiles, "UserId", "UserName");
            ViewBag.ProjectTypeID = new SelectList(db.ProjectTypes, "ProjectTypeID", "Description");
            return View();
        }

        //
        // POST: /ProjectActivity/Create

        [HttpPost]
        public ActionResult Create(ProjectActivity projectactivity)
        {
            if (ModelState.IsValid)
            {
                db.ProjectActivities.Add(projectactivity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerUserID = new SelectList(db.UserProfiles, "UserId", "UserName", projectactivity.OwnerUserID);
            ViewBag.ProjectTypeID = new SelectList(db.ProjectTypes, "ProjectTypeID", "Description", projectactivity.ProjectTypeID);
            return View(projectactivity);
        }

        //
        // GET: /ProjectActivity/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProjectActivity projectactivity = db.ProjectActivities.Find(id);
            if (projectactivity == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerUserID = new SelectList(db.UserProfiles, "UserId", "UserName", projectactivity.OwnerUserID);
            ViewBag.ProjectTypeID = new SelectList(db.ProjectTypes, "ProjectTypeID", "Description", projectactivity.ProjectTypeID);
            return View(projectactivity);
        }

        //
        // POST: /ProjectActivity/Edit/5

        [HttpPost]
        public ActionResult Edit(ProjectActivity projectactivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectactivity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerUserID = new SelectList(db.UserProfiles, "UserId", "UserName", projectactivity.OwnerUserID);
            ViewBag.ProjectTypeID = new SelectList(db.ProjectTypes, "ProjectTypeID", "Description", projectactivity.ProjectTypeID);
            return View(projectactivity);
        }

        //
        // GET: /ProjectActivity/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProjectActivity projectactivity = db.ProjectActivities.Find(id);
            if (projectactivity == null)
            {
                return HttpNotFound();
            }
            return View(projectactivity);
        }

        //
        // POST: /ProjectActivity/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectActivity projectactivity = db.ProjectActivities.Find(id);
            db.ProjectActivities.Remove(projectactivity);
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