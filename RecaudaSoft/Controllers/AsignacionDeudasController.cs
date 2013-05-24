using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;
using RecaudaSoft.Utils;

namespace RecaudaSoft.Controllers
{
    public class AsignacionDeudasController : Controller
    {
                
        //public ArrayList carteras = new ArrayList() { get; set; }
        //public ArrayList gestores = new ArrayList() { get; set; }

        //
        // GET: /AsignacionDeudas/Index

        public ActionResult Index()
        {
            using (var db = new CobranzasEntities())
            {
                ModeloAsignacion objetoModelo = new ModeloAsignacion();
                objetoModelo.gestores = db.Gestors.Include("Parametro").Include("Parametro1").Include("Parametro2").ToList();
                objetoModelo.carteras = db.Carteras.Include("Acreedor").Include("Parametro").ToList();
                return View(objetoModelo);
            }
        }

        //
        // GET: /AsignacionDeudas/EleccionCarteras

        public ActionResult EleccionCarteras()
        {
            using (var db = new CobranzasEntities())
            {
                var listaCarteras = db.Carteras.Include("Acreedor");
                listaCarteras = listaCarteras.Include("Parametro");
                return View(listaCarteras.ToList());
            }
        }
    
        //
        // GET: /AsignacionDeudas/EleccionGestores

        public ActionResult EleccionGestores()
        {
            using (var db = new CobranzasEntities())
            {
                var listaGestores = db.Gestors.Include("Parametro").Include("Parametro1").Include("Parametro2");
                return View(listaGestores.ToList());
            }
        }

        //
        // GET: /AsignacionDeudas/AsignarTareas

        public ActionResult AsignarTareas()
        {
            return AsignarTareasExitoso();
        }


        //
        // POST: /AsignacionDeudas/AsignarTareas
        /*
        [HttpPost]
        public ActionResult AsignarTareas(string button)
        {

        }
         * */

        //
        // GET: /AsignacionDeudas/AsignarTareasExitoso

        public ActionResult AsignarTareasExitoso()
        {
            return View();
        } 

    }
}
