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
    using System.Web;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Lugar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lugar()
        {
            this.Actividad = new HashSet<Actividad>();
        }
    
        public int lug_id { get; set; }
        [DisplayName("Nombre")]
        [Required]
        public string lug_nombre { get; set; }
        [DisplayName("Decripción")]
        [Required]
        public string lug_descripcion { get; set; }
        [DisplayName("Estado")]
        [Required]
        public Nullable<bool> lug_estado { get; set; }
        [DisplayName("Foto")]
        public string lug_ruta_foto { get; set; }
        [DisplayName("Observación")]
        [Required]
        public string lug_observacion { get; set; }

        public int ciu_id { get; set; }

        public HttpPostedFileBase ImagenFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actividad> Actividad { get; set; }
        public virtual Ciudad Ciudad { get; set; }
    }
}
