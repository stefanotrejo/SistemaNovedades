namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NovedadInasistencia")]
    public partial class NovedadInasistencia
    {
        [Key]
        public int ninId { get; set; }

        public int? itiId { get; set; }

        public int? acaId { get; set; }

        public int? liqId { get; set; }

        public DateTime? ninFechaInicio { get; set; }

        public int? ninCantidad { get; set; }

        public DateTime? ninFechaFin { get; set; }

        public byte? ninActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        public virtual AgenteCargo AgenteCargo { get; set; }

        public virtual InasistenciaTipo InasistenciaTipo { get; set; }

        public virtual Liquidacion Liquidacion { get; set; }
    }
}
