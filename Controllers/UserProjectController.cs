using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoFinal.Models;


namespace TrabalhoFinal.Controllers
{
    public class UserProjectController : Controller
    {
        private DataModelContext db = new DataModelContext();

        //
        // GET: /UserProject/

        public ActionResult Index()
        {
            var userprojects = db.UserProjects.Include(u => u.ProjectActivity).Include(u => u.UserProfile).Where(up => up.UserProfile.UserName == User.Identity.Name);
            return View(userprojects.ToList());
        }

        //
        // GET: /UserProject/Details/5

        public ActionResult Details(int id = 0)
        {
            UserProject userproject = db.UserProjects.Find(id);
            if (userproject == null)
            {
                return HttpNotFound();
            }
            return View(userproject);
        }

        //
        // GET: /UserProject/Create

        public ActionResult Create()
        {
            ViewBag.ProjectActivityID = new SelectList(db.ProjectActivities, "ProjectActivityID", "Name");
            ViewBag.UserID = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /UserProject/Create

        [HttpPost]
        public ActionResult Create(UserProject userproject)
        {


            var loggedUser = db.UserProfiles.Where(user => user.UserName == User.Identity.Name)
                .Select(s => new { s.UserId });


            userproject.UserID = loggedUser.First().UserId;
            if (ModelState.IsValid)
            {
                db.UserProjects.Add(userproject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectActivityID = new SelectList(db.ProjectActivities, "ProjectActivityID", "Name", userproject.ProjectActivityID);
            ViewBag.UserID = new SelectList(db.UserProfiles, "UserId", "UserName", userproject.UserID);
            return View(userproject);
        }

        //
        // GET: /UserProject/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UserProject userproject = db.UserProjects.Find(id);
            if (userproject == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectActivityID = new SelectList(db.ProjectActivities, "ProjectActivityID", "Name", userproject.ProjectActivityID);
            ViewBag.UserID = new SelectList(db.UserProfiles, "UserId", "UserName", userproject.UserID);
            return View(userproject);
        }

        //
        // POST: /UserProject/Edit/5

        [HttpPost]
        public ActionResult Edit(UserProject userproject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userproject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectActivityID = new SelectList(db.ProjectActivities, "ProjectActivityID", "Name", userproject.ProjectActivityID);
            ViewBag.UserID = new SelectList(db.UserProfiles, "UserId", "UserName", userproject.UserID);
            return View(userproject);
        }

        //
        // GET: /UserProject/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UserProject userproject = db.UserProjects.Find(id);
            if (userproject == null)
            {
                return HttpNotFound();
            }
            return View(userproject);
        }

        //
        // POST: /UserProject/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProject userproject = db.UserProjects.Find(id);
            db.UserProjects.Remove(userproject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShowAllUsersHours()
        {
            var userprojects = db.UserProjects.Include(u => u.ProjectActivity).Include(u => u.UserProfile);
            return View(userprojects.ToList());
        }

        public ActionResult teste()
        {
            string username = "Carlos";

            var result = from up in db.UserProjects

                             join u in db.UserProfiles on up.UserID equals u.UserId

                             join p in db.ProjectActivities on up.ProjectActivityID equals p.ProjectActivityID

                             where u.UserName == username

                             group up by new {

                                 WeekNumber = SqlFunctions.DatePart("wk", up.Date),

                                 Username = u.UserName,

                                 Projectname = p.Name

                             } into g

                             let Total = g.Sum(x => x.TotalHours)

                             orderby Total descending

                             select new ReportByWeek(){

                                 UserName = g.Key.Username,

                                 ProjectName = g.Key.Projectname,

                                 DateNumber = g.Key.WeekNumber,

                                 TotalHour = Total

                             };

            return View(result.ToList());
        }

        public ActionResult HoursByProject()
        {

            var result = from up in db.UserProjects
                         join pr in db.ProjectActivities on up.ProjectActivityID equals pr.ProjectActivityID
                         group up by new
                         {
                             ProjectName = pr.Name,
                             ProjectType = pr.ProjectType.Description,
                             ProjectOwner = pr.UserProfile.UserName
                         } into g
                         let Total = g.Sum(x => x.TotalHours)
                         select new HoursByProject()
                         {
                             ProjectName = g.Key.ProjectName,
                             ProjectType = g.Key.ProjectType,
                             ProjectOwner = g.Key.ProjectOwner,
                             TotalHour = Total
                         };


            return View(result.ToList());
        }

        public ActionResult HoursByUser()
        {
            var result = from up in db.UserProjects
                         join upr in db.UserProfiles on up.UserID equals upr.UserId
                         group up by new
                         {
                             UserName = upr.UserName,
                         } into g
                         let Total = g.Sum(x => x.TotalHours)
                         select new HoursByUser()
                         {
                             UserName = g.Key.UserName,
                             TotalHour = Total
                         };
            return View(result.ToList());
        }

        public ActionResult DetailedHoursByUser(string userName)
        {
            var result = from up in db.UserProjects
                         join upr in db.UserProfiles on up.UserID equals upr.UserId
                         join pa in db.ProjectActivities on up.ProjectActivityID equals pa.ProjectActivityID
                         select new DetailedHoursByUser()
                         {
                             UserName = upr.UserName,
                             ProjectName = pa.Name,
                             Date = up.Date,
                             TotalHours = up.TotalHours
                         };
            return View(result.ToList());
        }
        

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}