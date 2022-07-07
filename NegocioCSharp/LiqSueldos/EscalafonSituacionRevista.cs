namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EscalafonSituacionRevista")]
    public partial class EscalafonSituacionRevista
    {
        [Key]
        public int esrId { get; set; }

        public int? sreId { get; set; }

        public int? escId { get; set; }

        public byte? esrActivo { get; set; }

        public int? UsuIdCreacion { get; set; }

        public int? UsuIdUltimaModificacion { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public DateTime? FechaHoraUltimaModificacion { get; set; }

        public virtual Escalafon Escalafon { get; set; }

        public virtual SituacionRevista SituacionRevista { get; set; }
    }
}
