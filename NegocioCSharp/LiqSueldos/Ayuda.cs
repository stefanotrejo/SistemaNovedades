namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ayuda")]
    public partial class Ayuda
    {
        [Key]
        public int ayuId { get; set; }

        public string ayuPaginaNombre { get; set; }

        public string ayuDescripcion { get; set; }

        public byte? ayuActivo { get; set; }

        public int? usuIdCreacion { get; set; }

        public int? usuIdUltimaModificacion { get; set; }

        public DateTime? ayuFechaHoraCreacion { get; set; }

        public DateTime? ayuFechaHoraUltimaModificacion { get; set; }
    }
}
