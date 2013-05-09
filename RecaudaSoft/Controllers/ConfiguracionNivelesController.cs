using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecaudaSoft.Controllers
{
    public class ConfiguracionNivelesController : Controller
    {
        //
        // GET: /ConfiguracionNiveles/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /ConfiguracionNiveles/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ConfiguracionNiveles/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ConfiguracionNiveles/Create

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
        // GET: /ConfiguracionNiveles/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ConfiguracionNiveles/Edit/5

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
        // GET: /ConfiguracionNiveles/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ConfiguracionNiveles/Delete/5

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
