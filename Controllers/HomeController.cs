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
    public class HomeController : Controller
    {
        private Agencia_de_Viajes_CertificacionEntities db = new Agencia_de_Viajes_CertificacionEntities();
        // GET: Actividads
        public ActionResult Index()
        {
            var actividad = db.Actividad.Include(a => a.Lugar);
            return View(actividad.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}