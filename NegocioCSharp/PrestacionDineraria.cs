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
        public partial class PrestacionDineraria
        {
            private Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila;
            private DataTable Tabla = new DataTable();

            #region gets and sets 
            private String _pdiNombre;
            public string pdiNombre
            {
                get { return _pdiNombre; }
                set { _pdiNombre = value; }
            }

            private String _pdiCuil;
            public string pdiCuil
            {
                get { return _pdiCuil; }
                set { _pdiCuil = value; }
            }

            private DateTime _pdiFechaOcurrencia;
            public DateTime pdiFechaOcurrencia
            {
                get { return _pdiFechaOcurrencia; }
                set { _pdiFechaOcurrencia = value; }
            }

            private DateTime _pdiFechaLiquidacion;
            public DateTime pdiFechaLiquidacion
            {
                get { return _pdiFechaLiquidacion; }
                set { _pdiFechaLiquidacion = value; }
            }


            private decimal _pdiDiferencia;
            public decimal pdiDiferencia
            {
                get { return _pdiDiferencia; }
                set { _pdiDiferencia = value; }
            }

            private int _pdiActivo;
            public int pdiActivo
            {
                get { return _pdiActivo; }
                set { _pdiActivo = value; }
            }
            #endregion

            #region METODOS
            public int Insertar()
            {
                int IdMax = 0;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[PrestacionDineraria.Insertar]", new object[,] {
                        {"@pdiNombre",pdiNombre},
                        {"@pdiCuil",pdiCuil},
                        {"@pdiFechaOcurrencia",pdiFechaOcurrencia},
                        {"@pdiFechaLiquidacion",pdiFechaLiquidacion},
                        {"@pdiDiferencia",pdiDiferencia},
                        {"@pdiActivo",pdiActivo}
                    });
                    return IdMax;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            //public int InsertarPagoEventual()

            //{
            //    int IdMax = 0;
            //    try
            //    {
            //        IdMax = ocdGestor.EjecutarNonQueryRetornaId("[PagosEventuales.Insertar]", new object[,] {
            //            {"@ageApellidoNombre",ageApellidoyNombre},
            //            {"@ageDNI",ageDocumento},
            //            {"@lpaId",lpaId},
            //            {"@ageImporte",facimporte},
            //            {"@ageCUIT",ageCuil},
            //            {"@sexo",ageSexo},
            //            {"@ageNroControl",ageNroControl},
            //            {"@pevLugarPagoCodigo",lpaCodigo},
            //            {"@acumulado",pevPagoAcumulado}
            //        });
            //        return IdMax;
            //    }

            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }

            //}

            //public void InsertarDetallePagoEventual()
            //{
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[DetallePagoEventual.Insertar]", new object[,] {
            //            {
            //                "@pevId",
            //                pevId
            //            },
            //            {
            //                "@mes",
            //                dpeMes
            //            },
            //            {
            //                "@anio",
            //                dpeAnio
            //            }
            //        });
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}

            //public Agente ObtenerAgenteXNroControl(string nrocontrol)
            //{
            //    try
            //    {
            //        Agente oAgente = new Agente();
            //        Fila = new DataTable();
            //        Fila = ocdGestor.EjecutarReader("[PagosEventuales.ObtenerAgentePorNroControl]", new object[,] {
            //         {
            //                "@nrocontrol",
            //                nrocontrol
            //            }
            //    });
            //        //if (Fila.Rows.Count > 0)
            //        //{
            //        //    if (Fila.Rows[0]["lpaNombre"].ToString().Trim().Length > 0)
            //        //    {
            //        //        oAgente.UnLugPag = Convert.ToString(Fila.Rows[0]["lpaNombre"]);
            //        //    }
            //        //    else
            //        //    {
            //        //        oAgente.UnLugPag = "";
            //        //    }
            //        //    if (Fila.Rows[0]["Cuil"].ToString().Trim().Length > 0)
            //        //    {
            //        //        oAgente.ageCuil = Convert.ToString(Fila.Rows[0]["Cuil"]);
            //        //    }
            //        //    else
            //        //    {
            //        //        oAgente.ageCuil = "";
            //        //    }
            //        //    if (Fila.Rows[0]["Nombre"].ToString().Trim().Length > 0)
            //        //    {
            //        //        oAgente.ageApellidoyNombre = Convert.ToString(Fila.Rows[0]["Nombre"]);
            //        //    }
            //        //    else
            //        //    {
            //        //        oAgente.ageApellidoyNombre = "";
            //        //    }
            //        //    if (Fila.Rows[0]["Sexo"].ToString().Trim().Length > 0)
            //        //    {
            //        //        oAgente.ageSexo = Convert.ToString(Fila.Rows[0]["Sexo"]);
            //        //    }
            //        //    else
            //        //    {
            //        //        oAgente.ageSexo = "";
            //        //    }
            //        //    if (Convert.ToInt32(Fila.Rows[0]["lpaId"]) != 0)
            //        //    {
            //        //        oAgente.lpaId = Convert.ToInt32(Fila.Rows[0]["lpaId"]);
            //        //    }
            //        //    else
            //        //    {
            //        //        oAgente.lpaId = 0;
            //        //    }
            //        //    if (Convert.ToInt32(Fila.Rows[0]["lpaCodigo"]) != 0)
            //        //    {
            //        //        oAgente.lpaCodigo = Convert.ToInt32(Fila.Rows[0]["lpaCodigo"]);
            //        //    }
            //        //    else
            //        //    {
            //        //        oAgente.lpaCodigo = 0;
            //        //    }
            //        //    oAgente.ageNroControl = nrocontrol;
            //        //}
            //        return oAgente;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}

            //public Agente ObtenerAgenteXCuil(string Cuil)
            //{
            //    try
            //    {
            //        Agente oAgente = new Agente();
            //        Fila = new DataTable();
            //        Fila = ocdGestor.EjecutarReader("[PagosEventuales.ObtenerAgentePorCuil]", new object[,] {
            //         {
            //                "@Cuil",
            //                Cuil
            //            }
            //    });
            //        //if (Fila.Rows.Count > 0)
            //        //{
            //        //    if (Fila.Rows[0]["lpaNombre"].ToString().Trim().Length > 0)
            //        //    {
            //        //        oAgente.UnLugPag = Convert.ToString(Fila.Rows[0]["lpaNombre"]);
            //        //    }
            //        //    else
            //        //    {
            //        //        oAgente.UnLugPag = "";
            //        //    }
            //        //    if (Fila.Rows[0]["Cuil"].ToString().Trim().Length > 0)
            //        //    {
            //        //        oAgente.ageCuil = Convert.ToString(Fila.Rows[0]["Cuil"]);
            //        //    }
            //        //    else
            //        //    {
            //        //        oAgente.ageCuil = "";
            //        //    }
            //        //    if (Fila.Rows[0]["Nombre"].ToString().Trim().Length > 0)
            //        //    {
            //        //        oAgente.ageApellidoyNombre = Convert.ToString(Fila.Rows[0]["Nombre"]);
            //        //    }
            //        //    else
            //        //    {
            //        //        oAgente.ageApellidoyNombre = "";
            //        //    }
            //        //    if (Fila.Rows[0]["Sexo"].ToString().Trim().Length > 0)
            //        //    {
            //        //        oAgente.ageSexo = Convert.ToString(Fila.Rows[0]["Sexo"]);
            //        //    }
            //        //    else
            //        //    {
            //        //        oAgente.ageSexo = "";
            //        //    }
            //        //    if (Convert.ToInt32(Fila.Rows[0]["lpaId"]) != 0)
            //        //    {
            //        //        oAgente.lpaId = Convert.ToInt32(Fila.Rows[0]["lpaId"]);
            //        //    }
            //        //    else
            //        //    {
            //        //        oAgente.lpaId = 0;
            //        //    }
            //        //    if (Convert.ToInt32(Fila.Rows[0]["lpaCodigo"]) != 0)
            //        //    {
            //        //        oAgente.lpaCodigo = Convert.ToInt32(Fila.Rows[0]["lpaCodigo"]);
            //        //    }
            //        //    else
            //        //    {
            //        //        oAgente.lpaCodigo = 0;
            //        //    }
            //        //}
            //        return oAgente;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}

            //public Agente ObtenerAgenteXCuilyLugarDePago(string Cuil, string LugarDePagoCodigo)
            //{
            //    try
            //    {
            //        Agente oAgente = new Agente();
            //        Fila = new DataTable();
            //        Fila = ocdGestor.EjecutarReader("[PagosEventuales.ObtenerAgentePorCuilyLugarDePago]", new object[,] {
            //         {
            //                "@Cuil",
            //                Cuil
            //            },
            //        {
            //            "@LugarDePagoCodigo",
            //            LugarDePagoCodigo
            //        }
            //    });
            //        if (Fila.Rows.Count > 0)
            //        {
            //            if (Fila.Rows[0]["Cuil"].ToString().Trim().Length > 0)
            //            {
            //                oAgente.ageCuil = Convert.ToString(Fila.Rows[0]["Cuil"]);
            //            }
            //            else
            //            {
            //                oAgente.ageCuil = "";
            //            }
            //            if (Fila.Rows[0]["lpaNombre"].ToString().Trim().Length > 0)
            //            {
            //                oAgente.UnLugPag = Convert.ToString(Fila.Rows[0]["lpaNombre"]);
            //            }
            //            else
            //            {
            //                oAgente.UnLugPag = "";
            //            }
            //            if (Fila.Rows[0]["NroCOntrol"].ToString().Trim().Length > 0)
            //            {
            //                oAgente.ageNroControl = Convert.ToString(Fila.Rows[0]["NroCOntrol"]);
            //            }
            //            else
            //            {
            //                oAgente.ageNroControl = "";
            //            }
            //        }
            //        return oAgente;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}

            //public Agente ObtenerLugarDePagoPorCodigo(int LugarPagoCodigo)
            //{
            //    try
            //    {
            //        Agente oAgente = new Agente();
            //        Fila = new DataTable();
            //        Fila = ocdGestor.EjecutarReader("[PagosEventuales.[PagosEventuales.ObtenerLugarDePagoPorNroControl]]", new object[,] {
            //         {
            //                "@LugarPagoCodigo",
            //                LugarPagoCodigo
            //            }
            //    });
            //        if (Fila.Rows.Count > 0)
            //        {
            //            if (Fila.Rows[0]["lpaId"].ToString().Trim().Length > 0)
            //            {
            //                oAgente.lpaId = Convert.ToInt32(Fila.Rows[0]["lpaId"]);
            //            }
            //            if (Fila.Rows[0]["UnLugPago"].ToString().Trim().Length > 0)
            //            {
            //                oAgente.UnLugPag = Convert.ToString(Fila.Rows[0]["UnLugPago"]);
            //            }
            //            else
            //            {
            //                oAgente.UnLugPag = "";
            //            }
            //        }
            //        return oAgente;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}

            //public DataTable ObtenerAgentesxFechaDeCarga(DateTime fechacarga)
            //{
            //    try
            //    {
            //        // Agente oAgente = new Agente();
            //        Fila = new DataTable();
            //        Fila = ocdGestor.EjecutarReader("[PagosEventuales.ObtenerAgentePorFechaDeCarga]", new object[,] {
            //         {
            //                "@ageFechacarga",
            //                fechacarga
            //            }
            //    });
            //        if (Fila.Rows.Count > 0)
            //        {
            //            //if (Fila.Rows[0]["lpaNombre"].ToString().Trim().Length > 0)
            //            //{
            //            //    oAgente.UnLugPag = Convert.ToString(Fila.Rows[0]["lpaNombre"]);
            //            //}
            //            //else
            //            //{
            //            //    oAgente.UnLugPag = "";
            //            //}
            //            //if (Fila.Rows[0]["Cuil"].ToString().Trim().Length > 0)
            //            //{
            //            //    oAgente.ageCUIT = Convert.ToString(Fila.Rows[0]["Cuil"]);
            //            //}
            //            //else
            //            //{
            //            //    oAgente.ageCUIT = "";
            //            //}
            //            //if (Fila.Rows[0]["Nombre"].ToString().Trim().Length > 0)
            //            //{
            //            //    oAgente.ageApellidoNombre = Convert.ToString(Fila.Rows[0]["Nombre"]);
            //            //}
            //            //else
            //            //{
            //            //    oAgente.ageApellidoNombre = "";
            //            //}
            //            //if (Fila.Rows[0]["Sexo"].ToString().Trim().Length > 0)
            //            //{
            //            //    oAgente.ageSexo = Convert.ToString(Fila.Rows[0]["Sexo"]);
            //            //}
            //            //else
            //            //{
            //            //    oAgente.ageSexo = "";
            //            //}
            //            //if (Convert.ToInt32(Fila.Rows[0]["lpaId"]) != 0)
            //            //{
            //            //    oAgente.lpaId = Convert.ToInt32(Fila.Rows[0]["lpaId"]);
            //            //}
            //            //else
            //            //{
            //            //    oAgente.lpaId = 0;
            //            //}
            //        }
            //        //else
            //        //{
            //        //    oAgente.ageApellidoNombre = "";
            //        //}
            //        return Fila;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}

            //public DataTable ObtenerRegistrosDeAgentes(DateTime fechacarga)
            //{
            //    try
            //    {
            //        // Agente oAgente = new Agente();
            //        Fila = new DataTable();
            //        Fila = ocdGestor.EjecutarReader("[PagosEventuales.ArchivoInformaticaGenerar]", new object[,] {
            //         {
            //                "@ageFechacarga",
            //                fechacarga
            //            }
            //    });
            //        return Fila;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}

            //public void Actualizar()
            //{
            //    try
            //    {

            //        ocdGestor.EjecutarNonQuery("[PagosEventuales.CambiarEstado]", new object[,] {
            //                {
            //                    "@fecha",
            //                    pevFechaCarga
            //                }
            //            });

            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}

            //public DataTable ObtenerValidarRepetido(string ageCuil)
            //{
            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[Agente.ObtenerValidarRepetido]", new object[,] {
            //            {"@ageCuil",ageCuil}
            //        });
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }

            //    return Tabla;
            //}

            //public int ObtenerIdPorCuil(string ageCuil)
            //{
            //    int id;
            //    try
            //    {

            //        id = ocdGestor.EjecutarScalar("[Agente.ObtenerIdPorCuil]", new object[,] {
            //          {"@ageCuil",ageCuil}
            //    });
            //        return id;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}

            #endregion
        }
    }
}
