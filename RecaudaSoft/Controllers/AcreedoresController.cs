using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;

namespace RecaudaSoft.Controllers
{
    public class AcreedoresController : Controller
    {
        //
        // GET: /Acreedores/

        public ActionResult Index()
        {
            using (var db = new CobranzasEntities())
            {
                var listaAcreedores = db.Acreedors.Include("Parametro");
                return View(listaAcreedores.ToList());
            }
        }

        //
        // GET: /Acreedores/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Acreedores/Create

        public ActionResult Create()
        {
            using (var db = new CobranzasEntities())
            {
                ViewBag.rubro = new SelectList(db.Parametroes.Where(p => p.tipo == "RUBRO_ACREEDOR"), "idParametro", "valor").ToList();
                return View();
            }
        } 

        //
        // POST: /Acreedores/Create

        [HttpPost]
        public ActionResult Create(Acreedor acreedor)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    db.Acreedors.Add(acreedor);
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
        // GET: /Acreedores/Edit/5
 
        public ActionResult Edit(int id)
        {
            using (var db = new CobranzasEntities())
            {
                var listaAcreedores = db.Acreedors.Include("Parametro");
                Acreedor acreedor = listaAcreedores.First(a => a.idAcreedor == id);

                ViewBag.rubro = new SelectList(db.Parametroes.Where(p => p.tipo == "RUBRO_ACREEDOR"), "idParametro", "valor", acreedor.rubro).ToList();

                return View(acreedor);
            }
        }

        //
        // POST: /Acreedores/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Acreedor acreedor)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    db.Entry(acreedor).State = System.Data.EntityState.Modified;
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
        // GET: /Acreedores/Delete/5
 
        public ActionResult Delete(int id)
        {
            using (var db = new CobranzasEntities())
            {
                return View(db.Acreedors.Include("Parametro").First(a => a.idAcreedor == id));
            }
        }

        //
        // POST: /Acreedores/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Acreedor acreedor)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    db.Entry(acreedor).State = System.Data.EntityState.Deleted;
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
