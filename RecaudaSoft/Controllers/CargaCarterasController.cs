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

        public static int idCarteraSeleccionada { get; set; }

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
                    //Guarda el archivo subido en el disco del servidor
                    string savedFileName = "~/UploadedExcelDocuments/" + excelFile.FileName;
                    excelFile.SaveAs(Server.MapPath(savedFileName));

                    // Crea una cadena de conexion para acceder al archivo Excel usando using ACE provider.
                    // Esto es para Excel 2007. Usuarios del 2003 usan un driver mas antiguo.

                    var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;", Server.MapPath(savedFileName));
                
                    // Leer informacion de la cartera

                    // Leer una por una 

                    // lee el deudor de la deuda
                    // lee su respectiva deuda
                    // insertar el deudor en la BD
                    // insertar la deuda en la BD (Fk del deudor)

                    // TODO cambiar hoja1 por un nombre mas significativo
                    var adapter = new OleDbDataAdapter("SELECT * FROM [Hoja1$]", connectionString);
                
                    var ds = new DataSet();
                    adapter.Fill(ds, "results");
                    DataTable data = ds.Tables["results"];

                    // TODO mejorar para que pueda leer nulos luego si es necesario haciendo cambios a la BD
                    //var listaDeudas = new List<Deuda>();
                    //var listaDeudores = new List<Deudor>();
                    bool deudorExiste = false;
                    Deudor deudor = null;
                    Deuda deuda;

                    // TODO validar el final del for para no leer lineas en vano y no perder tiempo
                    for (int fila = 1; fila < data.Rows.Count - 1; fila++)
                    {
                        if ((fila % 2) != 0)
                        {
                            // Se lee el deudor
                            deudor = new Deudor();
                            deudor.nombres = data.Rows[fila].Field<string>(FormatoDeudor.Nombres);
                            deudor.apellidoPaterno = data.Rows[fila].Field<string>(FormatoDeudor.Apellido_Paterno);
                            deudor.apellidoMaterno = data.Rows[fila].Field<string>(FormatoDeudor.Apellido_Materno);
                            string cadenaTipoDocumento = data.Rows[fila].Field<string>(FormatoDeudor.Tipo_Documento);
                            deudor.tipoDocumento = db.Parametroes.First(p => p.tipo == "TIPO_DOCUMENTO" && p.valor == cadenaTipoDocumento).idParametro;
                            deudor.numeroDocumento = data.Rows[fila].Field<string>(FormatoDeudor.Numero_Documento);
                            deudor.telefonoPersonal = data.Rows[fila].Field<string>(FormatoDeudor.Telefono_Personal);
                            deudor.telefonoDomicilio = data.Rows[fila].Field<string>(FormatoDeudor.Telefono_Domicilio);
                            deudor.telefonoTrabajo = data.Rows[fila].Field<string>(FormatoDeudor.Telefono_Trabajo);
                            deudor.correo = data.Rows[fila].Field<string>(FormatoDeudor.Correo);
                            deudor.direccion = data.Rows[fila].Field<string>(FormatoDeudor.Direccion);
                            string poseeTrabajo = data.Rows[fila].Field<string>(FormatoDeudor.Posee_Trabajo);
                            if (poseeTrabajo == "Sí")
                            {
                                deudor.poseeTrabajo = 1;
                            }
                            else if (poseeTrabajo == "No")
                            {
                                deudor.poseeTrabajo = 0;
                            }
                            deudor.fechaNacimiento = data.Rows[fila].Field<DateTime>(FormatoDeudor.Fecha_Nacimiento);
                            string cadenaEstadoCivil = data.Rows[fila].Field<string>(FormatoDeudor.Estado_Civil);
                            deudor.estadoCivil = db.Parametroes.First(p => p.tipo == "ESTADO_CIVIL" && p.valor == cadenaEstadoCivil).idParametro;
                            string cadenaNumeroHijos = data.Rows[fila].Field<string>(FormatoDeudor.Numero_Hijos);
                            deudor.numeroHijos = Convert.ToInt32(cadenaNumeroHijos);
                            string cadenaSexo = data.Rows[fila].Field<string>(FormatoDeudor.Sexo);
                            deudor.sexo = db.Parametroes.First(p => p.tipo == "SEXO" && p.valor == cadenaSexo).idParametro;
                            deudor.detalles = data.Rows[fila].Field<string>(FormatoDeudor.Detalles);

                            // Se valida si el deudor ya existe en la BD
                            Deudor deudorExistente = db.Deudors.FirstOrDefault(d => d.tipoDocumento == deudor.tipoDocumento && d.numeroDocumento == deudor.numeroDocumento);
                            if (deudorExistente == null)
                            {
                                deudorExiste = false;
                            }
                            else
                            {
                                deudorExiste = true;
                                // Si el deudor existe se deben actualizar los datos que se estan actualizando 
                                // por eso se "sobreescribe" usando su id
                                deudor.idDeudor = deudorExistente.idDeudor;
                            }

                        }
                        else
                        {
                            // Se lee la deuda del deudor
                            deuda = new Deuda();
                            string productoDeuda = data.Rows[fila].Field<string>(FormatoDeuda.Producto);
                            deuda.idProducto = db.Parametroes.First(p => p.tipo == "PRODUCTO_DEUDA" && p.valor == productoDeuda).idParametro;
                            string cadenaMonto = data.Rows[fila].Field<string>(FormatoDeuda.Monto);
                            deuda.monto = Convert.ToDecimal(cadenaMonto);
                            string valorMoneda = data.Rows[fila].Field<string>(FormatoDeuda.Moneda);
                            deuda.moneda = db.Parametroes.First(p => p.tipo == "MONEDA" && p.codUnico == valorMoneda).idParametro;
                            string esCuota = data.Rows[fila].Field<string>(FormatoDeuda.Es_Cuota);
                            if (esCuota == "Sí")
                            {
                                deuda.esCuota = 1;
                            }
                            else if (esCuota == "No")
                            {
                                deuda.esCuota = 0;
                            }

                            // Se aniaden los datos propios de todas las deudas de la cartera procesada
                            deuda.fechaInicio = DateTime.Today;
                            deuda.idCartera = idCarteraSeleccionada;

                            if (!deudorExiste)
                            { // Si el deudor no existe se inserta en la BD
                                deudor.numeroTotalDeudas = 1;
                                // TODO convertir a soles el total adeudado a asignar
                                deudor.totalAdeudado = deuda.monto;
                                db.Deudors.Add(deudor);
                                db.SaveChanges();
                            }
                            else
                            { // Si el deudor ya existe en la BD entonces se actualiza su numero total de deudas y el total adeudado
                                //int numeroTotalDeudas = deudorExistente.numeroTotalDeudas;
                                deudor.numeroTotalDeudas += 1;
                                // TODO convertir a soles el total adeudado a asignar
                                deudor.totalAdeudado += deuda.monto;
                                db.Entry(deudor).State = System.Data.EntityState.Modified;
                                db.SaveChanges();
                            }

                            // Se relaciona la deuda con el deudor
                            deuda.idDeudor = deudor.idDeudor;

                            db.Deudas.Add(deuda);
                            db.SaveChanges();
                        }
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
