namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AgenteCargo")]
    public partial class AgenteCargo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AgenteCargo()
        {
            AgenteLiquidacionCabecera = new HashSet<AgenteLiquidacionCabecera>();
            NovedadConcepto = new HashSet<NovedadConcepto>();
            NovedadInasistencia = new HashSet<NovedadInasistencia>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int acaId { get; set; }

        public int? ageId { get; set; }

        public int? cceId { get; set; }

        public int? ptiId { get; set; }

        public int? mbaId { get; set; }

        public int? lpeId { get; set; }

        public int? esuId { get; set; }

        public int? uprId { get; set; }

        public int? sreId { get; set; }

        public DateTime? acaFechaInicioCargo { get; set; }

        public DateTime? acaFechaBajaCargo { get; set; }

        public DateTime? acaFechaInicioPlantaPermanente { get; set; }

        public int? acaNroControl { get; set; }

        public int? acaHorasCatedra { get; set; }

        public byte? acaNoRetenido { get; set; }

        public byte? acaAdscriptoAfectado { get; set; }

        public int? aaaId { get; set; }

        public int? acaDiasMulta { get; set; }

        public byte? acaActivo { get; set; }

        public int? acaUsuIdCreacion { get; set; }

        public int? acaUsuIdUltimaModificacion { get; set; }

        public DateTime? acaFechaHoraCreacion { get; set; }

        public DateTime? acaFechaHoraUltimaModificacion { get; set; }

        public virtual Agente Agente { get; set; }

        public virtual Escuela Escuela { get; set; }

        public virtual LugarPago LugarPago { get; set; }

        public virtual MotivoBaja MotivoBaja { get; set; }

        public virtual PlantaTipo PlantaTipo { get; set; }

        public virtual SituacionRevista SituacionRevista { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgenteLiquidacionCabecera> AgenteLiquidacionCabecera { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NovedadConcepto> NovedadConcepto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NovedadInasistencia> NovedadInasistencia { get; set; }
    }
}
