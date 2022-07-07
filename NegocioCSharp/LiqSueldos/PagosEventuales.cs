namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PagosEventuales
    {
        [Key]
        public int pevId { get; set; }

        public int? lpaId { get; set; }

        [StringLength(255)]
        public string ageApellidoNombre { get; set; }

        [StringLength(255)]
        public string ageDNI { get; set; }

        [StringLength(255)]
        public string ageCUIT { get; set; }

        [StringLength(255)]
        public string ageSexo { get; set; }

        [StringLength(255)]
        public string pevLugarPagoCodigo { get; set; }

        public double? pevImporteTotal { get; set; }

        public DateTime? pevFechaCarga { get; set; }

        public byte? pevGenerado { get; set; }

        public byte? pevPagoAcumulado { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }
    }
}
