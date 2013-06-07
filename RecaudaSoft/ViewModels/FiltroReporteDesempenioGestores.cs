using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecaudaSoft.Models;

namespace RecaudaSoft.ViewModels
{
    public class FiltroReporteDesempenioGestores
    {
        public int idGestor { get; set; }
        public int tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public int nivelGestor { get; set; }
        public int tipoGestor { get; set; }
        public string nombreGestor { get; set; }
        public string apellidoPaternoGestor { get; set; }
        public string apellidoMaternoGestor { get; set; }
    }
}