using SeminarAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SeminarAPI.Controllers
{
    public class SeminarController : ApiController
    {
        SeminarContexDb db = new SeminarContexDb();

        // GET: api/Seminar
        public IEnumerable<Seminar> Get()
        {
            List<Seminar> all = db.Seminars.ToList();

            return all;
        }

        // GET: api/Seminar/5
        [ResponseType(typeof(Seminar))]
        public IHttpActionResult Get(int id)
        {

            Seminar seminar = db.Seminars.Find(id);

            if(seminar == null)
            {
                return NotFound();
            }

            return Ok(seminar);
        }

        // POST: api/Seminar
        [ResponseType(typeof(Seminar))]
        public IHttpActionResult Post(Seminar seminar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Seminars.Add(seminar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = seminar.IdSeminar }, seminar);
        }

        // PUT: api/Seminar/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put([FromBody]Seminar seminar)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            db.Entry(seminar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeminarExists(seminar.IdSeminar))
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

        // DELETE: api/Seminar/5
        [ResponseType(typeof(Seminar))]
        public IHttpActionResult Delete(int id)
        {
            Seminar seminar = db.Seminars.Find(id);
            if (seminar == null)
            {
                return NotFound();
            }

            db.Seminars.Remove(seminar);
            db.SaveChanges();

            return Ok(seminar);
        }

        private bool SeminarExists(int id)
        {
            return db.Seminars.Count(e => e.IdSeminar == id) > 0;
        }
    }
}
