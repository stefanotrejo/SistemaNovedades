namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TempDatosLiquidacion")]
    public partial class TempDatosLiquidacion
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tdlId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string tdlAnio { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string tdlMes { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string tdlNombre { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string tdlPrefijoDoc { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(10)]
        public string tdlPlanta { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(10)]
        public string tdlNroControl { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(10)]
        public string tdlJurisdicionId { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(10)]
        public string tdlLugarPid { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(10)]
        public string tdlEscuelaId { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(10)]
        public string tdlCargoId { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(10)]
        public string tdlCategoria { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(10)]
        public string tdlHorasCat { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(10)]
        public string tdlDiasTraba { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(10)]
        public string tdlAntiguedad { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(10)]
        public string tdlAntiReconocida { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(10)]
        public string tdlSituRevista { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(10)]
        public string tdlInterinato { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(10)]
        public string tdlPreseNoRiesgo { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(10)]
        public string tdlJuviladoActi { get; set; }

        [Key]
        [Column(Order = 20)]
        [StringLength(10)]
        public string tdlCajaPrevi { get; set; }

        [Key]
        [Column(Order = 21)]
        [StringLength(10)]
        public string tdlHaberImpo { get; set; }

        [Key]
        [Column(Order = 22)]
        [StringLength(10)]
        public string tdlHaberRemu { get; set; }

        [Key]
        [Column(Order = 23)]
        [StringLength(10)]
        public string tdlHaberNoRemu { get; set; }

        [Key]
        [Column(Order = 24)]
        [StringLength(10)]
        public string tdlSalario { get; set; }

        [Key]
        [Column(Order = 25)]
        [StringLength(10)]
        public string tdlLiqId { get; set; }

        [Key]
        [Column(Order = 26)]
        [StringLength(10)]
        public string tdlFechaAlta { get; set; }

        [Key]
        [Column(Order = 27)]
        [StringLength(10)]
        public string tdlUsuId { get; set; }

        [Key]
        [Column(Order = 28)]
        [StringLength(10)]
        public string tdlEscCodigo { get; set; }

        [Key]
        [Column(Order = 29)]
        [StringLength(50)]
        public string tdlSalarioFamilia { get; set; }

        [Key]
        [Column(Order = 30)]
        [StringLength(50)]
        public string tdlNuevoTotalHaberes { get; set; }
    }
}
