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
        int pageSize = 5;

        // GET: Seminari
        public async Task<ActionResult> Index(int page = 1)
        {
            SeminarViewModel model = new SeminarViewModel();

            var all = await serviceSeminar.GetAllAsync();
            var checkMe = all.OrderByDescending(p => p.Datum).Skip((page - 1) * pageSize).Take(pageSize);
            model.seminar = checkMe;

            model.pagingInfo = new PagingInfo()
            {
                TotalItems = all.Count(),
                ItemPerPage = pageSize,
                CurrentPage = page
            };

            return View(model);
        }

        public async Task<ActionResult> Search(string key)
        {
            SeminarViewModel model = new SeminarViewModel();
            var found = await serviceSeminar.SearchAsync(key);

            if (found.Count() == 0)
            {
                throw new ArgumentException("Nažalost unjeli ste netočne podatke :( ");
            }
            @ViewBag.Key = key;
            model.seminar = found;

            return View("Index", model);

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
        public async  Task<ActionResult> Delete(int id, string naziv)
        {
            var rezult = await serviceSeminar.DeleteAsync(id);

            TempData["Delete"] = naziv;

            return RedirectToAction("Index");
        }


    }
}