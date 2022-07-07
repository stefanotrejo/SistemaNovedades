namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Programa")]
    public partial class Programa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Programa()
        {
            SubPrograma = new HashSet<SubPrograma>();
            UnidadPresupuestaria = new HashSet<UnidadPresupuestaria>();
        }

        [Key]
        public int proId { get; set; }

        [StringLength(50)]
        public string jurCodigo { get; set; }

        public int? jurId { get; set; }

        [StringLength(50)]
        public string proCodigo { get; set; }

        [StringLength(200)]
        public string proNombre { get; set; }

        public byte? proActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        public virtual Jurisdiccion Jurisdiccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubPrograma> SubPrograma { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnidadPresupuestaria> UnidadPresupuestaria { get; set; }
    }
}
