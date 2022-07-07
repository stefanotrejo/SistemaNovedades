namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [Key]
        public int menId { get; set; }

        [StringLength(250)]
        public string menNombre { get; set; }

        public int? menIdPadre { get; set; }

        public int? menOrden { get; set; }

        [StringLength(500)]
        public string menUrl { get; set; }

        [StringLength(500)]
        public string menIcono { get; set; }

        public byte? menEsMenu { get; set; }

        public byte? menActivo { get; set; }

        public int? usuIdCreacion { get; set; }

        public int? usuIdUltimaModificacion { get; set; }

        public DateTime? menFechaHoraCreacion { get; set; }

        public DateTime? menFechaHoraUltimaModificacion { get; set; }
    }
}
