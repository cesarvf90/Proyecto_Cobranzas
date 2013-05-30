using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecaudaSoft.Models;
using RecaudaSoft.ViewModels;

namespace RecaudaSoft.Utils
{
    public class AlgoritmoAsignacion
    {

        public void asignarActividades(ModeloAsignacion asignacion)
        {
            using (var db = new CobranzasEntities())
            {
                // Se crea una lista de deudas por cada tipo de actividad
                List<Deuda> deudasLlamada = new List<Deuda>();
                List<Deuda> deudasCorreo = new List<Deuda>();
                List<Deuda> deudasCorrespondencia = new List<Deuda>();
                List<Deuda> deudasVisita = new List<Deuda>();

                for (int i = 0; i < asignacion.carteras.Count; i++)
                {
                    Cartera cartera = asignacion.carteras.ElementAt(i);

                    // obtener politica de cobranza de la cartera
                    PoliticaCobranza politicaCobranza = cartera.PoliticaCobranzas.First();
                    // obtener tipo de actividad que corresponde a ejecutar segun la politica en la fecha actual
                    TipoActividad tipoActividadCartera = db.PoliticaCobranzaXTipoActividads.Include("TipoActividad").Include("PoliticaCobranza").First(p => p.idPoliticaCobranza == politicaCobranza.idPoliticaCobranza && (DateTime.Compare(p.fechaInicio, DateTime.Today) <= 0) && (DateTime.Compare(DateTime.Today, p.fechaFin) <= 0)).TipoActividad;

                    List<Deuda> deudasCarteraCalificadas = new List<Deuda>();

                    foreach (Deuda deuda in cartera.Deudas)
                    {
                        // calificar deuda y asignar dificultad
                        calificarDeuda(deuda);
                        deudasCarteraCalificadas.Add(deuda);
                    }

                    // se aniaden las deudas de esa cartera a las del tipo de actividad que corresponden
                    switch (tipoActividadCartera.nombre)
                    {
                        case "Llamada telefónica": deudasLlamada.AddRange(deudasCarteraCalificadas); break;
                        case "Envío correo": deudasCorreo.AddRange(deudasCarteraCalificadas); break;
                        case "Envío correspondencia": deudasCorrespondencia.AddRange(deudasCarteraCalificadas); break;
                        case "Visita": deudasVisita.AddRange(deudasCarteraCalificadas); break;
                    }

                }

                foreach (Gestor gestor in asignacion.gestores)
                {
                    // calificar gestor y asignar potencial
                    calificarGestor(gestor);
                }

                // Se ordena deudas en orden decreciente por dificultad (de la mas dificil a la mas facil)
                deudasLlamada = deudasLlamada.OrderByDescending(d => d.dificultad).ToList();
                deudasCorreo = deudasCorreo.OrderByDescending(d => d.dificultad).ToList();
                deudasCorrespondencia = deudasCorrespondencia.OrderByDescending(d => d.dificultad).ToList();
                deudasVisita = deudasVisita.OrderByDescending(d => d.dificultad).ToList();
                
                Dictionary<string, List<Deuda>> mapaDeudas = new Dictionary<string, List<Deuda>>();
                mapaDeudas.Add("0", deudasLlamada);
                mapaDeudas.Add("1", deudasCorreo);
                mapaDeudas.Add("2", deudasCorrespondencia);
                mapaDeudas.Add("3", deudasVisita);

                Dictionary<string, string> mapaTiposGestores = new Dictionary<string, string>();
                mapaTiposGestores.Add("0", "Gestor Telefónico");
                mapaTiposGestores.Add("1", "Gestor Correspondencia");
                mapaTiposGestores.Add("2", "Gestor Visitador");
                mapaTiposGestores.Add("3", "Gestor Correo");

                // Se ordena gestores en orden decreciente por potencial (del mas experimentado al menos experimentado)
                asignacion.gestores = asignacion.gestores.OrderByDescending(g => g.potencial).ToList();

                // Realizo la asignacion basado en el tipo de actividad segun la politica de cobranza
                DateTime fechaActual = DateTime.Today;
                List<Gestor> gestoresPorTipo = new List<Gestor>();
                int deudasPorGestor;
                List<GestorXDeuda> listaAsignaciones = new List<GestorXDeuda>();

                // Se recorre y se realiza la asignacion tomando en cuenta el bolso de deudas correspondientes a cada tipo de actividad
                // y los gestores especializados en realizar ese tipo de actividades
                for (int i = 0; i < 4; i++)
                {
                    List<Deuda> deudas = mapaDeudas[i.ToString()];
                    foreach (Deuda deuda in deudas)
                    {
                        gestoresPorTipo = asignacion.gestores.Where(g => g.Parametro2.valor == mapaTiposGestores[i.ToString()]).ToList();
                        deudasPorGestor = deudas.Count / gestoresPorTipo.Count;

                        // Estos dos parametros se usan para repartir las deudas que sobren porque la distribucion no siempre sera proporcional
                        int sobranteDeudasPrimerGestor = deudas.Count - deudasPorGestor * gestoresPorTipo.Count;
                        bool seAsignoSobrantes = false;
                        GestorXDeuda gestorXDeuda;

                        foreach (Gestor gestor in gestoresPorTipo)
                        {
                            // Se le asignan las deudas correspondientes al gestor
                            for (int j = 0; j < deudasPorGestor; ++j)
                            {
                                gestorXDeuda = new GestorXDeuda();
                                gestorXDeuda.idGestor = gestor.idGestor;
                                gestorXDeuda.idDeuda = deudas.ElementAt(j).idDeuda;
                                gestorXDeuda.fechaAsignacion = fechaActual;
                                gestorXDeuda.exito = 0;
                                db.GestorXDeudas.Add(gestorXDeuda);
                                db.SaveChanges();
                                listaAsignaciones.Add(gestorXDeuda);
                            }
                            deudas.RemoveRange(0, deudasPorGestor);

                            // Se le asignan las deudas sobrantes al primero porque es el que tiene mayor experiencia
                            if (!seAsignoSobrantes)
                            {
                                for (int k = 0; k < sobranteDeudasPrimerGestor; ++k)
                                {
                                    gestorXDeuda = new GestorXDeuda();
                                    gestorXDeuda.idGestor = gestor.idGestor;
                                    gestorXDeuda.idDeuda = deudas.ElementAt(k).idDeuda;
                                    gestorXDeuda.fechaAsignacion = fechaActual;
                                    gestorXDeuda.exito = 0;
                                    db.GestorXDeudas.Add(gestorXDeuda);
                                    db.SaveChanges();
                                    listaAsignaciones.Add(gestorXDeuda);
                                }
                                deudas.RemoveRange(0, sobranteDeudasPrimerGestor);
                                seAsignoSobrantes = true;
                            }
                        }
                    }
                }

                asignacion.gestoresXdeudas = listaAsignaciones;
            }
        }

