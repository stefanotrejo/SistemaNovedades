namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AgenteAdscripcionAfectacion")]
    public partial class AgenteAdscripcionAfectacion
    {
        [Key]
        public int aaaId { get; set; }

        public int? acaIdOrigen { get; set; }

        public int? lpaIdOrigen { get; set; }

        public byte? aaaTipo { get; set; }

        public int? acaIdDestino { get; set; }

        public int? lpaIdDestino { get; set; }

        public byte? aaaActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }
    }
}
