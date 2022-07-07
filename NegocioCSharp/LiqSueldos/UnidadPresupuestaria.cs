namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UnidadPresupuestaria")]
    public partial class UnidadPresupuestaria
    {
        [Key]
        public int uprId { get; set; }

        public int? proId { get; set; }

        public int? sprId { get; set; }

        [StringLength(100)]
        public string uprCodigo { get; set; }

        [StringLength(50)]
        public string uprActividad { get; set; }

        public byte? uprActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        public virtual Programa Programa { get; set; }

        public virtual SubPrograma SubPrograma { get; set; }
    }
}
