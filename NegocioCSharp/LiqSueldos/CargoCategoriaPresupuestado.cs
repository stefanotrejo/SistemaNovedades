namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CargoCategoriaPresupuestado")]
    public partial class CargoCategoriaPresupuestado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CargoCategoriaPresupuestado()
        {
            CargoCategoriaEscalafon = new HashSet<CargoCategoriaEscalafon>();
        }

        [Key]
        public int ccpId { get; set; }

        public int? agrId { get; set; }

        [StringLength(200)]
        public string ccpNombre { get; set; }

        [StringLength(50)]
        public string ccpTramo { get; set; }

        [StringLength(50)]
        public string ccpApertura { get; set; }

        public int? ccpCodigoCargoCategoria { get; set; }

        public byte? ccpTipo { get; set; }

        public byte? ccpActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        public virtual Agrupamiento Agrupamiento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CargoCategoriaEscalafon> CargoCategoriaEscalafon { get; set; }
    }
}
