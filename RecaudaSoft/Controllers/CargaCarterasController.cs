using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;
using System.Data;
using System.Data.OleDb;
using RecaudaSoft.Utils;

namespace RecaudaSoft.Controllers
{
    public class CargaCarterasController : Controller
    {

        int idCarteraSeleccionada;

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
                idCarteraSeleccionada = id;

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
            using (var db = new CobranzasEntities()) {
                if (excelFile != null)
                {
                    //Save the uploaded file to the disc.
                    string savedFileName = "~/UploadedExcelDocuments/" + excelFile.FileName;
                    excelFile.SaveAs(Server.MapPath(savedFileName));

                    //Create a connection string to access the Excel file using the ACE provider.
                    //This is for Excel 2007. 2003 uses an older driver.

                    var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;", Server.MapPath(savedFileName));
                
                    // Leer informacion de la cartera

                    // Leer una por una 
                
                    // las deudas 
                    // los deudores asociados a las mismas
                    // insertar la deuda en la BD
                    // insertar el deudor en la BD

                    //Fill the dataset with information from the Hoja1 worksheet.
                
                    // TODO cambiar hoja1 por un nombre mas significativo
                    var adapter = new OleDbDataAdapter("SELECT * FROM [Hoja1$]", connectionString);
                
                    var ds = new DataSet();
                    adapter.Fill(ds, "results");
                    DataTable data = ds.Tables["results"];

                    // TODO mejorar para que pueda leer nulos luego si es necesario haciendo cambios a la BD
                    var listaDeudas = new List<Deuda>();
                    for (int i = 0; i < data.Rows.Count - 1; i++)
                    {
                        //data.Rows[fila][columna]
                        Deuda deuda = new Deuda();
                        string productoDeuda = data.Rows[i].Field<string>("Producto");
                        deuda.idProducto = db.Parametroes.First(p => p.tipo == "PRODUCTO_DEUDA" && p.valor == productoDeuda).idParametro;
                        double montoDouble = data.Rows[i].Field<double>("Monto");
                        deuda.monto = Convert.ToDecimal(montoDouble);
                        string valorMoneda = data.Rows[i].Field<string>("Moneda");
                        deuda.moneda = db.Parametroes.First(p => p.tipo == "MONEDA" && p.codUnico == valorMoneda).idParametro;
                        //deuda.Parametro = moneda; //TODO evaluar si es necesaria esta linea
                        string esCuota = data.Rows[i].Field<string>("Es Cuota");
                        if (esCuota == "Sí") {
                            deuda.esCuota = 1;
                        } else if (esCuota == "No") {
                            deuda.esCuota = 0;
                        }

                        // Se aniaden los datos propios de todas las deudas de la cartera procesada
                        deuda.fechaInicio = DateTime.Today;
                        deuda.idCartera = idCarteraSeleccionada;

                        listaDeudas.Add(deuda);
                        db.Deudas.Add(deuda);
                        db.SaveChanges();
                    }

                    return View("ProcesarArchivoExitoso");
                }
                return View();
            }
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
