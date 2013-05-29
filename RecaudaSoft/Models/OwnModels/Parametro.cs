using System.ComponentModel;

namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ParametroMetaData))]
    public partial class Parametro { }

    public class ParametroMetaData
    {
        [DisplayName("Id")]
        public int idParametro { get; set; }
        [DisplayName("Tipo")]
        public string tipo { get; set; }
        [DisplayName("Valor")]
        public string valor { get; set; }
        [DisplayName("Valor Numérico")]
        public Nullable<decimal> valorNum { get; set; }
        [DisplayName("Id Padre")]
        public Nullable<int> idPadre { get; set; }
        [DisplayName("Código único")]   
        public string codUnico { get; set; }

        public virtual ICollection<Acreedor> Acreedors { get; set; }
        public virtual ICollection<Actividad> Actividads { get; set; }
        public virtual ICollection<Cartera> Carteras { get; set; }
        public virtual ICollection<Deuda> Deudas { get; set; }
        public virtual ICollection<Deudor> Deudors { get; set; }
        public virtual ICollection<Deudor> Deudors1 { get; set; }
        public virtual ICollection<Deudor> Deudors2 { get; set; }
        public virtual ICollection<Gestor> Gestors { get; set; }
        public virtual ICollection<Gestor> Gestors1 { get; set; }
        public virtual ICollection<Gestor> Gestors2 { get; set; }
        public virtual ICollection<Refinanciacion> Refinanciacions { get; set; }
        public virtual ICollection<Deuda> Deudas1 { get; set; }
    }
}
