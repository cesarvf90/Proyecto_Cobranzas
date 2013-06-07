using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;
using RecaudaSoft.ViewModels;

namespace RecaudaSoft.Controllers
{
    public class ReporteAcreedoresController : Controller
    {
        //
        // GET: /ReporteAcreedores/

        public ActionResult Index()
        {
            using (var db = new CobranzasEntities())
            {
                ViewBag.idAcreedor = new SelectList(db.Acreedors, "idAcreedor", "nombre").ToList();
                return View();
            }
        }

        //
        // POST: /ReporteAcreedores/

        [HttpPost]
        public ActionResult Index(FiltroReporteAcreedores filtroReporte)
        {
            return View("MostrarReporte");
        }

        //
        // GET: /ReporteAcreedores/MosrarReporte

        public ActionResult MostrarReporte()
        {
            return View();
        }
    }
}
