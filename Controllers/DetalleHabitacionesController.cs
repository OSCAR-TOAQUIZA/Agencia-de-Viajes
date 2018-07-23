using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pry_Agencia_Viajes;

namespace Pry_Agencia_Viajes.Controllers
{
    public class DetalleHabitacionesController : Controller
    {
        private Agencia_de_Viajes_CertificacionEntities db = new Agencia_de_Viajes_CertificacionEntities();

        // GET: DetalleHabitaciones
        public ActionResult Index()
        {
            var detalle_Habitacion = db.Detalle_Habitacion.Include(d => d.Habitacion).Include(d => d.Hotel);
            return View(detalle_Habitacion.ToList());
        }

        // GET: DetalleHabitaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Habitacion detalle_Habitacion = db.Detalle_Habitacion.Find(id);
            if (detalle_Habitacion == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Habitacion);
        }

        // GET: DetalleHabitaciones/Create
        public ActionResult Create()
        {
            ViewBag.hab_id = new SelectList(db.Habitacion, "hab_id", "hab_nombre");
            ViewBag.hot_id = new SelectList(db.Hotel, "hot_id", "hot_nombre");
            return View();
        }

        // POST: DetalleHabitaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dha_id,hot_id,hab_id,dha_costo,dha_observacion")] Detalle_Habitacion detalle_Habitacion)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_Habitacion.Add(detalle_Habitacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.hab_id = new SelectList(db.Habitacion, "hab_id", "hab_nombre", detalle_Habitacion.hab_id);
            ViewBag.hot_id = new SelectList(db.Hotel, "hot_id", "hot_nombre", detalle_Habitacion.hot_id);
            return View(detalle_Habitacion);
        }

        // GET: DetalleHabitaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Habitacion detalle_Habitacion = db.Detalle_Habitacion.Find(id);
            if (detalle_Habitacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.hab_id = new SelectList(db.Habitacion, "hab_id", "hab_nombre", detalle_Habitacion.hab_id);
            ViewBag.hot_id = new SelectList(db.Hotel, "hot_id", "hot_nombre", detalle_Habitacion.hot_id);
            return View(detalle_Habitacion);
        }

        // POST: DetalleHabitaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dha_id,hot_id,hab_id,dha_costo,dha_observacion")] Detalle_Habitacion detalle_Habitacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_Habitacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hab_id = new SelectList(db.Habitacion, "hab_id", "hab_nombre", detalle_Habitacion.hab_id);
            ViewBag.hot_id = new SelectList(db.Hotel, "hot_id", "hot_nombre", detalle_Habitacion.hot_id);
            return View(detalle_Habitacion);
        }

        // GET: DetalleHabitaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Habitacion detalle_Habitacion = db.Detalle_Habitacion.Find(id);
            if (detalle_Habitacion == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Habitacion);
        }

        // POST: DetalleHabitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_Habitacion detalle_Habitacion = db.Detalle_Habitacion.Find(id);
            db.Detalle_Habitacion.Remove(detalle_Habitacion);
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
