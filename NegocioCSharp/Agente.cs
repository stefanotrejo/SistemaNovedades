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
        public partial class Agente
        {
            #region Propiedades

            private Datos.Gestor ocdGestor = new Datos.Gestor();

            private DataTable Fila;
            private DataTable Tabla = new DataTable();

            private String _ageApellidoNombre;
            public string ageApellidoNombre
            {
                get { return _ageApellidoNombre; }
                set { _ageApellidoNombre = value; }
            }

            private String _ageDNI;
            public string ageDNI
            {
                get { return _ageDNI; }
                set { _ageDNI = value; }
            }

            private String _UnLugPag;
            public string LugarPago
            {
                get { return _UnLugPag; }
                set { _UnLugPag = value; }
            }

            private float _facimporte;
            public float facimporte
            {
                get { return _facimporte; }
                set { _facimporte = value; }
            }

            private string _ageCUIT;
            public string ageCUIT
            {
                get { return _ageCUIT; }
                set { _ageCUIT = value; }
            }

            private string _ageSexo;
            public string ageSexo
            {
                get { return _ageSexo; }
                set { _ageSexo = value; }
            }

            private String _ageNroControl;
            public string ageNroControl
            {
                get { return _ageNroControl; }
                set { _ageNroControl = value; }
            }

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

            private int _pevId;
            public int pevId
            {
                get { return _pevId; }
                set { _pevId = value; }
            }

            private DateTime _pevFechaCarga;
            public DateTime pevFechaCarga
            {
                get { return _pevFechaCarga; }
                set { _pevFechaCarga = value; }
            }
            private int _pevPagoAcumulado;
            public int pevPagoAcumulado
            {
                get { return _pevPagoAcumulado; }
                set { _pevPagoAcumulado = value; }
            }
            //**********************************DetallePagoEventual
            private int _dpeMes;
            public int dpeMes
            {
                get { return _dpeMes; }
                set { _dpeMes = value; }
            }
            private int _dpeAnio;
            public int dpeAnio
            {
                get { return _dpeAnio; }
                set { _dpeAnio = value; }
            }

            private string _dpeConcepto;
            public string dpeConcepto
            {
                get { return _dpeConcepto; }
                set { _dpeConcepto = value; }
            }

            private string _ageJurisdiccion;
            public string ageJurisdiccion
            {
                get { return _ageJurisdiccion; }
                set { _ageJurisdiccion = value; }
            }

            private string _agePrograma;
            public string agePrograma
            {
                get { return _agePrograma; }
                set { _agePrograma = value; }
            }


            #endregion
            #region Metodos
            //METODOS---------------------------------------------------------------------



            //  public void Insertar(string usuApellido, string usuNombre, string usuNombreIngreso, string usuClave, string usuClaveProvisoria, bool usuCambiarClave, string usuEmail, int perId, int usuIdCreacion, int usuIdUltimaModificacion,
            //    System.DateTime usuFechaHoraCreacion, System.DateTime usuFechaHoraUltimaModificacion, bool usuActivo)
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
            public Agente ObtenerLugarDePagoPorCodigo(int LugarPagoCodigo)
            {
                try
                {
                    Agente oAgente = new Agente();
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[PagosEventuales.[PagosEventuales.ObtenerLugarDePagoPorNroControl]]", new object[,] {
                     {
                            "@LugarPagoCodigo",
                            LugarPagoCodigo
                        }
                });
                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["lpaId"].ToString().Trim().Length > 0)
                        {
                            oAgente.lpaId = Convert.ToInt32(Fila.Rows[0]["lpaId"]);
                        }
                        if (Fila.Rows[0]["UnLugPago"].ToString().Trim().Length > 0)
                        {
                            oAgente.LugarPago = Convert.ToString(Fila.Rows[0]["LugarPago"]);
                        }
                        else
                        {
                            oAgente.LugarPago = "";
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
            }
            #endregion
        }
    }
}
