using SeminarMVC.Models.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SeminarMVC.Controllers
{
    [Authorize]
    public class PredbiljezbeController : Controller
    {
        PredbiljezbaREST service = new PredbiljezbaREST();

        // GET: Predbiljezbe
        public async Task<ActionResult> Index(int? active)
        {
            if(active == 0)
            {
                ViewBag.Active = "nonactive";
                var all = await service.GetAllAsync();
                var chekMe = all.Where(p => p.Active == false).OrderByDescending(p => p.Datum);
                return View(chekMe);

            }
            else if (active == 1)
            {
                ViewBag.Active = "active";
                var all = await service.GetAllAsync();
                var checkMe = all.Where(p => p.Active == true).OrderByDescending(p => p.Datum);
                return View(checkMe);
            }
            else
            {
                ViewBag.Active = "all";
                var all = await service.GetAllAsync();

                return View(all.OrderByDescending(p => p.Datum));
            }

        }
    }
}