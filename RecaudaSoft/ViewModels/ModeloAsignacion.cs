using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;

namespace RecaudaSoft.ViewModels
{
    public class ModeloAsignacion
    {
        //public IEnumerable<Cartera> carteras { get; set; }
        public List<Cartera> carteras { get; set; }
        public List<Gestor> gestores { get; set; }
        public List<GestorXDeuda> gestoresXdeudas { get; set; }
        public int valor { get; set; }
    }

    public class CheckCartera
    {
        public Cartera cartera { get; set; }
        public bool Checked { get; set; }
    }

    public class CheckGestor
    {
        public Gestor gestor { get; set; }
        public bool Checked { get; set; }
    }
}
