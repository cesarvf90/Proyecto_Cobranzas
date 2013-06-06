using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;

namespace RecaudaSoft.Controllers
{
    public class AsignacionSupervisoresController : Controller
    {
        public static Gestor supervisor { get; set; }

        //
        // GET: /AsignacionSupervisores/

        public ActionResult Index()
        {
            using (var db = new CobranzasEntities())
            {
                var listaGestores = db.Gestors.Include("Parametro").Include("Parametro1").Include("Parametro2").Where(g => g.Parametro.valor == "Supervisor" || g.Parametro.valor == "Jefe de Cobranza");
                return View(listaGestores.ToList());
            }
        }

        //
        // GET: /AsignacionSupervisores/DetallarSupervisor/5

        public ActionResult DetallarSupervisor(int idGestor)
        {
            using (var db = new CobranzasEntities())
            {
                var listaGestores = db.Gestors.Include("Parametro").Include("Parametro1").Include("Parametro2").Include("GestorXGestors").Include("GestorXGestors.Gestor1.Parametro").Include("GestorXGestors.Gestor1.Parametro1").Include("GestorXGestors.Gestor1.Parametro2");
                supervisor = listaGestores.First(a => a.idGestor == idGestor);

                return View(supervisor);
            }
        }

        //
        // GET: /AsignacionSupervisores/RegistrarSupervisados/5

        public ActionResult RegistrarSupervisados(int idGestorSupervisor)
        {
            using (var db = new CobranzasEntities())
            {
                ViewBag.nombreSupervisor = supervisor.NombreCompleto;
                var listaGestores = db.Gestors.Include("Parametro").Include("Parametro1").Include("Parametro2");
                return View(listaGestores.ToList());
            }
        }
    }
}
