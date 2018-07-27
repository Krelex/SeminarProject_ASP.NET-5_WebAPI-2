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
    [HandleError]
    public class SeminariController : Controller
    {

        SeminarREST serviceSeminar = new SeminarREST();

        // GET: Seminari
        public async Task<ActionResult> Index()
        {
            var all = await serviceSeminar.GetAllAsync();

            return View(all);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var seminar = await serviceSeminar.GetByIdAsync(id);

            return View(seminar);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                if (int.Parse(seminar.Broj()) >= 5)
                {
                    seminar.Popunjen = true;
                }

                var respone = await serviceSeminar.PutAsync(seminar);

                if(respone.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    TempData["Edit"] = seminar.Naziv;
                }else
                {
                    TempData["StatusCode"] = "Dogodila se pogreska prilikom spremanja molimo vas pokusajte ponovo! ["+respone.StatusCode+"]";
                }

                return RedirectToAction("Index");
            }

            return View(seminar);
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

        [HttpGet]
        public ActionResult Delete(int id, string naziv)
        {
            serviceSeminar.DeleteAsync(id);

            TempData["Delete"] = naziv;

            return RedirectToAction("Index");
        }


    }
}