using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pry_Agencia_Viajes;

namespace Pry_Agencia_Viajes.Controllers
{
    public class ActividadsController : Controller
    {
        private Agencia_de_Viajes_CertificacionEntities db = new Agencia_de_Viajes_CertificacionEntities();
        // GET: Actividads
        public ActionResult Index()
        {
            var actividad = db.Actividad.Include(a => a.Lugar);
            return View(actividad.ToList());
        }

        // GET: Actividads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        // GET: Actividads/Create
        public ActionResult Create(int id_Lugar, string ciudad, string nombre_Lugar, string foto)
        {
            //ViewBag.lug_id = new SelectList(db.Lugar, "lug_id", "lug_nombre");
            // Actividad actividades = db.Actividad.FirstOrDefault(e => e.lug_id.Equals(lugar.lug_id));
            ViewBag.id = id_Lugar;
            ViewBag.nombre = nombre_Lugar;
            ViewBag.ruta = foto;
            ViewBag.ciudad = ciudad;
            return View();
        }

        
        // POST: Actividads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "act_id,act_nombre,act_descripcion,act_costo,act_estado,act_ruta_foto_1")] Actividad actividad, HttpPostedFileBase actividadFoto1, int id_Lugar, string ciudad, string nombre_Lugar, string foto)
        {
            ViewBag.id = id_Lugar;
            ViewBag.nombre = nombre_Lugar;
            ViewBag.ruta = foto;
            ViewBag.ciudad = ciudad;
            actividad.ImagenFile = actividadFoto1;
            if (ModelState.IsValid)
            {
                actividad.lug_id = id_Lugar;
                if (actividad.ImagenFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(actividadFoto1.FileName);
                    string extension = Path.GetExtension(actividadFoto1.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    actividad.act_ruta_foto_1 = "~/Images/Actividades/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/Actividades/"), fileName);
                    actividad.ImagenFile.SaveAs(fileName);
                    db.Actividad.Add(actividad);
                    db.SaveChanges();
                    return RedirectToAction("Index","Lugares");
                }
                else
                {      
                    ViewBag.ErrorFoto = "La Foto de la Actividad es obligatoria";
                    return View(actividad);
                }

            }
            //ViewBag.lug_id = new SelectList(db.Lugar, "lug_id", "lug_nombre", actividad.lug_id);
            return View(actividad);
        }

        // GET: Actividads/Edit/5
        public ActionResult Edit(int? id, int id_Lugar, string ciudad, string nombre_Lugar, string foto)
        {
            ViewBag.id_Lugar = id_Lugar;
            ViewBag.nombre = nombre_Lugar;
            ViewBag.ruta = foto;
            ViewBag.ciudad = ciudad;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            //ViewBag.lug_id = new SelectList(db.Lugar, "lug_id", "lug_nombre", actividad.lug_id);
            return View(actividad);
        }

        // POST: Actividads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "act_id,act_nombre,act_descripcion,act_costo,act_estado")] Actividad actividad, HttpPostedFileBase actividadFoto1, int id_Lugar, string ciudad, string nombre_Lugar, string foto)
        {
            ViewBag.id_Lugar = id_Lugar;
            ViewBag.nombre = nombre_Lugar;
            ViewBag.ruta = foto;
            ViewBag.ciudad = ciudad;
            string rutaNoModificada;
            using (db)
            {
                var actividadGuardada = db.Actividad.Find(actividad.act_id);
                rutaNoModificada = actividadGuardada.act_ruta_foto_1;
            }
            Agencia_de_Viajes_CertificacionEntities db2 = new Agencia_de_Viajes_CertificacionEntities();
            actividad.ImagenFile = actividadFoto1;
            if (ModelState.IsValid)
            {
                if (actividad.ImagenFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(actividadFoto1.FileName);
                    string extension = Path.GetExtension(actividadFoto1.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    actividad.act_ruta_foto_1 = "~/Images/Actividades/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/Actividades"), fileName);
                    actividad.ImagenFile.SaveAs(fileName);
                    actividad.lug_id = id_Lugar;
                    db2.Entry(actividad).State = EntityState.Modified;
                    db2.SaveChanges();
                    db2.Dispose();
                    return RedirectToAction("Index", "Lugares");
                }
                else
                {
                    actividad.lug_id = id_Lugar;
                    actividad.act_ruta_foto_1 = rutaNoModificada;
                    db2.Entry(actividad).State = EntityState.Modified;
                    db2.SaveChanges();
                    db2.Dispose();
                    return RedirectToAction("Index", "Lugares");
                }
            }
            
            return View(actividad);
        }

        // GET: Actividads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        // POST: Actividads/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actividad actividad = db.Actividad.Find(id);
            db.Actividad.Remove(actividad);
            db.SaveChanges();
            return RedirectToAction("Index","Lugares");
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
