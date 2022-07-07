namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InasistenciaTipo")]
    public partial class InasistenciaTipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InasistenciaTipo()
        {
            NovedadInasistencia = new HashSet<NovedadInasistencia>();
        }

        [Key]
        public int itiId { get; set; }

        [StringLength(50)]
        public string itiNombre { get; set; }

        public byte? itiQuitaPresentismo { get; set; }

        public byte? itiDescuentoProporcional { get; set; }

        public byte? itiQuitaIncentivo { get; set; }

        public byte? itiDescuentaProporcionalAsignaciones { get; set; }

        [StringLength(10)]
        public string itiActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NovedadInasistencia> NovedadInasistencia { get; set; }
    }
}
