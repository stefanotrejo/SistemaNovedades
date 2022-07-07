using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;

namespace LiquidacionSueldos.Negocio
{
    public partial class Error
    {
        private Datos.Gestor ocdGestor = new Datos.Gestor();
        private DataTable Fila;
        private DataTable Tabla = new DataTable();
        #region Propiedades
        public int usuId { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string TargetSite { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public int Activo { get; set; }
        #endregion

        #region Metodos
        public int Insertar(int usuId, string Message, string StackTrace, string TargetSite)
        {
            int IdMax = 0;
            try
            {
                IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Error.InsertarError]", new object[,] {

                    {
                            "@usuId",
                             usuId
                        },
                        {
                            "@errMessage",
                             Message
                        },
                                    {
                            "@StackTrace",
                            StackTrace
                        },
                    {
                        "@TargetSite",
                        TargetSite
                    }
                    });
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return IdMax;
        }
        #endregion




    }
}
