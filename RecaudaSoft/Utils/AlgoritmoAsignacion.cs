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
            for (int i = 0; i < asignacion.carteras.Count; i++)
            {
                Cartera cartera = asignacion.carteras.ElementAt(i);
                // obtener politica de cobrana de la cartera

                foreach (Deuda deuda in cartera.Deudas)
                {
                    // calificar deuda y asignar calificacion
                    calificarDeuda(deuda);
                }

            }

            foreach (Gestor gestor in asignacion.gestores)
            {
                // califico gestores y asigno calificacion
                calificarGestor(gestor);

            }

            // Realizo la asignacion basado en el tipo de actividad segun la politica de cobranza

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

                    // Se califica la deuda de acuerdo a la antiguedad de la misma
                    if (parametroDeuda.nombre == "ESTADO_CIVIL")
                    {
                        dificultad = dificultad * parametroDeuda.CalificacionDatoes.First(c => c.valorDato == deuda.Deudor.Parametro.valor && c.idDato == parametroDeuda.idDato).valorCalificacion;
                    }
                }
            }
        }

        public void calificarGestor(Gestor gestor)
        {
        }
    }
}