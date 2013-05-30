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
                for (int i = 0; i < objetoModelo.carteras.Count; ++i)
                {
                    if (!objetoModelo.carteras.ElementAt(i).Checked)
                    {
                        objetoModelo.carteras.RemoveAt(i);
                    }
                }

                // Se procesan los gestores seleccionados
                for (int i = 0; i < objetoModelo.gestores.Count; ++i)
                {
                    if (!objetoModelo.gestores.ElementAt(i).Checked)
                    {
                        objetoModelo.gestores.RemoveAt(i);
                    }
                }

                objetoModelo.gestores = db.Gestors.Include("Parametro").Include("Parametro1").Include("Parametro2").ToList();
                objetoModelo.carteras = db.Carteras.Include("Acreedor").Include("Parametro").ToList();

                AlgoritmoAsignacion algoritmoAsignacion = new AlgoritmoAsignacion();
                algoritmoAsignacion.asignarActividades(objetoModelo);

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
