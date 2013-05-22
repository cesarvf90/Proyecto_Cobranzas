using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;

namespace RecaudaSoft.Controllers
{
    public class ConfiguracionPoliticaCobranzaController : Controller
    {

        public static int idPoliticaCobranzaSeleccionada { get; set; }

        //
        // GET: /ConfiguracionPoliticaCobranza/

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
        // GET: /ConfiguracionPoliticaCobranza/Details/5

        public ActionResult Details(int id)
        {
            using (var db = new CobranzasEntities())
            {
                var listaCarteras = db.Carteras.Include("Parametro").Include("Acreedor");
                Cartera cartera = listaCarteras.First(a => a.idCartera == id);

                ViewBag.esVencida = new SelectList(db.Parametroes.Where(p => p.tipo == "TIPO_CARTERA"), "idParametro", "valor", cartera.esVencida).ToList();
                ViewBag.idAcreedor = new SelectList(db.Acreedors, "idAcreedor", "nombre", cartera.idAcreedor).ToList();

                return View(cartera);
            }
        }

        //
        // GET: /ConfiguracionPoliticaCobranza/RegistrarPolitica

        public ActionResult RegistrarPolitica()
        {
            using (var db = new CobranzasEntities())
            {
                ViewBag.idTipoActividad = new SelectList(db.TipoActividads, "idTipoActividad", "nombre").ToList();
                return View();
            }
        }

        //
        // POST: /ConfiguracionPoliticaCobranza/RegistrarPolitica

        [HttpPost]
        public ActionResult RegistrarPolitica(List<PoliticaCobranzaXTipoActividad> listaActividades)
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
        // GET: /ConfiguracionPoliticaCobranza/RegistrarActividadesPolitica

        public ActionResult RegistrarActividadesPolitica()
        {
            using (var db = new CobranzasEntities())
            {
                ViewBag.idTipoActividad = new SelectList(db.TipoActividads, "idTipoActividad", "nombre").ToList();
                return View();
            }
        }

        //
        // POST: /ConfiguracionPoliticaCobranza/RegistrarActividadesPolitica

        [HttpPost]
        public ActionResult RegistrarActividadesPolitica(List<PoliticaCobranzaXTipoActividad> listaActividades)
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
        // GET: /ConfiguracionPoliticaCobranza/RegistrarPasoPolitica

        public ActionResult RegistrarPasoPolitica()
        {
            using (var db = new CobranzasEntities())
            {
                ViewBag.idTipoActividad = new SelectList(db.TipoActividads, "idTipoActividad", "nombre").ToList();
                return View();
            }
        }

        //
        // POST: /ConfiguracionPoliticaCobranza/RegistrarPasoPolitica

        [HttpPost]
        public ActionResult RegistrarPasoPolitica(PoliticaCobranzaXTipoActividad pasoPolitica)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    // TODO asignarle idpoliticacobranza al paso
                    //pasoPolitica.idPoliticaCobranza;
                    db.PoliticaCobranzaXTipoActividads.Add(pasoPolitica);
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
        // GET: /ConfiguracionPoliticaCobranza/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ConfiguracionPoliticaCobranza/Create

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
        // GET: /ConfiguracionPoliticaCobranza/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ConfiguracionPoliticaCobranza/Edit/5

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
        // GET: /ConfiguracionPoliticaCobranza/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ConfiguracionPoliticaCobranza/Delete/5

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
