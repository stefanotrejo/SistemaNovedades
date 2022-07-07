namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PerfilMenu")]
    public partial class PerfilMenu
    {
        [Key]
        public int pmeId { get; set; }

        public int perId { get; set; }

        public int menId { get; set; }

        public byte? pmeActivo { get; set; }

        public int? usuIdCreacion { get; set; }

        public int? usuIdUltimaModificacion { get; set; }

        public DateTime? pmeFechaHoraCreacion { get; set; }

        public DateTime? pmeFechaHoraUltimaModificacion { get; set; }
    }
}
