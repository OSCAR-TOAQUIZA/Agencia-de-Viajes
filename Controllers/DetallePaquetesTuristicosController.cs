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
    public class DetallePaquetesTuristicosController : Controller
    {
        private Agencia_de_Viajes_CertificacionEntities db = new Agencia_de_Viajes_CertificacionEntities();

        // GET: DetallePaquetesTuristicos
        public ActionResult Index()
        {
            var detalle_Paquete_Turistico = db.Detalle_Paquete_Turistico.Include(d => d.Actividad).Include(d => d.Paquete_Turistico).Include(d => d.Transporte);
            return View(detalle_Paquete_Turistico.ToList());
        }

        // GET: DetallePaquetesTuristicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Paquete_Turistico detalle_Paquete_Turistico = db.Detalle_Paquete_Turistico.Find(id);
            if (detalle_Paquete_Turistico == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Paquete_Turistico);
        }

        public String VerCiudad(int id_paq)
        {
            var paquete = db.Paquete_Turistico.Find(id_paq);
            var habitacion = db.Detalle_Habitacion.Find(paquete.dha_id);
            var hotel = db.Hotel.Find(habitacion.hot_id);
            var ciudad = db.Ciudad.Find(hotel.ciu_id);

            return (ciudad.ciu_nombre);
        }

      

        // GET: DetallePaquetesTuristicos/Create
        public ActionResult Create(int ptu_id)
        {
            ViewBag.ptu_id = new SelectList(db.Paquete_Turistico, "ptu_id", "ptu_nombre", ptu_id);
            ViewBag.act_id = new SelectList(db.Actividad, "act_id", "act_nombre");
            ViewBag.tra_id = new SelectList(db.Transporte, "tra_id", "tra_tipo_transporte");
            return View();
        }

        // POST: DetallePaquetesTuristicos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dptu_id,ptu_id,act_id,tra_id,dptu_etado,dptu_observacion")] Detalle_Paquete_Turistico detalle_Paquete_Turistico)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_Paquete_Turistico.Add(detalle_Paquete_Turistico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.act_id = new SelectList(db.Actividad, "act_id", "act_nombre", detalle_Paquete_Turistico.act_id);
            //ViewBag.ptu_id = new SelectList(db.Paquete_Turistico, "ptu_id", "ptu_nombre", detalle_Paquete_Turistico.ptu_id);
            //ViewBag.tra_id = new SelectList(db.Transporte, "tra_id", "tra_tipo_transporte", detalle_Paquete_Turistico.tra_id);
            return View(detalle_Paquete_Turistico);
        }

        // GET: DetallePaquetesTuristicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Paquete_Turistico detalle_Paquete_Turistico = db.Detalle_Paquete_Turistico.Find(id);
            if (detalle_Paquete_Turistico == null)
            {
                return HttpNotFound();
            }
            ViewBag.act_id = new SelectList(db.Actividad, "act_id", "act_nombre", detalle_Paquete_Turistico.act_id);
            ViewBag.ptu_id = new SelectList(db.Paquete_Turistico, "ptu_id", "ptu_nombre", detalle_Paquete_Turistico.ptu_id);
            ViewBag.tra_id = new SelectList(db.Transporte, "tra_id", "tra_tipo_transporte", detalle_Paquete_Turistico.tra_id);
            return View(detalle_Paquete_Turistico);
        }

        // POST: DetallePaquetesTuristicos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dptu_id,ptu_id,act_id,tra_id,dptu_etado,dptu_observacion")] Detalle_Paquete_Turistico detalle_Paquete_Turistico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_Paquete_Turistico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.act_id = new SelectList(db.Actividad, "act_id", "act_nombre", detalle_Paquete_Turistico.act_id);
            ViewBag.ptu_id = new SelectList(db.Paquete_Turistico, "ptu_id", "ptu_nombre", detalle_Paquete_Turistico.ptu_id);
            ViewBag.tra_id = new SelectList(db.Transporte, "tra_id", "tra_tipo_transporte", detalle_Paquete_Turistico.tra_id);
            return View(detalle_Paquete_Turistico);
        }

        // GET: DetallePaquetesTuristicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Paquete_Turistico detalle_Paquete_Turistico = db.Detalle_Paquete_Turistico.Find(id);
            if (detalle_Paquete_Turistico == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Paquete_Turistico);
        }

        // POST: DetallePaquetesTuristicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_Paquete_Turistico detalle_Paquete_Turistico = db.Detalle_Paquete_Turistico.Find(id);
            db.Detalle_Paquete_Turistico.Remove(detalle_Paquete_Turistico);
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
