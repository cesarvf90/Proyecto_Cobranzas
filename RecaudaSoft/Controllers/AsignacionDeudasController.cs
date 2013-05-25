using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;
using RecaudaSoft.Utils;
using RecaudaSoft.ViewModels;

namespace RecaudaSoft.Controllers
{
    public class AsignacionDeudasController : Controller
    {
                
        //
        // GET: /AsignacionDeudas/Index

        public ActionResult Index()
        {
            using (var db = new CobranzasEntities())
            {
                ModeloAsignacion objetoModelo = new ModeloAsignacion();
                objetoModelo.gestores = db.Gestors.Include("Parametro").Include("Parametro1").Include("Parametro2").ToList();
                objetoModelo.carteras = db.Carteras.Include("Acreedor").Include("Parametro").ToList();
                objetoModelo.valor = 7;
                return View(objetoModelo);
            }
        }

        //
        // POST: /AsignacionDeudas/Index
        /*
        [HttpPost]
        public ActionResult Index(ModeloAsignacion objeto)
        {
            using (var db = new CobranzasEntities())
            {
                var listaCarteras = db.Carteras.Include("Acreedor");
                listaCarteras = listaCarteras.Include("Parametro");
                return View(objeto);
            }
        }
        */

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

        public ActionResult AsignarTareas(ModeloAsignacion objetoModelo)
        {
            using (var db = new CobranzasEntities())
            {
                // Se procesan las carteras seleccionadas
                List<Cartera> carterasSeleccionadas = new List<Cartera>();
                //foreach (var cartera in objetoModelo.carteras)
                foreach (var cartera in objetoModelo.carteras)
                {
                    if (cartera.Checked)
                    {
                        carterasSeleccionadas.Add(cartera);
                    }
                }

                // Se procesan los gestores seleccionados
                List<Gestor> gestoresSeleccionados = new List<Gestor>();
                foreach (var gestor in objetoModelo.gestores)
                {
                    if (gestor.Checked)
                    {
                        gestoresSeleccionados.Add(gestor);
                    }
                }

                return View(objetoModelo);
            }
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
