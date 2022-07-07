namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CargoCategoriaBasico")]
    public partial class CargoCategoriaBasico
    {
        [Key]
        public int ccbId { get; set; }

        public int? ccpCodigoCargoCategoria { get; set; }

        public int? escId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ccbValor { get; set; }

        public int? ccbPuntos { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ccbValorSub1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ccbValorSub2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ccbValorSub3 { get; set; }

        public byte? ccbActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        public virtual Escalafon Escalafon { get; set; }
    }
}
