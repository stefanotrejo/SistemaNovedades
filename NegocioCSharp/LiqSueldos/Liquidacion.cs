namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Liquidacion")]
    public partial class Liquidacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Liquidacion()
        {
            AgenteLiquidacionCabecera = new HashSet<AgenteLiquidacionCabecera>();
            NovedadInasistencia = new HashSet<NovedadInasistencia>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int liqId { get; set; }

        [Required]
        [StringLength(10)]
        public string liqMes { get; set; }

        [Required]
        [StringLength(10)]
        public string liqAnio { get; set; }

        [Required]
        [StringLength(50)]
        public string liqNombre { get; set; }

        [Required]
        [StringLength(10)]
        public string liqTipo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte liqActivo { get; set; }

        public int UsuIdCreacion { get; set; }

        public int UsuIdUltimaModificacion { get; set; }

        public DateTime FechaHoraCreacion { get; set; }

        public DateTime FechaHoraUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgenteLiquidacionCabecera> AgenteLiquidacionCabecera { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NovedadInasistencia> NovedadInasistencia { get; set; }
    }
}
