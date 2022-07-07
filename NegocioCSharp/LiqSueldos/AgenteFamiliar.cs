namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AgenteFamiliar")]
    public partial class AgenteFamiliar
    {
        [Key]
        public int afaId { get; set; }

        public int ageId { get; set; }

        public int parId { get; set; }

        public int nivId { get; set; }

        public int afaCuil { get; set; }

        [Required]
        [StringLength(50)]
        public string afaNombreyApellido { get; set; }

        public DateTime afaFechaSituacion { get; set; }

        [Required]
        [StringLength(50)]
        public string afaSexo { get; set; }

        public int afaEstadoCivil { get; set; }

        public byte afaDiscapacidad { get; set; }

        public byte afaActivo { get; set; }

        public int UsuIdCreacion { get; set; }

        public int UsuIdUltimaModificacion { get; set; }

        public DateTime FechaHoraCreacion { get; set; }

        public DateTime FechaHoraUltimaModificacion { get; set; }

        public virtual Agente Agente { get; set; }

        public virtual NivelAcademico NivelAcademico { get; set; }

        public virtual Parentesco Parentesco { get; set; }
    }
}
