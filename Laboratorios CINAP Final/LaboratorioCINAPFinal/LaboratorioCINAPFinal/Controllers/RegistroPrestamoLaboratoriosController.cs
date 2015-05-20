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
    public class RegistroPrestamoLaboratoriosController : Controller
    {
        private LaboratoriosCINAPEntities db = new LaboratoriosCINAPEntities();

        // GET: RegistroPrestamoLaboratorios
        public ActionResult Index()
        {
            var registroPrestamoLaboratorios = db.RegistroPrestamoLaboratorios.Include(r => r.Grupo).Include(r => r.Laboratorio).Include(r => r.Maestro);
            return View(registroPrestamoLaboratorios.ToList());
        }

        // GET: RegistroPrestamoLaboratorios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroPrestamoLaboratorio registroPrestamoLaboratorio = db.RegistroPrestamoLaboratorios.Find(id);
            if (registroPrestamoLaboratorio == null)
            {
                return HttpNotFound();
            }
            return View(registroPrestamoLaboratorio);
        }

        // GET: RegistroPrestamoLaboratorios/Create
        public ActionResult Create()
        {
            ViewBag.ID_Grupo = new SelectList(db.Grupoes, "ID_Grupo", "Materia");
            ViewBag.ID_Laboratorio = new SelectList(db.Laboratorios, "ID_Laboratorio", "Nombre");
            ViewBag.ID_Maestro = new SelectList(db.Maestroes, "ID_Maestro", "Nombre");
            return View();
        }

        // POST: RegistroPrestamoLaboratorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_RegistroPrestamoLaboratorio,ID_Laboratorio,ID_Maestro,ID_Grupo,FechaEntrada,FechaSalida,Asistencia")] RegistroPrestamoLaboratorio registroPrestamoLaboratorio)
        {
            if (ModelState.IsValid)
            {
                db.RegistroPrestamoLaboratorios.Add(registroPrestamoLaboratorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Grupo = new SelectList(db.Grupoes, "ID_Grupo", "Materia", registroPrestamoLaboratorio.ID_Grupo);
            ViewBag.ID_Laboratorio = new SelectList(db.Laboratorios, "ID_Laboratorio", "Nombre", registroPrestamoLaboratorio.ID_Laboratorio);
            ViewBag.ID_Maestro = new SelectList(db.Maestroes, "ID_Maestro", "Nombre", registroPrestamoLaboratorio.ID_Maestro);
            return View(registroPrestamoLaboratorio);
        }

        // GET: RegistroPrestamoLaboratorios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroPrestamoLaboratorio registroPrestamoLaboratorio = db.RegistroPrestamoLaboratorios.Find(id);
            if (registroPrestamoLaboratorio == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Grupo = new SelectList(db.Grupoes, "ID_Grupo", "Materia", registroPrestamoLaboratorio.ID_Grupo);
            ViewBag.ID_Laboratorio = new SelectList(db.Laboratorios, "ID_Laboratorio", "Nombre", registroPrestamoLaboratorio.ID_Laboratorio);
            ViewBag.ID_Maestro = new SelectList(db.Maestroes, "ID_Maestro", "Nombre", registroPrestamoLaboratorio.ID_Maestro);
            return View(registroPrestamoLaboratorio);
        }

        // POST: RegistroPrestamoLaboratorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_RegistroPrestamoLaboratorio,ID_Laboratorio,ID_Maestro,ID_Grupo,FechaEntrada,FechaSalida,Asistencia")] RegistroPrestamoLaboratorio registroPrestamoLaboratorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroPrestamoLaboratorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Grupo = new SelectList(db.Grupoes, "ID_Grupo", "Materia", registroPrestamoLaboratorio.ID_Grupo);
            ViewBag.ID_Laboratorio = new SelectList(db.Laboratorios, "ID_Laboratorio", "Nombre", registroPrestamoLaboratorio.ID_Laboratorio);
            ViewBag.ID_Maestro = new SelectList(db.Maestroes, "ID_Maestro", "Nombre", registroPrestamoLaboratorio.ID_Maestro);
            return View(registroPrestamoLaboratorio);
        }

        // GET: RegistroPrestamoLaboratorios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroPrestamoLaboratorio registroPrestamoLaboratorio = db.RegistroPrestamoLaboratorios.Find(id);
            if (registroPrestamoLaboratorio == null)
            {
                return HttpNotFound();
            }
            return View(registroPrestamoLaboratorio);
        }

        // POST: RegistroPrestamoLaboratorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroPrestamoLaboratorio registroPrestamoLaboratorio = db.RegistroPrestamoLaboratorios.Find(id);
            db.RegistroPrestamoLaboratorios.Remove(registroPrestamoLaboratorio);
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
