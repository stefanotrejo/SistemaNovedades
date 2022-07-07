namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubPrograma")]
    public partial class SubPrograma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubPrograma()
        {
            UnidadPresupuestaria = new HashSet<UnidadPresupuestaria>();
        }

        [Key]
        public int sprId { get; set; }

        public int? proId { get; set; }

        [StringLength(50)]
        public string sprCodigo { get; set; }

        [StringLength(200)]
        public string sprNombre { get; set; }

        public byte? sprActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        public virtual Programa Programa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnidadPresupuestaria> UnidadPresupuestaria { get; set; }
    }
}
