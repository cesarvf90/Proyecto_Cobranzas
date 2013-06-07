using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecaudaSoft.Models;

namespace RecaudaSoft.ViewModels
{
    public class FiltroReporteActividad
    {
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public int nivelGestor { get; set; }
        public int tipoGestor { get; set; }
        public TipoActividad tipoActividad { get; set; }
        public int resultadoActividad { get; set; }
    }
}