namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Agrupamiento")]
    public partial class Agrupamiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agrupamiento()
        {
            CargoCategoriaPresupuestado = new HashSet<CargoCategoriaPresupuestado>();
        }

        [Key]
        public int agrId { get; set; }

        [StringLength(50)]
        public string agrCodigo { get; set; }

        [StringLength(50)]
        public string agrNombre { get; set; }

        public byte? agrActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CargoCategoriaPresupuestado> CargoCategoriaPresupuestado { get; set; }
    }
}
