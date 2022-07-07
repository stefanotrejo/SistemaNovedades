namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Agente")]
    public partial class Agente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agente()
        {
            AgenteCargo = new HashSet<AgenteCargo>();
            AgenteFamiliar = new HashSet<AgenteFamiliar>();
            AgenteFechaAntiguedad = new HashSet<AgenteFechaAntiguedad>();
            AgenteTitulo = new HashSet<AgenteTitulo>();
            NovedadAgenteFamiliar = new HashSet<NovedadAgenteFamiliar>();
        }

        [Key]
        public int ageId { get; set; }

        [Required]
        [StringLength(50)]
        public string ageCuil { get; set; }

        [Required]
        [StringLength(50)]
        public string ageTipoDocumento { get; set; }

        [Required]
        [StringLength(100)]
        public string ageApellidoyNombre { get; set; }

        public DateTime? ageFechaNacimiento { get; set; }

        [StringLength(50)]
        public string ageSexo { get; set; }

        [StringLength(50)]
        public string ageEstadoCivil { get; set; }

        public byte? ageActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgenteCargo> AgenteCargo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgenteFamiliar> AgenteFamiliar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgenteFechaAntiguedad> AgenteFechaAntiguedad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgenteTitulo> AgenteTitulo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NovedadAgenteFamiliar> NovedadAgenteFamiliar { get; set; }
    }
}
