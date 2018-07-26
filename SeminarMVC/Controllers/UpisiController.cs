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
    public class UpisiController : Controller
    {
        SeminarREST clientSeminar = new SeminarREST();
        PredbiljezbaREST clientPredbiljezba = new PredbiljezbaREST();

        // GET: Upisi
        public async Task<ActionResult> Index()
        {
            var allSeminars =await clientSeminar.GetAllAsync();

            var notPopunjen = allSeminars.Where(s => s.Popunjen == false).ToList();

            return View(notPopunjen);
        }

        public async Task<ActionResult> Korisnika(int id, string name)
        {
            ViewBag.SeminarId = id;
            ViewBag.Name = name;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Korisnika(Predbiljezba predbiljezba)
        {
            predbiljezba.Active = false;

            predbiljezba.Datum = DateTime.Now;

            var SeminarId =int.Parse(Request.Form["IdSeminar"]);
            predbiljezba.IdSeminar = SeminarId;




            if (ModelState.IsValid)
            {
                await clientPredbiljezba.CreateAsync(predbiljezba);
                var seminari = await clientSeminar.GetByIdAsync(SeminarId);

                var check = seminari.PopunjenCheck();

                TempData["Sucess"] = seminari.Naziv;
                TempData["Naziv"] = predbiljezba.Ime;

                return RedirectToAction("Index");
            }
            ViewBag.Error = "Desila se pogreska, molimo vas pokusajte ponovo !";
            return View();
        }
    }
}