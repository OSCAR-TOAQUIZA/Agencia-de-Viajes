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

    public partial class Transporte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transporte()
        {
            this.Detalle_Paquete_Turistico = new HashSet<Detalle_Paquete_Turistico>();
        }

        public int tra_id { get; set; }
        [DisplayName("Tipo/Nombre")]
        [Required]
        public string tra_tipo_transporte { get; set; }
        [DisplayName("Costo")]
        [Required]
        public Nullable<decimal> tra_costo { get; set; }
        [DisplayName("Origen")]
        [Required]
        public string tra_origen { get; set; }
        [DisplayName("Destino")]
        [Required]
        public string tra_destino { get; set; }
        [DisplayName("Hora Salida")]
        [Required]
        public Nullable<System.TimeSpan> tra_hora_salida { get; set; }
        [DisplayName("Hora Llegada")]
        [Required]
        public Nullable<System.TimeSpan> tra_hora_llegada { get; set; }
        [DisplayName("Descripción")]
        [Required]
        public string tra_descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Paquete_Turistico> Detalle_Paquete_Turistico { get; set; }
    }
}
