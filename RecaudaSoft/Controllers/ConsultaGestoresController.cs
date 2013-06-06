using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;

namespace RecaudaSoft.Controllers
{
    public class ConsultaGestoresController : Controller
    {
        //
        // GET: /ConsultaGestores/

        public ActionResult Index()
        {
            using (var db = new CobranzasEntities())
            {
                var listaGestores = db.Gestors.Include("Parametro");
                listaGestores = listaGestores.Include("Parametro1");
                listaGestores = listaGestores.Include("Parametro2");
                return View(listaGestores.ToList());
            }
        }

        //
        // GET: /ConsultaGestores/DetallarGestor/5

        public ActionResult DetallarGestor(int idGestor)
        {
            using (var db = new CobranzasEntities())
            {
                var listaGestores = db.Gestors.Include("Parametro").Include("Parametro1").Include("Parametro2").Include("GestorXDeudas").Include("GestorXDeudas.Deuda").Include("GestorXDeudas.Deuda.Deudor").Include("GestorXDeudas.Deuda.Parametro").Include("GestorXDeudas.Deuda.Parametro1").Include("GestorXDeudas.Deuda.Cartera");
                Gestor gestor = listaGestores.First(a => a.idGestor == idGestor);

                return View(gestor);
            }
        }

        //
        // GET: /ConsultaGestores/DetallarDeuda/5

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
