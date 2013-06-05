using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;

namespace RecaudaSoft.Controllers
{
    public class RegistroAvanceController : Controller
    {
        public static Deuda deudaSeleccionada { get; set; }

        //
        // GET: /RegistroAvance/

        public ActionResult Index()
        {
            using (var db = new CobranzasEntities())
            {
                var listaDeudas = db.Deudas.Include("Parametro").Include("Deudor").Include("Cartera").Include("Parametro1");
                return View(listaDeudas.ToList());
            }
        }

        //
        // GET: /RegistroAvance/Details/5

        public ActionResult Details(int id)
        {
            using (var db = new CobranzasEntities())
            {
                var listaDeudas = db.Deudas.Include("Parametro").Include("Deudor").Include("GestorXDeudas").Include("Cartera").Include("Parametro1").Include("Deudor.Parametro").Include("Deudor.Parametro1").Include("Deudor.Parametro2");
                deudaSeleccionada = listaDeudas.First(a => a.idDeuda == id);

                ViewBag.moneda = new SelectList(db.Parametroes.Where(p => p.tipo == "MONEDA"), "idParametro", "valor", deudaSeleccionada.moneda).ToList();

                return View(deudaSeleccionada);
            }
        }
        
        //
        // GET: /RegistroAvance/Edit/5
        // Se envia como parametro el id de la deuda
        public ActionResult RegistrarActividad()
        {
            using (var db = new CobranzasEntities())
            {
                ViewBag.idTipoActividad = new SelectList(db.TipoActividads, "idTipoActividad", "nombre").ToList();
                ViewBag.idResultado = new SelectList(db.Parametroes.Where(p => p.tipo == "RESULTADO_ACTIVIDAD"), "idParametro", "valor").ToList();
                return View();
            }
        }

        [HttpPost]
        public ActionResult RegistrarActividad(Actividad actividad)
        {
            try
            {
                actividad.idDeuda = deudaSeleccionada.idDeuda;
                // TODO cvasquez: registrar la actividad con el deudor que la esta realizando
                actividad.idGestor = deudaSeleccionada.GestorXDeudas.First().idGestor;
                // Se le debe setear la deuda y el gestor a la actividad (se obtienen de la misma transaccion)
                using (var db = new CobranzasEntities())
                {
                    db.Actividads.Add(actividad);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /RegistroAvance/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /RegistroAvance/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /RegistroAvance/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /RegistroAvance/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /RegistroAvance/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /RegistroAvance/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
