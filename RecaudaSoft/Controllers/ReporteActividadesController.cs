using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;
using RecaudaSoft.ViewModels;

namespace RecaudaSoft.Controllers
{
    public class ReporteActividadesController : Controller
    {
        //
        // GET: /ReporteActividades/

        public ActionResult Index()
        {
            using (var db = new CobranzasEntities())
            {
                ViewBag.idNivelGestor = new SelectList(db.Parametroes.Where(p => p.tipo == "NIVEL_GESTOR"), "idParametro", "valor").ToList();
                ViewBag.idTipoGestor = new SelectList(db.Parametroes.Where(p => p.tipo == "TIPO_GESTOR"), "idParametro", "valor").ToList();
                ViewBag.idTipoActividad = new SelectList(db.TipoActividads, "idTipoActividad", "nombre").ToList();
                ViewBag.idResultado = new SelectList(db.Parametroes.Where(p => p.tipo == "RESULTADO_ACTIVIDAD"), "idParametro", "valor").ToList();
                ViewBag.parametro = "Envío de correo";  //enviado para hacer pruebas
                return View();
            }
        }

        //
        // POST: /ReporteActividades/

        [HttpPost]
        public ActionResult Index(FiltroReporteActividad filtroReporte)
        {
                return View("MostrarReporte");
        }

        //
        // GET: /ReporteActividades/VerReporte

        public ActionResult MostrarReporte()
        {
            return View();
        }

    }
}
