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
    
    public partial class Habitacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Habitacion()
        {
            this.Detalle_Habitacion = new HashSet<Detalle_Habitacion>();
        }
    
        public int hab_id { get; set; }
        [DisplayName("Tipo")]
        [Required]
        public string hab_nombre { get; set; }
        [DisplayName("Camas")]
        [Required]
        public Nullable<int> hab_numero_camas { get; set; }
        [DisplayName("Baños")]
        [Required]
        public Nullable<int> hab_numero_banos { get; set; }
        [DisplayName("Tiene Telefono")]
        [Required]
        public Nullable<bool> hab_telefono { get; set; }
        [DisplayName("Descripción")]
        [Required]
        public string hab_descripcion { get; set; }
        [DisplayName("Observación")]
        public string hab_observacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Habitacion> Detalle_Habitacion { get; set; }
    }
}
