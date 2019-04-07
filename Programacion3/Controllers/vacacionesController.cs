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
    public class vacacionesController : Controller
    {
        private pro3Entities db = new pro3Entities();

        // GET: vacaciones
        public ActionResult Index()
        {
            var vacaciones = db.vacaciones.Include(v => v.empleados);
            return View(vacaciones.ToList());
        }

        // GET: vacaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacaciones vacaciones = db.vacaciones.Find(id);
            if (vacaciones == null)
            {
                return HttpNotFound();
            }
            return View(vacaciones);
        }

        // GET: vacaciones/Create
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.empleados, "id", "codigoEmpleado");
            return View();
        }

        // POST: vacaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_vacaciones,desde,hasta,año,comentario,id_empleado")] vacaciones vacaciones)
        {
            if (ModelState.IsValid)
            {
                db.vacaciones.Add(vacaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.empleados, "id", "codigoEmpleado", vacaciones.id_empleado);
            return View(vacaciones);
        }

        // GET: vacaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacaciones vacaciones = db.vacaciones.Find(id);
            if (vacaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_empleado = new SelectList(db.empleados, "id", "codigoEmpleado", vacaciones.id_empleado);
            return View(vacaciones);
        }

        // POST: vacaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_vacaciones,desde,hasta,año,comentario,id_empleado")] vacaciones vacaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.empleados, "id", "codigoEmpleado", vacaciones.id_empleado);
            return View(vacaciones);
        }

        // GET: vacaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacaciones vacaciones = db.vacaciones.Find(id);
            if (vacaciones == null)
            {
                return HttpNotFound();
            }
            return View(vacaciones);
        }

        // POST: vacaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vacaciones vacaciones = db.vacaciones.Find(id);
            db.vacaciones.Remove(vacaciones);
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
