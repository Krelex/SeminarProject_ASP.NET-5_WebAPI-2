using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeminarMVC.Controllers
{
    public class SeminariController : Controller
    {
        // GET: Seminari
        public ActionResult Index()
        {
            return View();
        }
    }
}