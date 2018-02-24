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
    public class ReunioesController : ApiController
    {
        private MeetGroupAppContext db = new MeetGroupAppContext();

        // GET: api/Reunioes
        public IQueryable<Reuniao> GetReuniaos()
        {
            return db.Reuniaos;
        }

        // GET: api/Reunioes/5
        [ResponseType(typeof(Reuniao))]
        public IHttpActionResult GetReuniao(Guid id)
        {
            Reuniao reuniao = db.Reuniaos.Find(id);
            if (reuniao == null)
            {
                return NotFound();
            }

            return Ok(reuniao);
        }

        // PUT: api/Reunioes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReuniao(Guid id, Reuniao reuniao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reuniao.Id)
            {
                return BadRequest();
            }

            db.Entry(reuniao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReuniaoExists(id))
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

        // POST: api/Reunioes
        [ResponseType(typeof(Reuniao))]
        public IHttpActionResult PostReuniao(Reuniao reuniao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reuniaos.Add(reuniao);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ReuniaoExists(reuniao.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("DefaultApi", new { id = reuniao.Id }, reuniao);
        }

        // DELETE: api/Reunioes/5
        [ResponseType(typeof(Reuniao))]
        public IHttpActionResult DeleteReuniao(Guid id)
        {
            Reuniao reuniao = db.Reuniaos.Find(id);
            if (reuniao == null)
            {
                return NotFound();
            }

            db.Reuniaos.Remove(reuniao);
            db.SaveChanges();

            return Ok(reuniao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReuniaoExists(Guid id)
        {
            return db.Reuniaos.Count(e => e.Id == id) > 0;
        }
    }
}