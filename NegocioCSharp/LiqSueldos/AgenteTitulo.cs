namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AgenteTitulo")]
    public partial class AgenteTitulo
    {
        [Key]
        public int atiId { get; set; }

        public int? ageId { get; set; }

        public int? titId { get; set; }

        public byte? atiActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        public virtual Agente Agente { get; set; }

        public virtual Titulo Titulo { get; set; }
    }
}
