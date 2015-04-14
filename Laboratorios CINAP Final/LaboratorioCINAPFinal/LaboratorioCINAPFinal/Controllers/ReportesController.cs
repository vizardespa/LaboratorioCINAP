using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaboratorioCINAPFinal.Models;

namespace LaboratorioCINAPFinal.Controllers
{
    public class ReportesController : Controller
    {
        private LaboratoriosCINAPEntities db = new LaboratoriosCINAPEntities();

        // GET: Reportes
        public ActionResult Index()
        {
            var reportes = db.Reportes.Include(r => r.TipoReporte);
            return View(reportes.ToList());
        }

        // GET: Reportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = db.Reportes.Find(id);
            Carrera carrera = db.Carreras.Find(1);
            if (reporte == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdCarrera = new SelectList(db.Carreras, "ID_Carrera", "Nombre", carrera.ID_Carrera);
            ViewBag.IdTipoReporte = new SelectList(db.TipoReportes, "IdTipoReporte", "Nombre", reporte.IdTipoReporte);
            return View(reporte);
        }

        // GET: Reportes/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoReporte = new SelectList(db.TipoReportes, "IdTipoReporte", "Nombre");
            return View();
        }

        // POST: Reportes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Reporte,Nombre,FechaInicioPeriodo,FechaTerminacionPeriodo,IdTipoReporte,Temporal")] Reporte reporte)
        {
            if (ModelState.IsValid)
            {
                db.Reportes.Add(reporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoReporte = new SelectList(db.TipoReportes, "IdTipoReporte", "Nombre", reporte.IdTipoReporte);
            return View(reporte);
        }

        // GET: Reportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = db.Reportes.Find(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoReporte = new SelectList(db.TipoReportes, "IdTipoReporte", "Nombre", reporte.IdTipoReporte);
            return View(reporte);
        }

        // POST: Reportes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Reporte,Nombre,FechaInicioPeriodo,FechaTerminacionPeriodo,IdTipoReporte,Temporal")] Reporte reporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoReporte = new SelectList(db.TipoReportes, "IdTipoReporte", "Nombre", reporte.IdTipoReporte);
            return View(reporte);
        }

        // GET: Reportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = db.Reportes.Find(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }
            return View(reporte);
        }

        // POST: Reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reporte reporte = db.Reportes.Find(id);
            db.Reportes.Remove(reporte);
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
