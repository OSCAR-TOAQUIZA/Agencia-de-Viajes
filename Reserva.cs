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
    
    public partial class Reserva
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reserva()
        {
            this.Detalle_Reserva = new HashSet<Detalle_Reserva>();
        }
    
        public int res_id { get; set; }
        public int cli_id { get; set; }
        public Nullable<System.DateTime> res_fecha { get; set; }
        public string res_forma_pago { get; set; }
        public Nullable<bool> res_estado_reserva { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Reserva> Detalle_Reserva { get; set; }
    }
}