using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;

namespace RecaudaSoft.Controllers
{
    public class UsuariosController : Controller
    {
        //
        // GET: /Usuarios/

        public ActionResult Index()
        {
            using (var db = new CobranzasEntities())
            {
                return View(db.Usuarios.ToList());
            }
        }

        //
        // GET: /Usuarios/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Usuarios/Create

        public ActionResult Create()
        {
            using (var db = new CobranzasEntities())
            {
                ViewBag.idGestor = new SelectList(db.Gestors, "idGestor", "nombres").ToList();
                ViewBag.idAcreedor = new SelectList(db.Acreedors, "idAcreedor", "nombre").ToList();
                ViewBag.idRol = new SelectList(db.Rols, "idRol", "nombre").ToList();
                return View();
            }
        } 

        //
        // POST: /Usuarios/Create

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    db.Usuarios.Add(usuario);
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
        // GET: /Usuarios/Edit/5
 
        public ActionResult Edit(int id)
        {
            using (var db = new CobranzasEntities())
            {
                return View(db.Usuarios.Find(id));
            }
        }

        //
        // POST: /Usuarios/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Usuario usuario)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    db.Entry(usuario).State = System.Data.EntityState.Modified;
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
        // GET: /Usuarios/Delete/5
 
        public ActionResult Delete(int id)
        {
            using (var db = new CobranzasEntities())
            {
                return View(db.Usuarios.Find(id));
            }
        }

        //
        // POST: /Usuarios/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Usuario usuario)
        {
            try
            {
                using (var db = new CobranzasEntities())
                {
                    db.Entry(usuario).State = System.Data.EntityState.Deleted;
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
