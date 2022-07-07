namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CargoCategoriaEscalafon")]
    public partial class CargoCategoriaEscalafon
    {
        [Key]
        [Column(Order = 0)]
        public int cceId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ccpCodigoCargoCategoria { get; set; }

        public int? lpeId { get; set; }

        public int? ccpId { get; set; }

        public int? mesId { get; set; }

        public byte? cceOcupado { get; set; }

        public byte? cceTratamientoEspecialConceptos { get; set; }

        public byte? cceActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        [StringLength(50)]
        public string apertura { get; set; }

        [StringLength(50)]
        public string tramo { get; set; }

        [StringLength(50)]
        public string lugarpago { get; set; }

        [StringLength(50)]
        public string agrupamiento { get; set; }

        [StringLength(50)]
        public string esc { get; set; }

        public virtual CargoCategoriaPresupuestado CargoCategoriaPresupuestado { get; set; }

        public virtual LugarPagoEscalafon LugarPagoEscalafon { get; set; }
    }
}
