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
    public class entradaEmpleadosController : Controller
    {
        private pro3Entities db = new pro3Entities();

        // GET: entradaEmpleados
        public ActionResult Index()
        {
            var entradaEmpleados = db.entradaEmpleados.Include(e => e.empleados);
            return View(entradaEmpleados.ToList());
        }

        // GET: entradaEmpleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entradaEmpleados entradaEmpleados = db.entradaEmpleados.Find(id);
            if (entradaEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(entradaEmpleados);
        }

        // GET: entradaEmpleados/Create
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.empleados, "id", "codigoEmpleado");
            return View();
        }

        // POST: entradaEmpleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_entrada,mes,id_empleado")] entradaEmpleados entradaEmpleados)
        {
            if (ModelState.IsValid)
            {
                db.entradaEmpleados.Add(entradaEmpleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.empleados, "id", "codigoEmpleado", entradaEmpleados.id_empleado);
            return View(entradaEmpleados);
        }

        // GET: entradaEmpleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entradaEmpleados entradaEmpleados = db.entradaEmpleados.Find(id);
            if (entradaEmpleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_empleado = new SelectList(db.empleados, "id", "codigoEmpleado", entradaEmpleados.id_empleado);
            return View(entradaEmpleados);
        }

        // POST: entradaEmpleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_entrada,mes,id_empleado")] entradaEmpleados entradaEmpleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entradaEmpleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.empleados, "id", "codigoEmpleado", entradaEmpleados.id_empleado);
            return View(entradaEmpleados);
        }

        // GET: entradaEmpleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entradaEmpleados entradaEmpleados = db.entradaEmpleados.Find(id);
            if (entradaEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(entradaEmpleados);
        }

        // POST: entradaEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            entradaEmpleados entradaEmpleados = db.entradaEmpleados.Find(id);
            db.entradaEmpleados.Remove(entradaEmpleados);
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
