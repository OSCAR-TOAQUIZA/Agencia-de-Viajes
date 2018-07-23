
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pry_Agencia_Viajes;
using static System.Net.Mime.MediaTypeNames;

namespace Pry_Agencia_Viajes.Controllers
{
    public class PaquetesTuristicosController : Controller
    {
        private Agencia_de_Viajes_CertificacionEntities db = new Agencia_de_Viajes_CertificacionEntities();

        // GET: PaquetesTuristicos
        public ActionResult Index()
        {
            
            ViewBag.ptu_id = new SelectList(db.Paquete_Turistico, "ptu_id", "ptu_nombre");
            var paquete_Turistico = db.Paquete_Turistico.Include(p => p.Detalle_Habitacion);
            return View(paquete_Turistico.ToList());
        }

        // GET: PaquetesTuristicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquete_Turistico paquete_Turistico = db.Paquete_Turistico.Find(id);
            if (paquete_Turistico == null)
            {
                return HttpNotFound();
            }
            return View(paquete_Turistico);
        }

        public ActionResult PreCreate()
        {
            ViewBag.act_id = new SelectList(db.Actividad, "act_id", "act_nombre");
            return View("PreCreate");
        }


        // GET: PaquetesTuristicos/Create
        public ActionResult Create()
        {
            var datos = db.Detalle_Habitacion.Include(h => h.Habitacion).Include(ho => ho.Hotel);
            
            List<SelectListItem> conjunto = new List<SelectListItem> { };
            foreach (var item in datos)
            {
                conjunto.Add(
                    new SelectListItem { Text = item.Hotel.hot_nombre + " / " + item.Habitacion.hab_nombre + " / " +item.dha_costo, Value = (item.dha_id).ToString()  }
                );
            }
            ViewBag.dha_id = new SelectList(conjunto, "Value", "Text");
            return View();
        }

        // POST: PaquetesTuristicos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ptu_id,ptu_nombre,ptu_descripcion,ptu_estado,ptu_fecha_salida,ptu_fecha_llegada,dha_id")] Paquete_Turistico paquete_Turistico )
        {
            if (ModelState.IsValid)
            {
                db.Paquete_Turistico.Add(paquete_Turistico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dha_id = new SelectList(db.Detalle_Habitacion, "dha_id", "dha_observacion", paquete_Turistico.dha_id);
            return View(paquete_Turistico);
        }

        // GET: PaquetesTuristicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquete_Turistico paquete_Turistico = db.Paquete_Turistico.Find(id);
            if (paquete_Turistico == null)
            {
                return HttpNotFound();
            }
            ViewBag.dha_id = new SelectList(db.Detalle_Habitacion, "dha_id", "dha_observacion", paquete_Turistico.dha_id);
            return View(paquete_Turistico);
        }

        // POST: PaquetesTuristicos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ptu_id,ptu_nombre,ptu_descripcion,ptu_estado,ptu_foto_1,ptu_foto_2,ptu_fecha_salida,ptu_fecha_llegada,dha_id")] Paquete_Turistico paquete_Turistico, HttpPostedFileBase ImagenFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paquete_Turistico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dha_id = new SelectList(db.Detalle_Habitacion, "dha_id", "dha_observacion", paquete_Turistico.dha_id);
            return View(paquete_Turistico);
        }

        // GET: PaquetesTuristicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquete_Turistico paquete_Turistico = db.Paquete_Turistico.Find(id);
            if (paquete_Turistico == null)
            {
                return HttpNotFound();
            }
            return View(paquete_Turistico);
        }

        // POST: PaquetesTuristicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paquete_Turistico paquete_Turistico = db.Paquete_Turistico.Find(id);
            db.Paquete_Turistico.Remove(paquete_Turistico);
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
