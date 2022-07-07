namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EscalafonImponible")]
    public partial class EscalafonImponible
    {
        [Key]
        public int eimId { get; set; }

        public int? escId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? eimMaximo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? eimMinimo { get; set; }

        public DateTime? eimFechaInicioVigencia { get; set; }

        public byte? eimActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        public virtual Escalafon Escalafon { get; set; }
    }
}
