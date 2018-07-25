using SeminarMVC.Models;
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
    public class SeminariController : Controller
    {

        SeminarREST serviceSeminar = new SeminarREST();

        // GET: Seminari
        public async Task<ActionResult> Index()
        {
            var all = await serviceSeminar.GetAllAsync();

            return View(all);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Edit(Seminar seminar)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Seminar seminar )
        {
            if (ModelState.IsValid)
            {
                await serviceSeminar.CreateAsync(seminar);

                TempData["Seminar"] = seminar.Naziv;

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return View();
        }


    }
}