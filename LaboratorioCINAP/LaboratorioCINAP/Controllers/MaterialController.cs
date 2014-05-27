using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaboratorioCINAP.Models;

namespace LaboratorioCINAP.Controllers
{
    public class MaterialController : Controller
    {
        private LaboratoriosCINAPEntities db = new LaboratoriosCINAPEntities();

        //
        // GET: /Material/

        public ActionResult Index()
        {
            var material = db.Material.Include(m => m.TipoMaterial);
            return View(material.ToList());
        }

        //
        // GET: /Material/Details/5

        public ActionResult Details(int id = 0)
        {
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        //
        // GET: /Material/Create

        public ActionResult Create()
        {
            ViewBag.ID_TipoMaterial = new SelectList(db.TipoMaterial, "ID_TipoMaterial", "Nombre");
            return View();
        }

        //
        // POST: /Material/Create

        [HttpPost]
        public ActionResult Create(Material material)
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

        //
        // GET: /Material/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TipoMaterial = new SelectList(db.TipoMaterial, "ID_TipoMaterial", "Nombre", material.ID_TipoMaterial);
            return View(material);
        }

        //
        // POST: /Material/Edit/5

        [HttpPost]
        public ActionResult Edit(Material material)
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

        //
        // GET: /Material/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        //
        // POST: /Material/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Material material = db.Material.Find(id);
            db.Material.Remove(material);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}