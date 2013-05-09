using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;

namespace RecaudaSoft.Controllers
{
    public class RolesController : Controller
    {
        //
        // GET: /Roles/

        public ActionResult Index()
        {
            using (var db = new CobranzasEntities())
            {
                return View(db.Rols.ToList());
            }
        }

        //
        // GET: /Roles/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Roles/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Roles/Create

        [HttpPost]
        public ActionResult Create(Rol rol)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    db.Rols.Add(rol);
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
        // GET: /Roles/Edit/5
 
        public ActionResult Edit(int id)
        {
            using (var db = new CobranzasEntities())
            {
                return View(db.Rols.Find(id));
            }
        }

        //
        // POST: /Roles/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Rol rol)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    db.Entry(rol).State = System.Data.EntityState.Modified;
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
        // GET: /Roles/Delete/5
 
        public ActionResult Delete(int id)
        {
            using (var db = new CobranzasEntities())
            {
                return View(db.Rols.Find(id));
            }
        }

        //
        // POST: /Roles/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Rol rol)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    db.Entry(rol).State = System.Data.EntityState.Deleted;
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
