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
                return View(db.Acreedors.ToList());
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
            return View();
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
                return View(db.Acreedors.Find(id));
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
                return View(db.Acreedors.Find(id));
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
