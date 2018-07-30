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
    public class PredbiljezbeController : Controller
    {
        PredbiljezbaREST service = new PredbiljezbaREST();
        SeminarREST serviceSeminar = new SeminarREST();

        public int pageSize = 5;


        // GET: Predbiljezbe
        public async Task<ActionResult> Index(int? active , int page = 1)
        {
            PredbiljezbaViewModel model = new PredbiljezbaViewModel();

            if (active == 0)
            {
                ViewBag.Active = "nonactive";
                var all = await service.GetAllAsync();
                var chekMe = all.Where(p => p.Active == false).OrderByDescending(p => p.Datum).Skip((page - 1) * pageSize).Take(pageSize);

                model.predbiljezba = chekMe;

                model.pagingInfo = new PagingInfo()
                {
                    TotalItems = all.Where(i => i.Active == false).Count(),
                    ItemPerPage = pageSize,
                    CurrentPage = page
                };

                return View(model);
            }

            else if (active == 1)
            {
                ViewBag.Active = "active";
                var all = await service.GetAllAsync();
                var checkMe = all.Where(p => p.Active == true).OrderByDescending(p => p.Datum).Skip((page - 1) * pageSize).Take(pageSize);

                model.predbiljezba = checkMe;

                model.pagingInfo = new PagingInfo()
                {
                    TotalItems = all.Where(i => i.Active == true).Count(),
                    ItemPerPage = pageSize,
                    CurrentPage = page
                };

                return View(model);
            }
            else
            {
                ViewBag.Active = "all";
                var all = await service.GetAllAsync();
                var checkMe = all.OrderByDescending(p => p.Datum).Skip((page - 1) * pageSize).Take(pageSize);


                model.predbiljezba = checkMe;

                model.pagingInfo = new PagingInfo()
                {
                    TotalItems = all.Count(),
                    ItemPerPage = pageSize,
                    CurrentPage = page
                };

                return View(model);
            }
        }

        public async Task<ActionResult> Search(string key)
        {
            PredbiljezbaViewModel model = new PredbiljezbaViewModel();


            var all = await service.GetAllAsync();
            var found = all.Where(p => p.Email.Contains(key)).ToList();

            if (found.Count() == 0)
            {
                throw new ArgumentException("Nažalost unjeli ste netočne podatke :( ");
            }

            ViewBag.Key = key;
            model.predbiljezba = found;

            return View("Index", model);

        }

        public async Task<ActionResult> Edit(int id)
        {
            var item = await service.GetByIdAsync(id);
            var seminari = await serviceSeminar.GetAllAsync();

            List<SelectListItem> listaItema = new List<SelectListItem>();

            foreach (var semi in seminari)
            {
                SelectListItem li = new SelectListItem();
                li.Text = semi.Naziv;
                li.Value = semi.IdSeminar.ToString();
                listaItema.Add(li);
            }

            SelectList lista = new SelectList(listaItema , "Value" , "Text");
            
            ViewBag.lista = lista;

            return View(item);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Predbiljezba predbiljezba)
        {
            if (ModelState.IsValid)
            {
                await service.PutAsync(predbiljezba);
                TempData["EditP"] = predbiljezba.Email ;
                return RedirectToAction("Index");
            }

            return View(predbiljezba);
        }
    }
}