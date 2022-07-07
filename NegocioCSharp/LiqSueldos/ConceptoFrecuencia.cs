namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConceptoFrecuencia")]
    public partial class ConceptoFrecuencia
    {
        [Key]
        public int cfrId { get; set; }

        public int? conId { get; set; }

        public int? cfrMes { get; set; }

        public byte? cfrActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        public virtual Concepto Concepto { get; set; }
    }
}
