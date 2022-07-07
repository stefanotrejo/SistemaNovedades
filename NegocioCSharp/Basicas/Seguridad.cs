﻿using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Security.Cryptography;
using System.Text;

namespace LiquidacionSueldos
{
    namespace Negocio
    {
        public class Seguridad
        {
            static Datos.Gestor ocdGestor = new Datos.Gestor();

            static DataTable Tabla = new DataTable();
            public static DataTable Autenticar(string usuNombreIngreso, string usuClave)
            {
                string ClaveEncriptada = EncriptarClave(usuClave);
                return ocdGestor.EjecutarReader("[Usuario.ObtenerAutenticar]", new object[,] {{"@usuNombreIngreso",usuNombreIngreso},{"@usuClave",ClaveEncriptada}});
            }

            public static bool ValidarIngresoPagina(int perId, string PaginaNombre)
            {
                Tabla = ocdGestor.EjecutarReader("[Usuario.ValidarPagina]", new object[,] {
                    {
                        "@perId",
                        perId
                    },
                    {
                        "@PaginaNombre",
                        PaginaNombre
                    }
                });

                if (Tabla.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public static DataTable ObtenerMenu(int menId, int perId)
            {
                return ocdGestor.EjecutarReader("[Perfil.ObtenerMenu]", new object[,] {
                    {
                        "@menId",
                        menId
                    },
                    {
                        "@perId",
                        perId
                    }
                });
            }

            public static string EncriptarClave(string usuClave)
            {
                UnicodeEncoding encoder = null;
                SHA512Managed sSHA512 = null;
                try
                {
                    encoder = new UnicodeEncoding();
                    sSHA512 = new SHA512Managed();

                }
                catch (Exception oError)
                {
                    throw oError;
                }

                return Convert.ToBase64String(sSHA512.ComputeHash(encoder.GetBytes(usuClave)));
              
            }
        }
    }
}