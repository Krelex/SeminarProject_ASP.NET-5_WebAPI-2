﻿using SeminarMVC.Models;
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
                
                TempData["EditP"] = await service.PutAsync(predbiljezba); ;
                return RedirectToAction("Index");
            }

            return View(predbiljezba);
        }
    }
}