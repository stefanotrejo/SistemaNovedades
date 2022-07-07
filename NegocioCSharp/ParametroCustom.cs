using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace LiquidacionSueldos
{
    namespace Negocio
    {
        public partial class Parametro
        {
            public string ObtenerValor(string Nombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerTodoBuscarxNombre]", new object[,] { {
                        "@Nombre",
                        Nombre
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (Tabla.Rows.Count == 0)
                {
                    return "";
                }
                else
                {
                    return Tabla.Rows[0]["Valor"].ToString();
                }
            }
        }
    }
}







