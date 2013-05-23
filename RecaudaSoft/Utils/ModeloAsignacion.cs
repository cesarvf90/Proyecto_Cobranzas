using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecaudaSoft.Models;

namespace RecaudaSoft.Utils
{
    public class ModeloAsignacion
    {
        public IEnumerable<Cartera> carteras { get; set; }
        public IEnumerable<Gestor> gestores{ get; set; }

    }
}
