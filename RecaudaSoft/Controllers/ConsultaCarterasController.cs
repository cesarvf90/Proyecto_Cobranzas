using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;

namespace RecaudaSoft.Controllers
{
    public class ConsultaCarterasController : Controller
    {
        //
        // GET: /ConsultaCarteras/

        public ActionResult Index()
        {
            using (var db = new CobranzasEntities())
            {
                var listaCarteras = db.Carteras.Include("Acreedor");
                listaCarteras = listaCarteras.Include("Parametro");
                return View(listaCarteras.ToList());
            }
        }

        //
        // GET: /ConsultaCarteras/DetallarCartera/5

        public ActionResult DetallarCartera(int idCartera)
        {
            using (var db = new CobranzasEntities())
            {
                var listaCarteras = db.Carteras.Include("Parametro").Include("Acreedor").Include("Deudas").Include("Deudas.Deudor").Include("Deudas.GestorXDeudas").Include("Deudas.Parametro").Include("Deudas.Parametro1");
                Cartera cartera = listaCarteras.First(a => a.idCartera == idCartera);

                ViewBag.esVencida = new SelectList(db.Parametroes.Where(p => p.tipo == "TIPO_CARTERA"), "idParametro", "valor", cartera.esVencida).ToList();
                ViewBag.idAcreedor = new SelectList(db.Acreedors, "idAcreedor", "nombre", cartera.idAcreedor).ToList();

                return View(cartera);
            }
        }

        //
        // GET: /ConsultaCarteras/DetallarDeuda/5

        public ActionResult DetallarDeuda(int idDeuda)
        {
            using (var db = new CobranzasEntities())
            {
                var listaDeudas = db.Deudas.Include("Parametro").Include("Deudor").Include("GestorXDeudas").Include("Cartera").Include("Parametro1").Include("Deudor.Parametro").Include("Deudor.Parametro1").Include("Deudor.Parametro2");
                Deuda deuda = listaDeudas.First(a => a.idDeuda == idDeuda);

                ViewBag.moneda = new SelectList(db.Parametroes.Where(p => p.tipo == "MONEDA"), "idParametro", "valor", deuda.moneda).ToList();

                return View(deuda);
            }
        }
    }
}
