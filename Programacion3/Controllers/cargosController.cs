using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Programacion3.Models;

namespace Programacion3.Controllers
{
    public class cargosController : Controller
    {
        private pro3Entities db = new pro3Entities();

        // GET: cargos
        public ActionResult Index()
        {
            return View(db.cargos.ToList());
        }

        // GET: cargos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cargos cargos = db.cargos.Find(id);
            if (cargos == null)
            {
                return HttpNotFound();
            }
            return View(cargos);
        }

        // GET: cargos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cargos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cargos,codigoCargo,cargo")] cargos cargos)
        {
            if (ModelState.IsValid)
            {
                db.cargos.Add(cargos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargos);
        }

        // GET: cargos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cargos cargos = db.cargos.Find(id);
            if (cargos == null)
            {
                return HttpNotFound();
            }
            return View(cargos);
        }

        // POST: cargos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cargos,codigoCargo,cargo")] cargos cargos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargos);
        }

        // GET: cargos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cargos cargos = db.cargos.Find(id);
            if (cargos == null)
            {
                return HttpNotFound();
            }
            return View(cargos);
        }

        // POST: cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cargos cargos = db.cargos.Find(id);
            db.cargos.Remove(cargos);
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
