using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;

namespace RecaudaSoft.Controllers
{
    public class CargaCarterasController : Controller
    {
        //
        // GET: /CargaCarteras/

        public ActionResult Index()
        {
            using (var db = new CobranzasEntities())
            {
                var listaCarteras = db.Carteras.Include("Acreedor");
                listaCarteras = listaCarteras.Include("Parametro");
                return View(listaCarteras.ToList());
            }
        }

        //
        // GET: /CargaCarteras/SubirArchivo/5

        public ActionResult SubirArchivo(int id)
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

        [HttpPost]
        public ActionResult SubirArchivo(HttpPostedFileBase excelFile)
        {
            if (excelFile != null)
            {
                //Save the uploaded file to the disc.
                string savedFileName = "~/UploadedExcelDocuments/" + excelFile.FileName;
                excelFile.SaveAs(Server.MapPath(savedFileName));

                //Create a connection string to access the Excel file using the ACE provider.
                //This is for Excel 2007. 2003 uses an older driver.

                var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;", Server.MapPath(savedFileName));
                
                //Fill the dataset with information from the Hoja1 worksheet.
                /*
                var adapter = new OleDbDataAdapter("SELECT * FROM [Hoja1$]", connectionString);
                var ds = new DataSet();
                adapter.Fill(ds, "results");
                DataTable data = ds.Tables["results"];

                //Create a new list of People.
                var people = new List<Person>();
                for (int i = 0; i < data.Rows.Count - 1; i++)
                {
                    Person newPerson = new Person();
                    newPerson.Id = data.Rows[i].Field<double?>("Id");
                    newPerson.Name = data.Rows[i].Field<string>("Name");
                    newPerson.LastName = data.Rows[i].Field<string>("LastName");
                    newPerson.DateOfBirth = data.Rows[i].Field<DateTime?>("DateOfBirth");                   
                    people.Add(newPerson);
                }
                */
                return View("ProcesarArchivoExitoso");
            }
            return View();
        }

        //
        // GET: /CargaCarteras/ProcesarArchivoExitoso

        public ActionResult ProcesarArchivoExitoso()
        {
            return View();
        } 


        //
        // GET: /CargaCarteras/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /CargaCarteras/Create

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
        // GET: /CargaCarteras/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CargaCarteras/Edit/5

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
        // GET: /CargaCarteras/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CargaCarteras/Delete/5

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
