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
    public class licenciasController : Controller
    {
        private pro3Entities db = new pro3Entities();

        // GET: licencias
        public ActionResult Index()
        {
            var licencias = db.licencias.Include(l => l.empleados);
            return View(licencias.ToList());
        }

        // GET: licencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            licencias licencias = db.licencias.Find(id);
            if (licencias == null)
            {
                return HttpNotFound();
            }
            return View(licencias);
        }

        // GET: licencias/Create
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.empleados, "id", "codigoEmpleado");
            return View();
        }

        // POST: licencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_licencia,desde,hasta,motivo,comentarios,id_empleado")] licencias licencias)
        {
            if (ModelState.IsValid)
            {
                db.licencias.Add(licencias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.empleados, "id", "codigoEmpleado", licencias.id_empleado);
            return View(licencias);
        }

        // GET: licencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            licencias licencias = db.licencias.Find(id);
            if (licencias == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_empleado = new SelectList(db.empleados, "id", "codigoEmpleado", licencias.id_empleado);
            return View(licencias);
        }

        // POST: licencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_licencia,desde,hasta,motivo,comentarios,id_empleado")] licencias licencias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licencias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.empleados, "id", "codigoEmpleado", licencias.id_empleado);
            return View(licencias);
        }

        // GET: licencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            licencias licencias = db.licencias.Find(id);
            if (licencias == null)
            {
                return HttpNotFound();
            }
            return View(licencias);
        }

        // POST: licencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            licencias licencias = db.licencias.Find(id);
            db.licencias.Remove(licencias);
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
