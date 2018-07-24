using SeminarMVC.Models.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SeminarMVC.Controllers
{
    public class UpisiController : Controller
    {
        SeminarREST client = new SeminarREST();

        // GET: Upisi
        public async Task<ActionResult> Index()
        {
            var allSeminars =await client.GetAllAsync();

            return View(allSeminars);
        }
    }
}