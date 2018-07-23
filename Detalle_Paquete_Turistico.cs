//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pry_Agencia_Viajes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public partial class Detalle_Paquete_Turistico
    {
        public int dptu_id { get; set; }
        [Required]
        public int ptu_id { get; set; }
        [Required]
        public int act_id { get; set; }
        
        [Required]
        public int tra_id { get; set; }
        [DisplayName("Estado")]
        public Nullable<bool> dptu_etado { get; set; }
        [DisplayName("Observación")]
        [Required]
        public string dptu_observacion { get; set; }

        //Costo por persona
        public Nullable<decimal> dptu_costo_por_persona { get; set; }

        public virtual Actividad Actividad { get; set; }
        public virtual Paquete_Turistico Paquete_Turistico { get; set; }
        public virtual Transporte Transporte { get; set; }
    }
}
