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
    public class salidaEmpleadoesController : Controller
    {
        private pro3Entities db = new pro3Entities();

        // GET: salidaEmpleadoes
        public ActionResult Index()
        {
            var salidaEmpleado = db.salidaEmpleado.Include(s => s.empleados);
            return View(salidaEmpleado.ToList());
        }

        // GET: salidaEmpleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salidaEmpleado salidaEmpleado = db.salidaEmpleado.Find(id);
            if (salidaEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmpleado);
        }

        // GET: salidaEmpleadoes/Create
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.empleados, "id", "codigoEmpleado");
            return View();
        }

        // POST: salidaEmpleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_salida,tipoSalida,motivo,fechaSalida,id_empleado")] salidaEmpleado salidaEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.salidaEmpleado.Add(salidaEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.empleados, "id", "codigoEmpleado", salidaEmpleado.id_empleado);
            return View(salidaEmpleado);
        }

        // GET: salidaEmpleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salidaEmpleado salidaEmpleado = db.salidaEmpleado.Find(id);
            if (salidaEmpleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_empleado = new SelectList(db.empleados, "id", "codigoEmpleado", salidaEmpleado.id_empleado);
            return View(salidaEmpleado);
        }

        // POST: salidaEmpleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_salida,tipoSalida,motivo,fechaSalida,id_empleado")] salidaEmpleado salidaEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salidaEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.empleados, "id", "codigoEmpleado", salidaEmpleado.id_empleado);
            return View(salidaEmpleado);
        }

        // GET: salidaEmpleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salidaEmpleado salidaEmpleado = db.salidaEmpleado.Find(id);
            if (salidaEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmpleado);
        }

        // POST: salidaEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            salidaEmpleado salidaEmpleado = db.salidaEmpleado.Find(id);
            db.salidaEmpleado.Remove(salidaEmpleado);
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