        public void calificarDeuda(Deuda deuda)
        {
            decimal dificultad = 1;
            using (var db = new CobranzasEntities())
            {
                List<Dato> parametrosDeuda = db.Datoes.Include("CalificacionDatoes").Where(p => p.tipo == "Deudor").ToList();
                foreach (Dato parametroDeuda in parametrosDeuda)
                {
                    // Se califica la deuda respecto a si el deudor posee trabajo
                    if (parametroDeuda.nombre == "TIENE_TRABAJO")
                    {
                        if (deuda.Deudor.poseeTrabajo == 1)
                        {
                            dificultad = dificultad * parametroDeuda.CalificacionDatoes.First(c => c.valorDato == "Sí" && c.idDato == parametroDeuda.idDato).valorCalificacion;
                        }
                        else
                        {
                            dificultad = dificultad * parametroDeuda.CalificacionDatoes.First(c => c.valorDato == "No" && c.idDato == parametroDeuda.idDato).valorCalificacion;
                        }
                    }

                    // Se califica la deuda respecto a si el deudor posee otras deudas
                    if (parametroDeuda.nombre == "OTRAS_DEUDAS")
                    {
                        if (deuda.Deudor.numeroTotalDeudas > 1)
                        {
                            dificultad = dificultad * parametroDeuda.CalificacionDatoes.First(c => c.valorDato == "Sí" && c.idDato == parametroDeuda.idDato).valorCalificacion;
                        }
                        else
                        {
                            dificultad = dificultad * parametroDeuda.CalificacionDatoes.First(c => c.valorDato == "No" && c.idDato == parametroDeuda.idDato).valorCalificacion;
                        }
                    }

                    // Se califica la deuda en base al producto de la misma
                    if (parametroDeuda.nombre == "PRODUCTO_DEUDA")
                    {
                        dificultad = dificultad * parametroDeuda.CalificacionDatoes.First(c => c.valorDato == deuda.Parametro1.valor && c.idDato == parametroDeuda.idDato).valorCalificacion;
                    }

                    // Se califica la deuda de acuerdo a la escala en que se encuentre el valor de su monto
                    if (parametroDeuda.nombre == "MONTO")
                    {
                        dificultad = dificultad * parametroDeuda.CalificacionDatoes.First(c => c.valorDatoMinimo <= deuda.monto && c.valorDatoMaximo > deuda.monto && c.idDato == parametroDeuda.idDato).valorCalificacion;
                    }

                    // Se califica la deuda de acuerdo a la antiguedad de la misma
                    if (parametroDeuda.nombre == "ANTIGUEDAD_DIAS")
                    {
                        TimeSpan timeSpan = (TimeSpan) (DateTime.Today - deuda.fechaInicio);
                        int antiguedad = timeSpan.Days;
                        dificultad = dificultad * parametroDeuda.CalificacionDatoes.First(c => c.valorDatoMinimo <= antiguedad && c.valorDatoMaximo > antiguedad && c.idDato == parametroDeuda.idDato).valorCalificacion;
                    }

                    // Se califica la deuda de acuerdo al estado civil del deudor
                    if (parametroDeuda.nombre == "ESTADO_CIVIL")
                    {
                        dificultad = dificultad * parametroDeuda.CalificacionDatoes.First(c => c.valorDato == deuda.Deudor.Parametro.valor && c.idDato == parametroDeuda.idDato).valorCalificacion;
                    }
                }
                deuda.dificultad = dificultad;
            }
        }

