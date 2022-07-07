namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NovedadAgenteFamiliar")]
    public partial class NovedadAgenteFamiliar
    {
        [Key]
        public int nafId { get; set; }

        public int? ageId { get; set; }

        public int? parId { get; set; }

        public int? nivId { get; set; }

        [StringLength(50)]
        public string nafCuil { get; set; }

        [StringLength(100)]
        public string nafNombreyApellido { get; set; }

        public DateTime? nafFechaSituacion { get; set; }

        [StringLength(50)]
        public string nafSexo { get; set; }

        [StringLength(50)]
        public string nafEstadoCivil { get; set; }

        public byte? nafDiscapacidad { get; set; }

        public byte? nafActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        public virtual Agente Agente { get; set; }

        public virtual NivelAcademico NivelAcademico { get; set; }

        public virtual Parentesco Parentesco { get; set; }
    }
}
