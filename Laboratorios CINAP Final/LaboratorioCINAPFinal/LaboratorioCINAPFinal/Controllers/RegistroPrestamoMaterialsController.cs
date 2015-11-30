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
    public class RegistroPrestamoMaterialsController : Controller
    {
        private LaboratoriosCINAPEntities db = new LaboratoriosCINAPEntities();

        // GET: RegistroPrestamoMaterials
        public ActionResult Index()
        {
            var registroPrestamoMaterials = db.RegistroPrestamoMaterials.Include(r => r.Grupo).Include(r => r.Material).Include(r => r.Persona);
            return View(registroPrestamoMaterials.ToList());
        }

        // GET: RegistroPrestamoMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroPrestamoMaterial registroPrestamoMaterial = db.RegistroPrestamoMaterials.Find(id);
            if (registroPrestamoMaterial == null)
            {
                return HttpNotFound();
            }
            return View(registroPrestamoMaterial);
        }

        // GET: RegistroPrestamoMaterials/Create
        public ActionResult Create()
        {
            ViewBag.ID_Grupo = new SelectList(db.Grupoes, "ID_Grupo", "Materia");
            ViewBag.ID_Material = new SelectList(db.Materials, "ID_Material", "CodigoSerie");
            ViewBag.ID_Persona = new SelectList(db.Personas, "ID_Persona", "ID_Persona");
            return View();
        }

        // POST: RegistroPrestamoMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_RegistroPrestamoMaterial,ID_Material,ID_Persona,ID_Grupo,Estado,EstadoDescripcionEntrega,EstadoDescripcionRecibido,EstadoFuncionalEntrega,EstadoFuncionalRecibido,FechaPrestamo,FechaRegreso")] RegistroPrestamoMaterial registroPrestamoMaterial)
        {
            if (ModelState.IsValid)
            {
                db.RegistroPrestamoMaterials.Add(registroPrestamoMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Grupo = new SelectList(db.Grupoes, "ID_Grupo", "Materia", registroPrestamoMaterial.ID_Grupo);
            ViewBag.ID_Material = new SelectList(db.Materials, "ID_Material", "CodigoSerie", registroPrestamoMaterial.ID_Material);
            ViewBag.ID_Persona = new SelectList(db.Personas, "ID_Persona", "ID_Persona", registroPrestamoMaterial.ID_Persona);
            return View(registroPrestamoMaterial);
        }

        // GET: RegistroPrestamoMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroPrestamoMaterial registroPrestamoMaterial = db.RegistroPrestamoMaterials.Find(id);
            if (registroPrestamoMaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Grupo = new SelectList(db.Grupoes, "ID_Grupo", "Materia", registroPrestamoMaterial.ID_Grupo);
            ViewBag.ID_Material = new SelectList(db.Materials, "ID_Material", "CodigoSerie", registroPrestamoMaterial.ID_Material);
            ViewBag.ID_Persona = new SelectList(db.Personas, "ID_Persona", "ID_Persona", registroPrestamoMaterial.ID_Persona);
            return View(registroPrestamoMaterial);
        }

        // POST: RegistroPrestamoMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_RegistroPrestamoMaterial,ID_Material,ID_Persona,ID_Grupo,Estado,EstadoDescripcionEntrega,EstadoDescripcionRecibido,EstadoFuncionalEntrega,EstadoFuncionalRecibido,FechaPrestamo,FechaRegreso")] RegistroPrestamoMaterial registroPrestamoMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroPrestamoMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Grupo = new SelectList(db.Grupoes, "ID_Grupo", "Materia", registroPrestamoMaterial.ID_Grupo);
            ViewBag.ID_Material = new SelectList(db.Materials, "ID_Material", "CodigoSerie", registroPrestamoMaterial.ID_Material);
            ViewBag.ID_Persona = new SelectList(db.Personas, "ID_Persona", "ID_Persona", registroPrestamoMaterial.ID_Persona);
            return View(registroPrestamoMaterial);
        }

        // GET: RegistroPrestamoMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroPrestamoMaterial registroPrestamoMaterial = db.RegistroPrestamoMaterials.Find(id);
            if (registroPrestamoMaterial == null)
            {
                return HttpNotFound();
            }
            return View(registroPrestamoMaterial);
        }

        // POST: RegistroPrestamoMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroPrestamoMaterial registroPrestamoMaterial = db.RegistroPrestamoMaterials.Find(id);
            db.RegistroPrestamoMaterials.Remove(registroPrestamoMaterial);
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
