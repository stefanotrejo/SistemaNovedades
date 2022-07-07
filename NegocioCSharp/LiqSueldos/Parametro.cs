namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Parametro")]
    public partial class Parametro
    {
        [Key]
        public int parId { get; set; }

        [StringLength(50)]
        public string parNombre { get; set; }

        public string parValor { get; set; }

        public byte? parActivo { get; set; }

        public int? usuIdCreacion { get; set; }

        public int? usuIdUltimaModificacion { get; set; }

        public DateTime? parFechaHoraCreacion { get; set; }

        public DateTime? parFechaHoraUltimaModificacion { get; set; }
    }
}
