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
                var listaGestores = db.Gestors.Include("Parametro").Include("Parametro1").Include("Parametro2");
                Gestor gestor = listaGestores.First(a => a.idGestor == idGestor);

                return View(gestor);
            }
        }

    }
}
