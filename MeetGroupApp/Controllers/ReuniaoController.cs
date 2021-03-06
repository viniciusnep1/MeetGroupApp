﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeetGroupApp.Models;
using MeetGroupApp.Services;

namespace MeetGroupApp.Controllers
{
    public class ReuniaoController : Controller
    {
        private MeetGroupAppContext db = new MeetGroupAppContext();
        private ReuniaoService service = new ReuniaoService();

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
        public ActionResult Create([Bind(Include = "Id,DataInicio,HoraInicio,DataFim,HoraFim,Internet,NumeroSala,Pessoas,Computador,Televisor")] Reuniao reuniao)
        {
            if (ModelState.IsValid)
            {
                if (reuniao.DataInicio.Equals(DateTime.Today))
                {
                    ModelState.AddModelError("DataInicio", "A reunião deve ser marcada com pelo menos 1 dia de antecedencia.");
                    return View(reuniao);
                }
                else if (reuniao.DataInicio.Subtract(DateTime.Today).TotalDays >= 40)
                {
                    ModelState.AddModelError("DataInicio", "A reunião deve ser marcada com no máximo 40 dias de antecedencia");
                    return View(reuniao);
                }
                else if (reuniao.DataInicio < DateTime.Today || reuniao.DataFim < reuniao.DataInicio)
                {
                    ModelState.AddModelError("DataInicio", "A reunião deve ser marcada com uma data válida");
                    return View(reuniao);
                }
                if ((reuniao.DataInicio.DayOfWeek == DayOfWeek.Saturday || reuniao.DataInicio.DayOfWeek == DayOfWeek.Sunday) ||
                        reuniao.DataFim.DayOfWeek == DayOfWeek.Saturday || reuniao.DataFim.DayOfWeek == DayOfWeek.Sunday)
                {
                    ModelState.AddModelError("DataInicio", "A reunião deve ser marcada em dias úteis");
                    return View(reuniao);
                }
                else
                if (reuniao.HoraFim.Subtract(reuniao.HoraInicio).TotalHours > 8)
                {
                    ModelState.AddModelError("DataInicio", "A reunião deve ter no máximo 8 horas de duração");
                    return View(reuniao);
                }

                reuniao = service.VerificacaoDeSala(reuniao);
                if (reuniao.NumeroSala == 0)
                {
                    ModelState.AddModelError("DataInicio", "Sala não encontrada, verifique a entrada dos dados e tente novamente");
                    return View(reuniao);
                }

                reuniao.Id = Guid.NewGuid();
                db.Reuniaos.Add(reuniao);
                db.SaveChanges();

                string path = @"C:\Users\Public\reuniao.txt";
                StreamWriter sw = new StreamWriter(path);

                sw.WriteLine("Reunião marcada para " + reuniao.DataInicio.GetDateTimeFormats('D').FirstOrDefault() + " e terminará " + reuniao.DataFim.Date.GetDateTimeFormats('D').FirstOrDefault() + ". \nA reunião vai começar as " + reuniao.HoraInicio + " e vai terminar as " + reuniao.HoraFim + " e será na sala número " + reuniao.NumeroSala);
                sw.Close();
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
