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
        public partial class LugarPago
        {
            #region Propiedades
            
            private Datos.Gestor ocdGestor = new Datos.Gestor();

            private DataTable Fila;
            private DataTable Tabla = new DataTable();

            private int _lpaId;
            public int lpaId
            {
                get { return _lpaId; }
                set { _lpaId = value; }
            }

            private int _lpaCodigo;
            public int lpaCodigo
            {
                get { return _lpaCodigo; }
                set { _lpaCodigo = value; }
            }

            private String _lpaNombre;
            public string lpaNombre
            {
                get { return _lpaNombre; }
                set { _lpaNombre = value; }
            }

            private int _jurCodigo;
            public int jurCodigo
            {
                get { return _jurCodigo; }
                set { _jurCodigo = value; }
            }

            private String _escalafon;
            public string escalafon
            {
                get { return _escalafon; }
                set { _escalafon = value; }
            }

            private int _lpaActivo;
            public int lpaActivo
            {
                get { return _lpaActivo; }
                set { _lpaActivo = value; }
            }

            #endregion

            public LugarPago ObtenerPorCodigo(int LugarPagoCodigo)
            {
                try
                {
                    LugarPago objetoLugarPago = new LugarPago();
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[LugarPago.ObtenerPorCodigo]", new object[,] {
                     {
                            "@LugarPagoCodigo",
                            LugarPagoCodigo
                        }
                });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["lpaId"].ToString().Trim().Length > 0)
                        {
                            objetoLugarPago.lpaId = Convert.ToInt32(Fila.Rows[0]["lpaId"]);
                        }
                        if (Fila.Rows[0]["lpaNombre"].ToString().Trim().Length > 0)
                        {
                            objetoLugarPago.lpaNombre = Convert.ToString(Fila.Rows[0]["lpaNombre"]);
                        }
                        else
                        {
                            objetoLugarPago.lpaNombre = "";
                        }
                    }
                    else
                    {
                        objetoLugarPago = null;
                    }
                    return objetoLugarPago;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            /*
            public int Insertar()
            {
                //string ageApellidoNombre, string ageDNI, int UnLugPago, float ageImporte, string ageCUIT, string ageSexo, string ageNroControl, int lpaCodigo, int acumulado
                try
                {
                    int IdMax = 0;
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[PagosEventuales.Insertar]", new object[,] {
                        {
                            "@ageApellidoNombre",
                            ageApellidoNombre
                        },
                        {
                            "@ageDNI",
                            ageDNI
                        },
                        {
                            "@lpaId",
                            lpaId
                        },

                        {
                            "@ageImporte",
                            facimporte
                        },
                        {
                            "@ageCUIT",
                            ageCUIT
                        },
                        {
                            "@sexo",
                            ageSexo
                        },
                        {
                            "@ageNroControl",
                            ageNroControl
                        },
                        {
                            "@pevLugarPagoCodigo",
                            lpaCodigo
                        },
                          {
                            "@acumulado",
                            pevPagoAcumulado
                        },
                           {
                            "@ageJurisdiccion",
                            ageJurisdiccion
                        },
                            {
                            "@agePrograma",
                            agePrograma
                        }
                    });
                    return IdMax;
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void InsertarDetallePagoEventual()
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[DetallePagoEventual.Insertar]", new object[,] {
                        {
                            "@pevId",
                            pevId
                        },
                        {
                            "@mes",
                            dpeMes
                        },
                        {
                            "@anio",
                            dpeAnio
                        },
                        {
                            "@dpeConcepto",
                            dpeConcepto
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public Agente ObtenerAgentePorNroControl(string nrocontrol)
            {
                try
                {
                    Agente oAgente = new Agente();
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[PagosEventuales.ObtenerAgentePorNroControl]", new object[,] {
                     {
                            "@nrocontrol",
                            nrocontrol
                        }
                });
                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["lpaNombre"].ToString().Trim().Length > 0)
                        {
                            oAgente.LugarPago = Convert.ToString(Fila.Rows[0]["lpaNombre"]);
                        }
                        else
                        {
                            oAgente.LugarPago = "";
                        }
                        if (Fila.Rows[0]["Cuil"].ToString().Trim().Length > 0)
                        {
                            oAgente.ageCUIT = Convert.ToString(Fila.Rows[0]["Cuil"]);
                        }
                        else
                        {
                            oAgente.ageCUIT = "";
                        }
                        if (Fila.Rows[0]["Nombre"].ToString().Trim().Length > 0)
                        {
                            oAgente.ageApellidoNombre = Convert.ToString(Fila.Rows[0]["Nombre"]);
                        }
                        else
                        {
                            oAgente.ageApellidoNombre = "";
                        }
                        if (Fila.Rows[0]["Sexo"].ToString().Trim().Length > 0)
                        {
                            oAgente.ageSexo = Convert.ToString(Fila.Rows[0]["Sexo"]);
                        }
                        else
                        {
                            oAgente.ageSexo = "";
                        }
                        if (Convert.ToInt32(Fila.Rows[0]["lpaId"]) != 0)
                        {
                            oAgente.lpaId = Convert.ToInt32(Fila.Rows[0]["lpaId"]);
                        }
                        else
                        {
                            oAgente.lpaId = 0;
                        }
                        if (Convert.ToInt32(Fila.Rows[0]["lpaCodigo"]) != 0)
                        {
                            oAgente.lpaCodigo = Convert.ToInt32(Fila.Rows[0]["lpaCodigo"]);
                        }
                        else
                        {
                            oAgente.lpaCodigo = 0;
                        }
                        oAgente.ageNroControl = nrocontrol;

                        if (Fila.Rows[0]["Juris"].ToString().Trim().Length > 0)
                        {
                            oAgente.ageJurisdiccion = Convert.ToString(Fila.Rows[0]["Juris"]);
                        }
                        else
                        {
                            oAgente.ageJurisdiccion = "";
                        }

                        if (Fila.Rows[0]["Prog"].ToString().Trim().Length > 0)
                        {
                            oAgente.agePrograma = Convert.ToString(Fila.Rows[0]["Prog"]);
                        }
                        else
                        {
                            oAgente.agePrograma = "";
                        }
                        if (Fila.Rows[0]["NroCOntrol"].ToString().Trim().Length > 0)
                        {
                            oAgente.ageNroControl = Convert.ToString(Fila.Rows[0]["NroCOntrol"]);
                        }
                        else
                        {
                            oAgente.ageNroControl = "";
                        }
                    }
                    return oAgente;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public Agente ObtenerAgentePorCuil(string Cuil)
            {
                try
                {
                    Agente oAgente = new Agente();
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[PagosEventuales.ObtenerAgentePorCuil]", new object[,] {
                     {
                            "@Cuil",
                            Cuil
                        }
                });
                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["lpaNombre"].ToString().Trim().Length > 0)
                        {
                            oAgente.LugarPago = Convert.ToString(Fila.Rows[0]["lpaNombre"]);
                        }
                        else
                        {
                            oAgente.LugarPago = "";
                        }
                        if (Fila.Rows[0]["Cuil"].ToString().Trim().Length > 0)
                        {
                            oAgente.ageCUIT = Convert.ToString(Fila.Rows[0]["Cuil"]);
                        }
                        else
                        {
                            oAgente.ageCUIT = "";
                        }
                        if (Fila.Rows[0]["Nombre"].ToString().Trim().Length > 0)
                        {
                            oAgente.ageApellidoNombre = Convert.ToString(Fila.Rows[0]["Nombre"]);
                        }
                        else
                        {
                            oAgente.ageApellidoNombre = "";
                        }
                        if (Fila.Rows[0]["Sexo"].ToString().Trim().Length > 0)
                        {
                            oAgente.ageSexo = Convert.ToString(Fila.Rows[0]["Sexo"]);
                        }
                        else
                        {
                            oAgente.ageSexo = "";
                        }
                        if (Convert.ToInt32(Fila.Rows[0]["lpaId"]) != 0)
                        {
                            oAgente.lpaId = Convert.ToInt32(Fila.Rows[0]["lpaId"]);
                        }
                        else
                        {
                            oAgente.lpaId = 0;
                        }
                        if (Convert.ToInt32(Fila.Rows[0]["lpaCodigo"]) != 0)
                        {
                            oAgente.lpaCodigo = Convert.ToInt32(Fila.Rows[0]["lpaCodigo"]);
                        }
                        else
                        {
                            oAgente.lpaCodigo = 0;
                        }
                        if (Fila.Rows[0]["Juris"].ToString().Trim().Length > 0)
                        {
                            oAgente.ageJurisdiccion = Convert.ToString(Fila.Rows[0]["Juris"]);
                        }
                        else
                        {
                            oAgente.ageJurisdiccion = "";
                        }

                        if (Fila.Rows[0]["Prog"].ToString().Trim().Length > 0)
                        {
                            oAgente.agePrograma = Convert.ToString(Fila.Rows[0]["Prog"]);
                        }
                        else
                        {
                            oAgente.agePrograma = "";
                        }
                        if (Fila.Rows[0]["NroCOntrol"].ToString().Trim().Length > 0)
                        {
                            oAgente.ageNroControl = Convert.ToString(Fila.Rows[0]["NroCOntrol"]);
                        }
                        else
                        {
                            oAgente.ageNroControl = "";
                        }
                    }
                    return oAgente;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public Agente ObtenerAgentePorCuilyLugarDePago(string Cuil, string LugarDePagoCodigo)
            {
                try
                {
                    Agente oAgente = new Agente();
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[PagosEventuales.ObtenerAgentePorCuilyLugarDePago]", new object[,] {
                     {
                            "@Cuil",
                            Cuil
                        },
                    {
                        "@LugarDePagoCodigo",
                        LugarDePagoCodigo
                    }
                });
                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["Cuil"].ToString().Trim().Length > 0)
                        {
                            oAgente.ageCUIT = Convert.ToString(Fila.Rows[0]["Cuil"]);
                        }
                        else
                        {
                            oAgente.ageCUIT = "";
                        }
                        if (Fila.Rows[0]["lpaNombre"].ToString().Trim().Length > 0)
                        {
                            oAgente.LugarPago = Convert.ToString(Fila.Rows[0]["lpaNombre"]);
                        }
                        else
                        {
                            oAgente.LugarPago = "";
                        }
                        if (Fila.Rows[0]["NroCOntrol"].ToString().Trim().Length > 0)
                        {
                            oAgente.ageNroControl = Convert.ToString(Fila.Rows[0]["NroCOntrol"]);
                        }
                        else
                        {
                            oAgente.ageNroControl = "";
                        }
                    }
                    return oAgente;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }            

            public DataTable ObtenerAgentesxFechaDeCarga(DateTime fechacarga)
            {
                try
                {
                    // Agente oAgente = new Agente();
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[PagosEventuales.ObtenerAgentePorFechaDeCarga]", new object[,] {
                     {
                            "@ageFechacarga",
                            fechacarga
                        }
                });
                    if (Fila.Rows.Count > 0)
                    {
                        //if (Fila.Rows[0]["lpaNombre"].ToString().Trim().Length > 0)
                        //{
                        //    oAgente.UnLugPag = Convert.ToString(Fila.Rows[0]["lpaNombre"]);
                        //}
                        //else
                        //{
                        //    oAgente.UnLugPag = "";
                        //}
                        //if (Fila.Rows[0]["Cuil"].ToString().Trim().Length > 0)
                        //{
                        //    oAgente.ageCUIT = Convert.ToString(Fila.Rows[0]["Cuil"]);
                        //}
                        //else
                        //{
                        //    oAgente.ageCUIT = "";
                        //}
                        //if (Fila.Rows[0]["Nombre"].ToString().Trim().Length > 0)
                        //{
                        //    oAgente.ageApellidoNombre = Convert.ToString(Fila.Rows[0]["Nombre"]);
                        //}
                        //else
                        //{
                        //    oAgente.ageApellidoNombre = "";
                        //}
                        //if (Fila.Rows[0]["Sexo"].ToString().Trim().Length > 0)
                        //{
                        //    oAgente.ageSexo = Convert.ToString(Fila.Rows[0]["Sexo"]);
                        //}
                        //else
                        //{
                        //    oAgente.ageSexo = "";
                        //}
                        //if (Convert.ToInt32(Fila.Rows[0]["lpaId"]) != 0)
                        //{
                        //    oAgente.lpaId = Convert.ToInt32(Fila.Rows[0]["lpaId"]);
                        //}
                        //else
                        //{
                        //    oAgente.lpaId = 0;
                        //}
                    }
                    //else
                    //{
                    //    oAgente.ageApellidoNombre = "";
                    //}
                    return Fila;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public DataTable ObtenerRegistrosDeAgentes(DateTime fechacarga)
            {
                try
                {
                    // Agente oAgente = new Agente();
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[PagosEventuales.ArchivoInformaticaGenerar]", new object[,] {
                     {
                            "@ageFechacarga",
                            fechacarga
                        }
                });
                    return Fila;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Actualizar()
            {
                try
                {

                    ocdGestor.EjecutarNonQuery("[PagosEventuales.CambiarEstado]", new object[,] {
                            {
                                "@fecha",
                                pevFechaCarga
                            }
                        });

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }     */       
        }
    }
}
