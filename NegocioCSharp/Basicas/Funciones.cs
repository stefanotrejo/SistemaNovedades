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
        public class Funciones
        {
            static Datos.Gestor ocdGestor = new Datos.Gestor();
            static DataTable Tabla = new DataTable();

            static string Cadena = "";
            public static string CantidadConLetra(string NumeroDecimal)
            {
                Cadena = "";
                try
                {
                    Tabla = ocdGestor.EjecutarReaderSql("select dbo.CantidadConLetra(" + NumeroDecimal.Replace(",", ".") + ") as CantidadEnLetra");
                    Cadena = Tabla.Rows[0]["CantidadEnLetra"].ToString();
                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Cadena;
            }
        }
    }
}