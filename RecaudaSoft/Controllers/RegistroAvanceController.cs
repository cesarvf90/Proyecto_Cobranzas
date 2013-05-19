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
        //
        // GET: /RegistroAvance/

        public ActionResult Index()
        {
            using (var db = new CobranzasEntities())
            {
                var listaDeudas = db.Deudas.Include("Parametro");
                return View(listaDeudas.ToList());
            }
        }

        //
        // GET: /RegistroAvance/Details/5

        public ActionResult Details(int id)
        {
            using (var db = new CobranzasEntities())
            {
                var listaDeudas = db.Deudas.Include("Parametro");
                Deuda deuda = listaDeudas.First(a => a.idDeuda == id);

                ViewBag.moneda = new SelectList(db.Parametroes.Where(p => p.tipo == "MONEDA"), "idParametro", "valor", deuda.moneda).ToList();

                return View(deuda);
            }
        }
        
        //
        // GET: /RegistroAvance/Edit/5

        public ActionResult RegistrarActividad(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarActividad(int id, Actividad actividad)
        {
            try
            {
                // TODO Registrar la actividad en la BD
                // Se le debe setear la deuda y el gestor a la actividad (se obtienen de la misma transaccion)
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
