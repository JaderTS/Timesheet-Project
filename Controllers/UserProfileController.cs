using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using TrabalhoFinal.Filters;
using TrabalhoFinal.Models;
namespace TrabalhoFinal.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class UserProfileController : Controller
    {
        private DataModelContext db = new DataModelContext();
        //
        // GET: /UserProfile/

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.UserProfiles.ToList());
        }

    }
}
