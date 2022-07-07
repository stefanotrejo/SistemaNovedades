namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AgenteLiquidacionCabecera")]
    public partial class AgenteLiquidacionCabecera
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AgenteLiquidacionCabecera()
        {
            AgenteLiquidacionDetalle = new HashSet<AgenteLiquidacionDetalle>();
        }

        [Key]
        public int alcId { get; set; }

        public int? acaId { get; set; }

        public int? liqId { get; set; }

        public int? alcObligacionesTrabajadas { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? alcTotalRemunerativo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? alcTotalNoRemunerativo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? alcTotalAsignacionesFamiliares { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? alcTotalBruto { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? alcLiquido { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? aclHaberImponible { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? alcHaberImponibleAnses { get; set; }

        public int? alcAntiguedadReconocida { get; set; }

        public int? alcAntiguedad { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? alcTotalDescuentosLey { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? alcTotalDescuentos { get; set; }

        public DateTime? alcFechaIngreso { get; set; }

        public byte? alcActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        public virtual AgenteCargo AgenteCargo { get; set; }

        public virtual Liquidacion Liquidacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgenteLiquidacionDetalle> AgenteLiquidacionDetalle { get; set; }
    }
}
