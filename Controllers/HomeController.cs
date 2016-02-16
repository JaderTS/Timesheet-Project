using System;
using System.Collections.Generic;
using System.Linq;
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
    public class HomeController : Controller
    {
        [Authorize(Roles = "Admin,Funcionario")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
