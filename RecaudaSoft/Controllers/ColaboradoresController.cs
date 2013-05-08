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
                return View(db.Gestors.ToList());
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
            return View();
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
                return View(db.Gestors.Find(id));
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
                return View(db.Gestors.Find(id));
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
