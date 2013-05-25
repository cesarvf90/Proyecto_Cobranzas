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
            double dificultad = 1;
            using (var db = new CobranzasEntities())
            {
                List<Dato> parametrosDeuda = db.Datoes.Include("CalificacionDatoes").Where(p => p.tipo == "Deudor").ToList();
                foreach (Dato parametroDeuda in parametrosDeuda)
                {
                    // Se califica si el deudor tiene otras deudas
                    if (parametroDeuda.nombre == "OTRAS_DEUDAS")
                    {
                        if (deuda.Deudor.numeroTotalDeudas > 1)
                        {
                            //dificultad *= parametroDeuda.CalificacionDatoes.First(c => c.valorDato == "Sí").valorCalificacion;
                        }
                        else
                        {
                            //dificultad *= parametroDeuda.CalificacionDatoes.First(c => c.valorDato == "No").valorCalificacion;
                        }
                    }

                    // Se califica si el deudor tiene trabajo
                    if (parametroDeuda.nombre == "TIENE_TRABAJO")
                    {
                        if (deuda.Deudor.numeroTotalDeudas > 1)
                        {
                            //dificultad *= parametroDeuda.CalificacionDatoes.First(c => c.valorDato == "Sí").valorCalificacion;
                        }
                        else
                        {
                            //dificultad *= parametroDeuda.CalificacionDatoes.First(c => c.valorDato == "No").valorCalificacion;
                        }
                    }
                }
            }
        }

        public void calificarGestor(Gestor gestor)
        {
        }
    }
}