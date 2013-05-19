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
            return View();
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
