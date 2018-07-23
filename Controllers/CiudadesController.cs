using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pry_Agencia_Viajes;

namespace Pry_Agencia_Viajes.Controllers
{
    public class CiudadesController : Controller
    {
        private Agencia_de_Viajes_CertificacionEntities db = new Agencia_de_Viajes_CertificacionEntities();

        // GET: Ciudades
        public ActionResult Index()
        {
            return View(db.Ciudad.ToList());
        }

        // GET: Ciudades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.Ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // GET: Ciudades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ciudades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ciu_id,ciu_nombre,ciu_descripcion,ciu_clima,ciu_recomendaciones,ciu_observacion")] Ciudad ciudad, HttpPostedFileBase ImagenFile)
        {
            ciudad.ImagenFile = ImagenFile;
            if (ModelState.IsValid)
            {
                if (ciudad.ImagenFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(ImagenFile.FileName);
                    string extension = Path.GetExtension(ImagenFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    ciudad.ciu_ruta_foto = "~/Images/Ciudades/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/Ciudades/"), fileName);
                    ciudad.ImagenFile.SaveAs(fileName);
                    db.Ciudad.Add(ciudad);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {

                    ViewBag.ErrorFoto = "La Foto de la Ciudad es obligatoria";
                    return View(ciudad);
                }
               
            }

            return View(ciudad);
        }

        // GET: Ciudades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.Ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ciu_id,ciu_nombre,ciu_descripcion,ciu_clima,ciu_recomendaciones,ciu_observacion")] Ciudad ciudad, HttpPostedFileBase ImagenFile)

        {
            string rutaNoModificada;
            using (db)
            {
                var ciudadGuardada = db.Ciudad.Find(ciudad.ciu_id);
                rutaNoModificada = ciudadGuardada.ciu_ruta_foto;
            }
            Agencia_de_Viajes_CertificacionEntities db2 = new Agencia_de_Viajes_CertificacionEntities();
            ciudad.ImagenFile = ImagenFile;
            if (ModelState.IsValid)
            {
                if (ciudad.ImagenFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(ImagenFile.FileName);
                    string extension = Path.GetExtension(ImagenFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    ciudad.ciu_ruta_foto = "~/Images/Ciudades/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/Ciudades/"), fileName);
                    ciudad.ImagenFile.SaveAs(fileName);

                    db2.Entry(ciudad).State = EntityState.Modified;
                    db2.SaveChanges();
                    db2.Dispose();
                    return RedirectToAction("Index");
                }
                else
                {
                    ciudad.ciu_ruta_foto = rutaNoModificada;
                    db2.Entry(ciudad).State = EntityState.Modified;
                    db2.SaveChanges();
                    db2.Dispose();
                    return RedirectToAction("Index");
                }

               
            }
            return View(ciudad);
        }

        // GET: Ciudades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.Ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ciudad ciudad = db.Ciudad.Find(id);
            db.Ciudad.Remove(ciudad);
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
