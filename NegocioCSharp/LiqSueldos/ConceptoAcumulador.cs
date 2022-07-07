namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConceptoAcumulador")]
    public partial class ConceptoAcumulador
    {
        [Key]
        public int cacId { get; set; }

        public int? conIdAcumulador { get; set; }

        public int? conIdIncluido { get; set; }

        public byte? cacActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }
    }
}
