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
    public class ZaposleniksController : ApiController
    {
        private SeminarContexDb db = new SeminarContexDb();

        // GET: api/Zaposleniks
        public IQueryable<Zaposlenik> GetZaposleniks()
        {
            return db.Zaposleniks;
        }

        // GET: api/Zaposleniks/5
        [ResponseType(typeof(Zaposlenik))]
        public IHttpActionResult GetZaposlenik(int id)
        {
            Zaposlenik zaposlenik = db.Zaposleniks.Find(id);
            if (zaposlenik == null)
            {
                return NotFound();
            }

            return Ok(zaposlenik);
        }

        // PUT: api/Zaposleniks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZaposlenik(int id, Zaposlenik zaposlenik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zaposlenik.IdZaposlenik)
            {
                return BadRequest();
            }

            db.Entry(zaposlenik).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZaposlenikExists(id))
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

        // POST: api/Zaposleniks
        [ResponseType(typeof(Zaposlenik))]
        public IHttpActionResult PostZaposlenik(Zaposlenik zaposlenik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zaposleniks.Add(zaposlenik);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = zaposlenik.IdZaposlenik }, zaposlenik);
        }

        // DELETE: api/Zaposleniks/5
        [ResponseType(typeof(Zaposlenik))]
        public IHttpActionResult DeleteZaposlenik(int id)
        {
            Zaposlenik zaposlenik = db.Zaposleniks.Find(id);
            if (zaposlenik == null)
            {
                return NotFound();
            }

            db.Zaposleniks.Remove(zaposlenik);
            db.SaveChanges();

            return Ok(zaposlenik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZaposlenikExists(int id)
        {
            return db.Zaposleniks.Count(e => e.IdZaposlenik == id) > 0;
        }
    }
}