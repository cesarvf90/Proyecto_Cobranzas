using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;

namespace RecaudaSoft.Controllers
{
    public class ColaboradoresController : Controller
    {
        //
        // GET: /Colaboradores/

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
        // GET: /Colaboradores/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Colaboradores/Create

        public ActionResult Create()
        {
            using (var db = new CobranzasEntities())
            {
                ViewBag.idNivelGestor = new SelectList(db.Parametroes.Where(p => p.tipo == "NIVEL_GESTOR"), "idParametro", "valor").ToList();
                ViewBag.idTipoGestor = new SelectList(db.Parametroes.Where(p => p.tipo == "TIPO_GESTOR"), "idParametro", "valor").ToList();
                ViewBag.tipoDocumento = new SelectList(db.Parametroes.Where(p => p.tipo == "TIPO_DOCUMENTO"), "idParametro", "valor").ToList();
                return View();
            }
        } 

        //
        // POST: /Colaboradores/Create

        [HttpPost]
        public ActionResult Create(Gestor gestor)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    gestor.disponible = 1;
                    db.Gestors.Add(gestor);
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
        // GET: /Colaboradores/Edit/5
 
        public ActionResult Edit(int id)
        {
            using (var db = new CobranzasEntities())
            {
                var listaGestores = db.Gestors.Include("Parametro").Include("Parametro1").Include("Parametro2");
                Gestor gestor = listaGestores.First(a => a.idGestor == id);

                ViewBag.idNivelGestor = new SelectList(db.Parametroes.Where(p => p.tipo == "NIVEL_GESTOR"), "idParametro", "valor", gestor.idNivelGestor).ToList();
                ViewBag.idTipoGestor = new SelectList(db.Parametroes.Where(p => p.tipo == "TIPO_GESTOR"), "idParametro", "valor", gestor.idTipoGestor).ToList();
                ViewBag.tipoDocumento = new SelectList(db.Parametroes.Where(p => p.tipo == "TIPO_DOCUMENTO"), "idParametro", "valor", gestor.tipoDocumento).ToList();

                return View(gestor);
            }
        }

        //
        // POST: /Colaboradores/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Gestor gestor)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    db.Entry(gestor).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Colaboradores/Delete/5
 
        public ActionResult Delete(int id)
        {
            using (var db = new CobranzasEntities())
            {
                return View(db.Gestors.Include("Parametro").Include("Parametro1").Include("Parametro2").First(a => a.idGestor == id));
            }
        }

        //
        // POST: /Colaboradores/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Gestor gestor)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    db.Entry(gestor).State = System.Data.EntityState.Deleted;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
