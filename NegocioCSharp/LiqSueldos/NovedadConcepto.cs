namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NovedadConcepto")]
    public partial class NovedadConcepto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ncoId { get; set; }

        public int? conId { get; set; }

        public int? acaId { get; set; }

        public int? liqId { get; set; }

        public int? ncoValor { get; set; }

        public int? ncoCuilFamiliar { get; set; }

        public int? ncoCantidad { get; set; }

        public byte? ncoActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        public virtual AgenteCargo AgenteCargo { get; set; }

        public virtual Concepto Concepto { get; set; }
    }
}
