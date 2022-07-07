namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmailSalida")]
    public partial class EmailSalida
    {
        [Key]
        public int esaId { get; set; }

        public DateTime? esaFecha { get; set; }

        public string esaPara { get; set; }

        [StringLength(50)]
        public string esaTipo { get; set; }

        public string esaTitulo { get; set; }

        public string esaCuerpo { get; set; }

        public string esaDescripcion { get; set; }

        public int? cuoId { get; set; }

        public byte? esaActivo { get; set; }

        public int? usuIdCreacion { get; set; }

        public int? usuIdUltimaModificacion { get; set; }

        public DateTime? esaFechaHoraCreacion { get; set; }

        public DateTime? esaFechaHoraUltimaModificacion { get; set; }
    }
}
