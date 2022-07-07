namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AgenteFechaAntiguedad")]
    public partial class AgenteFechaAntiguedad
    {
        [Key]
        public int afaId { get; set; }

        public int? mesId { get; set; }

        public int? ageId { get; set; }

        public DateTime? afaFechaInicioVigencia { get; set; }

        public DateTime? afaFechaFinVigencia { get; set; }

        [StringLength(50)]
        public string afaAntiguedadReconocida { get; set; }

        public byte? afaActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        public virtual Agente Agente { get; set; }

        public virtual MetaEscalafon MetaEscalafon { get; set; }
    }
}
