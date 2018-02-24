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
using MeetGroupApp.Models;

namespace MeetGroupApp.Controllers
{
    public class SalasController : ApiController
    {
        private MeetGroupAppContext db = new MeetGroupAppContext();

        // GET: api/Salas
        public IQueryable<Sala> GetSalas()
        {
            return db.Salas;
        }

        // GET: api/Salas/5
        [ResponseType(typeof(Sala))]
        public IHttpActionResult GetSala(Guid id)
        {
            Sala sala = db.Salas.Find(id);
            if (sala == null)
            {
                return NotFound();
            }

            return Ok(sala);
        }

        // PUT: api/Salas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSala(Guid id, Sala sala)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sala.Id)
            {
                return BadRequest();
            }

            db.Entry(sala).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaExists(id))
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

        // POST: api/Salas
        [ResponseType(typeof(Sala))]
        public IHttpActionResult PostSala(Sala sala)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Salas.Add(sala);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SalaExists(sala.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sala.Id }, sala);
        }

        // DELETE: api/Salas/5
        [ResponseType(typeof(Sala))]
        public IHttpActionResult DeleteSala(Guid id)
        {
            Sala sala = db.Salas.Find(id);
            if (sala == null)
            {
                return NotFound();
            }

            db.Salas.Remove(sala);
            db.SaveChanges();

            return Ok(sala);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalaExists(Guid id)
        {
            return db.Salas.Count(e => e.Id == id) > 0;
        }
    }
}