using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaboratorioCINAP;

namespace LaboratorioCINAP.Controllers
{
    public class MaterialsController : Controller
    {
        private LaboratorioContext db = new LaboratorioContext();

        // GET: Materials
        public ActionResult Index()
        {
            var material = db.Material.Include(m => m.TipoMaterial);
            return View(material.ToList());
        }

        // GET: Materials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // GET: Materials/Create
        public ActionResult Create()
        {
            ViewBag.ID_TipoMaterial = new SelectList(db.TipoMaterial, "ID_TipoMaterial", "Nombre");
            return View();
        }

        // POST: Materials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Material,CodigoSerie,Disponibilidad,ID_TipoMaterial,EstadoFuncional,EstadoDescripcion,Activo")] Material material)
        {
            if (ModelState.IsValid)
            {
                db.Material.Add(material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_TipoMaterial = new SelectList(db.TipoMaterial, "ID_TipoMaterial", "Nombre", material.ID_TipoMaterial);
            return View(material);
        }

        // GET: Materials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TipoMaterial = new SelectList(db.TipoMaterial, "ID_TipoMaterial", "Nombre", material.ID_TipoMaterial);
            return View(material);
        }

        // POST: Materials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Material,CodigoSerie,Disponibilidad,ID_TipoMaterial,EstadoFuncional,EstadoDescripcion,Activo")] Material material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_TipoMaterial = new SelectList(db.TipoMaterial, "ID_TipoMaterial", "Nombre", material.ID_TipoMaterial);
            return View(material);
        }

        // GET: Materials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Material material = db.Material.Find(id);
            db.Material.Remove(material);
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
