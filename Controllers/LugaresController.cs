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
    public class LugaresController : Controller
    {
        private Agencia_de_Viajes_CertificacionEntities db = new Agencia_de_Viajes_CertificacionEntities();

        // GET: Lugares
        public ActionResult Index()
        {
            var lugar = db.Lugar.Include(l => l.Ciudad);
            return View(lugar.ToList());
        }

        // GET: Lugares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar lugar = db.Lugar.Find(id);

            //Employee insertedEmployee = db.Employees.FirstOrDefault(e ⇒e.Name.Equals("Michael"));
            //Actividad actividades = db.Actividad.FirstOrDefault(e => e.lug_id.Equals(lugar.lug_id));
            //ViewBag.Detalles = db.DetalesEntrega.Where(x => x.EntregaId == id);
            ViewBag.actividades = db.Actividad.Where(x => x.lug_id == lugar.lug_id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // GET: Lugares/Create
        public ActionResult Create()
        {
            ViewBag.ciu_id = new SelectList(db.Ciudad, "ciu_id", "ciu_nombre");
            return View();
        }

        // POST: Lugares/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lug_id,lug_nombre,lug_descripcion,lug_estado,lug_observacion,ciu_id")] Lugar lugar, HttpPostedFileBase ImagenLugar)
        {
            lugar.ImagenFile = ImagenLugar;
            
            if (ModelState.IsValid)
            {
                if (lugar.ImagenFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(ImagenLugar.FileName);
                    string extension = Path.GetExtension(ImagenLugar.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    lugar.lug_ruta_foto = "~/Images/Lugares/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/Lugares/"), fileName);
                    lugar.ImagenFile.SaveAs(fileName);
                    db.Lugar.Add(lugar);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorFoto = "La Foto del Lugar es obligatoria";
                    ViewBag.ciu_id = new SelectList(db.Ciudad, "ciu_id", "ciu_nombre", lugar.ciu_id);
                    return View(lugar);
                }

            }
            if (ModelState.IsValid)
            {
                db.Lugar.Add(lugar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ciu_id = new SelectList(db.Ciudad, "ciu_id", "ciu_nombre", lugar.ciu_id);
            return View(lugar);
        }

        // GET: Lugares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar lugar = db.Lugar.Find(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            ViewBag.ciu_id = new SelectList(db.Ciudad, "ciu_id", "ciu_nombre", lugar.ciu_id);
            return View(lugar);
        }

        // POST: Lugares/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lug_id,lug_nombre,lug_descripcion,lug_estado,lug_observacion,ciu_id")] Lugar lugar, HttpPostedFileBase ImagenLugar)
        {
            string rutaNoModificada;
            using (db)
            {
                var lugarGuardado = db.Lugar.Find(lugar.lug_id);
                rutaNoModificada = lugarGuardado.lug_ruta_foto;
            }
            Agencia_de_Viajes_CertificacionEntities db2 = new Agencia_de_Viajes_CertificacionEntities();
            lugar.ImagenFile = ImagenLugar;
            if (ModelState.IsValid)
            {
                    if (lugar.ImagenFile != null)
                    {
                    string fileName = Path.GetFileNameWithoutExtension(ImagenLugar.FileName);
                    string extension = Path.GetExtension(ImagenLugar.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    lugar.lug_ruta_foto = "~/Images/Lugares/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/Lugares/"), fileName);
                    lugar.ImagenFile.SaveAs(fileName);

                    db2.Entry(lugar).State = EntityState.Modified;
                    db2.SaveChanges();
                    db2.Dispose();
                    return RedirectToAction("Index");
                }
                    else
                    {
                    lugar.lug_ruta_foto = rutaNoModificada;
                    db2.Entry(lugar).State = EntityState.Modified;
                    db2.SaveChanges();
                    db2.Dispose();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ciu_id = new SelectList(db2.Ciudad, "ciu_id", "ciu_nombre", lugar.ciu_id);
            return View(lugar);
        }

        // GET: Lugares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar lugar = db.Lugar.Find(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // POST: Lugares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lugar lugar = db.Lugar.Find(id);
            db.Lugar.Remove(lugar);
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
