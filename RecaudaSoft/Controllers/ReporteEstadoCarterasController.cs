using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;
using RecaudaSoft.ViewModels;

namespace RecaudaSoft.Controllers
{
    public class ReporteEstadoCarterasController : Controller
    {
        //
        // GET: /ReporteEstadoCarteras/

        public ActionResult Index()
        {
            using (var db = new CobranzasEntities())
            {
                ViewBag.idAcreedor = new SelectList(db.Acreedors, "idAcreedor", "nombre").ToList();
                ViewBag.idCartera = new SelectList(db.Carteras, "idCartera", "nombre").ToList();
                return View();
            }
        }

        //
        // POST: /ReporteEstadoCarteras/

        [HttpPost]
        public ActionResult Index(FiltroReporteEstadoCarteras filtroReporte)
        {
            return View("MostrarReporte");
        }

        //
        // GET: /ReporteEstadoCarteras/MosrarReporte

        public ActionResult MostrarReporte()
        {
            return View();
        }
    }
}
