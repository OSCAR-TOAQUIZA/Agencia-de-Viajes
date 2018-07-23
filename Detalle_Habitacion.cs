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
    
    public partial class Detalle_Habitacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Detalle_Habitacion()
        {
            this.Paquete_Turistico = new HashSet<Paquete_Turistico>();
        }
    
        public int dha_id { get; set; }
        [Required]
        public int hot_id { get; set; }
        [Required]
        public int hab_id { get; set; }
        [DisplayName("Costo por Noche")]
        [Required]
        public Nullable<decimal> dha_costo { get; set; }
        [DisplayName("Observación")]
        [Required]
        public string dha_observacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paquete_Turistico> Paquete_Turistico { get; set; }
        public virtual Habitacion Habitacion { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
