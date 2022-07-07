namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AgenteLiquidacionDetalle")]
    public partial class AgenteLiquidacionDetalle
    {
        [Key]
        public int aldId { get; set; }

        public int? alcId { get; set; }

        public int? conId { get; set; }

        public int? novId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? aldImporte { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? aldValor { get; set; }

        public byte? aldActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        public virtual AgenteLiquidacionCabecera AgenteLiquidacionCabecera { get; set; }

        public virtual Concepto Concepto { get; set; }
    }
}
