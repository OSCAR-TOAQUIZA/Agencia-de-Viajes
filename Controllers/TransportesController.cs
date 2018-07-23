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
    public class TransportesController : Controller
    {
        private Agencia_de_Viajes_CertificacionEntities db = new Agencia_de_Viajes_CertificacionEntities();

        // GET: Transportes
        public ActionResult Index()
        {
            return View(db.Transporte.ToList());
        }

        // GET: Transportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporte transporte = db.Transporte.Find(id);
            if (transporte == null)
            {
                return HttpNotFound();
            }
            return View(transporte);
        }

        // GET: Transportes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transportes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tra_id,tra_tipo_transporte,tra_costo,tra_origen,tra_destino,tra_hora_salida,tra_hora_llegada,tra_descripcion")] Transporte transporte)
        {
            if (ModelState.IsValid)
            {
                db.Transporte.Add(transporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transporte);
        }

        // GET: Transportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporte transporte = db.Transporte.Find(id);
            if (transporte == null)
            {
                return HttpNotFound();
            }
            return View(transporte);
        }

        // POST: Transportes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tra_id,tra_tipo_transporte,tra_costo,tra_origen,tra_destino,tra_hora_salida,tra_hora_llegada,tra_descripcion")] Transporte transporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transporte);
        }

        // GET: Transportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporte transporte = db.Transporte.Find(id);
            if (transporte == null)
            {
                return HttpNotFound();
            }
            return View(transporte);
        }

        // POST: Transportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transporte transporte = db.Transporte.Find(id);
            db.Transporte.Remove(transporte);
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
