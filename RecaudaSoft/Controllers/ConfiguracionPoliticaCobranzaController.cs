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
                idPoliticaCobranzaSeleccionada = -1;
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

        public ActionResult RegistrarPolitica(int id)
        {
            using (var db = new CobranzasEntities())
            {
                PoliticaCobranza politica;
                if (idPoliticaCobranzaSeleccionada == -1)
                {
                    // Se crea la nueva politica de cobranza
                    politica = new PoliticaCobranza();
                    politica.idCartera = id;
                }
                else
                {
                    politica = db.PoliticaCobranzas.Include("PoliticaCobranzaXTipoActividads").First(p => p.idPoliticaCobranza == idPoliticaCobranzaSeleccionada);
                }

                return View(politica);
            }
        }

        //
        // POST: /ConfiguracionPoliticaCobranza/RegistrarPolitica

        [HttpPost]
        public ActionResult RegistrarPolitica(PoliticaCobranza politica)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    db.PoliticaCobranzas.Add(politica);
                    db.SaveChanges();
                    idPoliticaCobranzaSeleccionada = politica.idPoliticaCobranza;
                }
                return RedirectToAction("RegistrarPolitica", politica.idPoliticaCobranza);
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
                /*
                var listaActividades = Enumerable.Empty<PoliticaCobranzaXTipoActividad>();
                if (idPoliticaCobranzaSeleccionada != -1)
                {
                    listaActividades = db.PoliticaCobranzaXTipoActividads.Where(p => p.idPoliticaCobranza == idPoliticaCobranzaSeleccionada);
                } 
                 */
                var listaActividades = db.PoliticaCobranzaXTipoActividads; 
                return View(listaActividades.ToList());
            }
        }

        //
        // POST: /ConfiguracionPoliticaCobranza/RegistrarActividadesPolitica

        [HttpPost]
        public ActionResult RegistrarActividadesPolitica(PoliticaCobranzaXTipoActividad pasoPolitica)
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
                    pasoPolitica.idPoliticaCobranza = idPoliticaCobranzaSeleccionada;
                    db.PoliticaCobranzaXTipoActividads.Add(pasoPolitica);
                    db.SaveChanges();
                }
                //return RedirectToAction("RegistrarPolitica", idPoliticaCobranzaSeleccionada);
                //return RegistrarPolitica(idPoliticaCobranzaSeleccionada);
                return View("RegistroPasoPoliticaExitoso", pasoPolitica);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ConfiguracionPoliticaCobranza/RegistroPasoPoliticaExitoso

        public ActionResult RegistroPasoPoliticaExitoso()
        {
            return View();
        } 
    }
}
