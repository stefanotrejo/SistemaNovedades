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
        public partial class PagosEventualesBanco
        {
            private Datos.Gestor ocdGestor = new Datos.Gestor();

            public int InsertarBanco(string nombre, string dni, string lugar_pago,
                float importe, string cuit, string sexo, string concepto)
            {
                try
                {
                    int IdMax = 0;
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[PagosEventuales.Insertar_Banco]", new object[,] {
                        {
                            "@nombre",
                            nombre
                        },
                        {
                            "@dni",
                            dni
                        },
                        {
                            "@lugar_pago",
                            lugar_pago
                        },

                        {
                            "@importe",
                            importe
                        },
                        {
                            "@cuit",
                            cuit
                        },
                        {
                            "@sexo",
                            sexo
                        },
                        {
                            "@concepto",
                            concepto
                        }
                    });
                    return IdMax;
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
