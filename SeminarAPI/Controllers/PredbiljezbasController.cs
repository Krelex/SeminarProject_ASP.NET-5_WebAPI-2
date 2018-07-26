using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SeminarAPI.Models;

namespace SeminarAPI.Controllers
{
    public class PredbiljezbasController : ApiController
    {
        private SeminarContexDb db = new SeminarContexDb();

        // GET: api/Predbiljezbas
        [HttpGet]
        public List<Predbiljezba> GetPredbiljezbas()
        {
            var all = db.Predbiljezbas.Include("Seminar").ToList();
            return all;
        }

        // GET: api/Predbiljezbas/5
        [ResponseType(typeof(Predbiljezba))]
        public IHttpActionResult GetPredbiljezba(int id)
        {
            Predbiljezba predbiljezba = db.Predbiljezbas.Find(id);
            if (predbiljezba == null)
            {
                return NotFound();
            }

            return Ok(predbiljezba);
        }

        // PUT: api/Predbiljezbas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPredbiljezba(int id, Predbiljezba predbiljezba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != predbiljezba.IdPredbiljezba)
            {
                return BadRequest();
            }

            db.Entry(predbiljezba).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredbiljezbaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Predbiljezbas
        [ResponseType(typeof(Predbiljezba))]
        public IHttpActionResult PostPredbiljezba(Predbiljezba predbiljezba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Predbiljezbas.Add(predbiljezba);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = predbiljezba.IdPredbiljezba }, predbiljezba);
        }

        // DELETE: api/Predbiljezbas/5
        [ResponseType(typeof(Predbiljezba))]
        public IHttpActionResult DeletePredbiljezba(int id)
        {
            Predbiljezba predbiljezba = db.Predbiljezbas.Find(id);
            if (predbiljezba == null)
            {
                return NotFound();
            }

            db.Predbiljezbas.Remove(predbiljezba);
            db.SaveChanges();

            return Ok(predbiljezba);
        }

        [ResponseType(typeof(int))]
        [Route("~/api/Predbiljezbas/{Id}/PolaznikaCount")]
        [HttpGet]
        public IHttpActionResult BrojPolaznika(int id)
        {
            int broj = db.Database.SqlQuery<int>("SELECT COUNT (IdSeminar) FROM Predbiljezba WHERE IdSeminar =" + id).SingleOrDefault();    

            return Ok(broj);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PredbiljezbaExists(int id)
        {
            return db.Predbiljezbas.Count(e => e.IdPredbiljezba == id) > 0;
        }
    }
}