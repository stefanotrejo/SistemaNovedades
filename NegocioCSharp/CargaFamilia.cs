using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LiquidacionSueldos.Negocio
{
    class CargaFamilia
    {
        private Datos.Gestor ocdGestor = new Datos.Gestor();
        private DataTable Fila;
        private DataTable Tabla = new DataTable();

        public string Planta { get; set; }
        public string Legajo { get; set; }
        public string NumeroControl { get; set; }
        public string FechaNovedad { get; set; }
        public string EstadoCivil { get; set; }
        public string Salario { get; set; }
        public string ApellidoNombre { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Sexo { get; set; }
        public string Escolaridad { get; set; }
        public string Invalidez { get; set; }
    }
}