        public void calificarGestor(Gestor gestor)
        {
            decimal potencial = 1;
            using (var db = new CobranzasEntities())
            {
                List<Dato> parametrosGestor = db.Datoes.Include("CalificacionDatoes").Where(p => p.tipo == "Gestor").ToList();
                foreach (Dato parametroGestor in parametrosGestor)
                {
                    // Se califica al gestor de acuerdo al tiempo de experiencia que posee en la empresa
                    if (parametroGestor.nombre == "TIEMPO_EXPERIENCIA")
                    {
                        TimeSpan timeSpan = (TimeSpan)(DateTime.Today - gestor.fechaIngreso);
                        int mesesExperiencia = (timeSpan.Days)/30;
                        potencial = potencial * parametroGestor.CalificacionDatoes.First(c => c.valorDatoMinimo <= mesesExperiencia && c.valorDatoMaximo > mesesExperiencia && c.idDato == parametroGestor.idDato).valorCalificacion;
                    }

                    // Se califica al gestor de acuerdo al nivel de su cargo actual en la empresa
                    if (parametroGestor.nombre == "NIVEL_GESTOR")
                    {
                        potencial = potencial * parametroGestor.CalificacionDatoes.First(c => c.valorDato == gestor.Parametro.valor && c.idDato == parametroGestor.idDato).valorCalificacion;
                    }

                    // Se califica al gestor en base a la cantidad de deudas que ya ha recuperado trabajando para la empresa
                    if (parametroGestor.nombre == "DEUDAS_RECUPERADAS")
                    {
                        potencial = potencial * parametroGestor.CalificacionDatoes.First(c => c.valorDatoMinimo <= gestor.deudasRecuperadas && c.valorDatoMaximo > gestor.deudasRecuperadas && c.idDato == parametroGestor.idDato).valorCalificacion;
                    }
                }
                gestor.potencial = potencial;
            }
        }
    }
}