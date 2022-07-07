namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Concepto")]
    public partial class Concepto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Concepto()
        {
            AgenteLiquidacionDetalle = new HashSet<AgenteLiquidacionDetalle>();
            ConceptoFrecuencia = new HashSet<ConceptoFrecuencia>();
            NovedadConcepto = new HashSet<NovedadConcepto>();
        }

        [Key]
        public int conId { get; set; }

        public int? conCodigo { get; set; }

        public int? escId { get; set; }

        [StringLength(50)]
        public string conNombre { get; set; }

        public byte? conBonificacionDescuento { get; set; }

        public byte? conRemunerativoNoRemunerativo { get; set; }

        [StringLength(50)]
        public string conTipoCalculo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? conValor { get; set; }

        public int? conDependeCodCargo { get; set; }

        public int? conDescuentoTipo { get; set; }

        public byte? conPorDefecto { get; set; }

        public byte? conPermanente { get; set; }

        [StringLength(50)]
        public string conFormula { get; set; }

        public int? conCantidadMaxima { get; set; }

        public byte? conIncluyeEnRentasGenerales { get; set; }

        public byte? conMostrarEnReciboSueldo { get; set; }

        public byte? conOrigenFondo { get; set; }

        public byte? conEsAcumulador { get; set; }

        public byte? conActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgenteLiquidacionDetalle> AgenteLiquidacionDetalle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConceptoFrecuencia> ConceptoFrecuencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NovedadConcepto> NovedadConcepto { get; set; }
    }
}
