using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;

namespace RecaudaSoft.Controllers
{
    public class CarterasController : Controller
    {
        //
        // GET: /Carteras/

        public ActionResult Index()
        {
            using (var db = new CobranzasEntities())
            {
                var listaCarteras = db.Carteras.Include("Acreedor");
                listaCarteras = listaCarteras.Include("Parametro");
                return View(listaCarteras.ToList());
                //return View(db.Carteras.Include("Acreedor").ToList());
            }
        }

        //
        // GET: /Carteras/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Carteras/Create

        public ActionResult Create()
        {
            using (var db = new CobranzasEntities())
            {
                ViewBag.esVencida = new SelectList(db.Parametroes.Where(p => p.tipo == "TIPO_CARTERA"), "idParametro", "valor").ToList();
                ViewBag.idAcreedor = new SelectList(db.Acreedors, "idAcreedor", "nombre").ToList();
                return View();
            }
        }

        //
        // POST: /Carteras/Create

        [HttpPost]
        public ActionResult Create(Cartera cartera)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    db.Carteras.Add(cartera);
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
        // GET: /Carteras/Edit/5
 
        public ActionResult Edit(int id)
        {
            using (var db = new CobranzasEntities())
            {
                return View(db.Carteras.Find(id));
            }
        }

        //
        // POST: /Carteras/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Cartera cartera)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    db.Entry(cartera).State = System.Data.EntityState.Modified;
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
        // GET: /Carteras/Delete/5
 
        public ActionResult Delete(int id)
        {
            using (var db = new CobranzasEntities())
            {
                return View(db.Carteras.Find(id));
            }
        }

        //
        // POST: /Carteras/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Cartera cartera)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    db.Entry(cartera).State = System.Data.EntityState.Deleted;
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
