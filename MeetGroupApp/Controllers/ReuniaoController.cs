using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeetGroupApp.Models;

namespace MeetGroupApp.Controllers
{
    public class ReuniaoController : Controller
    {
        private MeetGroupAppContext db = new MeetGroupAppContext();

        // GET: Reuniao
        public ActionResult Index()
        {
            return View(db.Reuniaos.ToList());
        }

        // GET: Reuniao/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reuniao reuniao = db.Reuniaos.Find(id);
            if (reuniao == null)
            {
                return HttpNotFound();
            }
            return View(reuniao);
        }

        // GET: Reuniao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reuniao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataInicio,HoraInicio,DataFim,HoraFim")] Reuniao reuniao)
        {
            if (!reuniao.DataInicio.Equals(DateTime.Today) || reuniao.DataInicio.Subtract(DateTime.Today).TotalDays <= 40)
            {


            }
            else
            if ((reuniao.DataInicio.DayOfWeek == DayOfWeek.Saturday || reuniao.DataInicio.DayOfWeek == DayOfWeek.Sunday) ||
                    reuniao.DataFim.DayOfWeek == DayOfWeek.Saturday || reuniao.DataFim.DayOfWeek == DayOfWeek.Sunday)
            {

            }
            else
            if (reuniao.HoraInicio.Subtract(reuniao.HoraFim).TotalHours > 8)
            {

            }
            if (ModelState.IsValid)
            {
                reuniao.Id = Guid.NewGuid();
                db.Reuniaos.Add(reuniao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reuniao);
        }

        // GET: Reuniao/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reuniao reuniao = db.Reuniaos.Find(id);
            if (reuniao == null)
            {
                return HttpNotFound();
            }
            return View(reuniao);
        }

        // POST: Reuniao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataInicio,HoraInicio,DataFim,HoraFim")] Reuniao reuniao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reuniao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reuniao);
        }

        // GET: Reuniao/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reuniao reuniao = db.Reuniaos.Find(id);
            if (reuniao == null)
            {
                return HttpNotFound();
            }
            return View(reuniao);
        }

        // POST: Reuniao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Reuniao reuniao = db.Reuniaos.Find(id);
            db.Reuniaos.Remove(reuniao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
