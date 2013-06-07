using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;
using RecaudaSoft.ViewModels;

namespace RecaudaSoft.Controllers
{
    public class ReporteDesempenioGestoresController : Controller
    {
        //
        // GET: /ReporteDesempenioGestores/

        public ActionResult Index()
        {
            using (var db = new CobranzasEntities())
            {
                ViewBag.idNivelGestor = new SelectList(db.Parametroes.Where(p => p.tipo == "NIVEL_GESTOR"), "idParametro", "valor").ToList();
                ViewBag.idTipoGestor = new SelectList(db.Parametroes.Where(p => p.tipo == "TIPO_GESTOR"), "idParametro", "valor").ToList();
                ViewBag.tipoDocumento = new SelectList(db.Parametroes.Where(p => p.tipo == "TIPO_DOCUMENTO"), "idParametro", "valor").ToList();
                return View();
            }
        }

        //
        // POST: /ReporteDesempenioGestores/

        [HttpPost]
        public ActionResult Index(FiltroReporteDesempenioGestores filtroReporte)
        {
            return View("MostrarReporte");
        }

        //
        // GET: /ReporteDesempenioGestores/MostrarReporte

        public ActionResult MostrarReporte()
        {
            return View();
        }

    }
}
