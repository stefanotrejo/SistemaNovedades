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
        public class Liquidacion
        {
            #region Propiedades

            private Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Tabla = new DataTable();

            private int _liqId;
            public int liqId
            {
                get { return _liqId; }
                set { _liqId = value; }
            }

            private String _liqDescripcion;
            public string liqDescripcion
            {
                get { return _liqDescripcion; }
                set { _liqDescripcion = value; }
            }

            private String _liqMes;
            public string liqMes
            {
                get { return _liqMes; }
                set { _liqMes = value; }
            }

            private String _liqAnio;
            public string liqAnio
            {
                get { return _liqAnio; }
                set { _liqAnio = value; }
            }

            private int _liqEtapa;
            public int liqEtapa
            {
                get { return _liqEtapa; }
                set { _liqEtapa = value; }
            }

            private String _liqEstado;
            public string liqEstado
            {
                get { return _liqEstado; }
                set { _liqEstado = value; }
            }

            private String _mesAnioLiq;
            public string mesAnioLiq
            {
                get { return _mesAnioLiq; }
                set { _mesAnioLiq = value; }
            }

            private DateTime _liqFechaInicio;
            public DateTime liqFechaInicio
            {
                get { return _liqFechaInicio; }
                set { _liqFechaInicio = value; }
            }

            private DateTime? _liqFechaCierre;
            public DateTime? liqFechaCierre
            {
                get { return _liqFechaCierre; }
                set { _liqFechaCierre = value; }
            }
            private int _liqActivo;
            public int liqActivo
            {
                get { return _liqActivo; }
                set { _liqActivo = value; }
            }
            #endregion

            public int Insertar()
            {
                /* Verificar que no se haya agregado antes una novedad con ese codigo para ese id y etapa
                 */
                try
                {
                    int IdMax = 0;
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[LiquidacionNovedades.Insertar]", new object[,] {
                        {
                            "@liqDescripcion",
                            liqDescripcion
                        },
                        {
                            "@liqMes",
                            liqMes
                        },
                        {
                            "@liqAnio",
                            liqAnio
                        },
                        {
                            "@liqEtapa",
                            liqEtapa
                        },
                        {
                            "@liqEstado",
                            liqEstado
                        },
                        {
                            "@liqFechaInicio",
                            liqFechaInicio
                        }
                    });
                    return IdMax;
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

            /* Devuelve la liquidacion Abierta. Sino, devuelve objeto Liquidacion null.
             */
            public Liquidacion ObtenerLiquidacionAbierta()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                Liquidacion objetoLiquidacion = new Liquidacion();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[LiquidacionNovedades.ObtenerLiquidacionAbierta]", new object[,] { });
                    if (Tabla.Rows.Count > 0)
                    {
                        if (Tabla.Rows[0]["liqId"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqId = Convert.ToInt32(Tabla.Rows[0]["liqId"]);
                        }
                        else
                        {
                            objetoLiquidacion.liqId = 0;
                        }

                        if (Tabla.Rows[0]["liqDescripcion"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqDescripcion = Tabla.Rows[0]["liqDescripcion"].ToString();
                        }
                        else
                        {
                            objetoLiquidacion.liqDescripcion = "";
                        }

                        if (Tabla.Rows[0]["liqMes"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqMes = Tabla.Rows[0]["liqMes"].ToString();
                        }
                        else
                        {
                            objetoLiquidacion.liqMes = "";
                        }


                        if (Tabla.Rows[0]["liqAnio"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqAnio = Tabla.Rows[0]["liqAnio"].ToString();
                        }
                        else
                        {
                            objetoLiquidacion.liqAnio = "";
                        }

                        if (objetoLiquidacion.liqMes != "" & objetoLiquidacion.liqAnio != "")
                        {
                            objetoLiquidacion.mesAnioLiq = objetoLiquidacion.liqMes + '/' + objetoLiquidacion.liqAnio;
                        }

                        if (Tabla.Rows[0]["liqEtapa"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqEtapa = Convert.ToInt32(Tabla.Rows[0]["liqEtapa"]);
                        }
                        else
                        {
                            objetoLiquidacion.liqEtapa = 0;
                        }

                        if (Tabla.Rows[0]["liqEstado"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqEstado = Tabla.Rows[0]["liqEstado"].ToString();
                        }
                        else
                        {
                            objetoLiquidacion.liqEstado = "";
                        }


                        if (Tabla.Rows[0]["liqFechaInicio"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqFechaInicio = Convert.ToDateTime(Tabla.Rows[0]["liqFechaInicio"].ToString());
                        }
                        else
                        {
                            objetoLiquidacion.liqFechaInicio = Convert.ToDateTime("01/01/2001");
                        }

                        if (Tabla.Rows[0]["liqFechaCierre"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqFechaCierre = Convert.ToDateTime(Tabla.Rows[0]["liqFechaCierre"].ToString());
                        }
                        else
                        {
                            objetoLiquidacion.liqFechaCierre = Convert.ToDateTime("01/01/2001");
                        }

                        if (Tabla.Rows[0]["liqActivo"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqActivo = Convert.ToInt32(Tabla.Rows[0]["liqActivo"]);
                        }
                        else
                        {
                            objetoLiquidacion.liqActivo = 0;
                        }
                    }
                    else
                        objetoLiquidacion = null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return objetoLiquidacion;
            }

            public Liquidacion ObtenerLiquidacionAbiertaPersonal()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                Liquidacion objetoLiquidacion = new Liquidacion();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[LiquidacionNovedades.ObtenerLiquidacionAbiertaPersonal]", new object[,] { });
                    if (Tabla.Rows.Count > 0)
                    {
                        if (Tabla.Rows[0]["liqId"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqId = Convert.ToInt32(Tabla.Rows[0]["liqId"]);
                        }
                        else
                        {
                            objetoLiquidacion.liqId = 0;
                        }

                        if (Tabla.Rows[0]["liqDescripcion"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqDescripcion = Tabla.Rows[0]["liqDescripcion"].ToString();
                        }
                        else
                        {
                            objetoLiquidacion.liqDescripcion = "";
                        }

                        if (Tabla.Rows[0]["liqMes"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqMes = Tabla.Rows[0]["liqMes"].ToString();
                        }
                        else
                        {
                            objetoLiquidacion.liqMes = "";
                        }


                        if (Tabla.Rows[0]["liqAnio"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqAnio = Tabla.Rows[0]["liqAnio"].ToString();
                        }
                        else
                        {
                            objetoLiquidacion.liqAnio = "";
                        }

                        if (objetoLiquidacion.liqMes != "" & objetoLiquidacion.liqAnio != "")
                        {
                            objetoLiquidacion.mesAnioLiq = objetoLiquidacion.liqMes + '/' + objetoLiquidacion.liqAnio;
                        }

                        if (Tabla.Rows[0]["liqEtapa"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqEtapa = Convert.ToInt32(Tabla.Rows[0]["liqEtapa"]);
                        }
                        else
                        {
                            objetoLiquidacion.liqEtapa = 0;
                        }

                        if (Tabla.Rows[0]["liqEstado"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqEstado = Tabla.Rows[0]["liqEstado"].ToString();
                        }
                        else
                        {
                            objetoLiquidacion.liqEstado = "";
                        }


                        if (Tabla.Rows[0]["liqFechaInicio"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqFechaInicio = Convert.ToDateTime(Tabla.Rows[0]["liqFechaInicio"].ToString());
                        }
                        else
                        {
                            objetoLiquidacion.liqFechaInicio = Convert.ToDateTime("01/01/2001");
                        }

                        if (Tabla.Rows[0]["liqFechaCierre"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqFechaCierre = Convert.ToDateTime(Tabla.Rows[0]["liqFechaCierre"].ToString());
                        }
                        else
                        {
                            objetoLiquidacion.liqFechaCierre = Convert.ToDateTime("01/01/2001");
                        }

                        if (Tabla.Rows[0]["liqActivo"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqActivo = Convert.ToInt32(Tabla.Rows[0]["liqActivo"]);
                        }
                        else
                        {
                            objetoLiquidacion.liqActivo = 0;
                        }
                    }
                    else
                        objetoLiquidacion = null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return objetoLiquidacion;
            }

            public DataTable ObtenerTodos(string liqMes, string liqAnio, int liqEtapa)
            {
                try
                {
                    Tabla = new DataTable();
                    Tabla = ocdGestor.EjecutarReader("[LiquidacionNovedades.ObtenerTodoPorMesAnio]", new object[,] {
                     {
                            "@liqMes",
                            liqMes
                        },
                      {
                            "@liqAnio",
                            liqAnio
                        },
                      {
                            "@liqEtapa",
                            liqEtapa
                        }
                });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Tabla;
            }

            public DataTable ObtenerUno(string liqMes, string liqAnio, string liqEtapa)
            {
                try
                {
                    Tabla = new DataTable();
                    Tabla = ocdGestor.EjecutarReader("[LiquidacionNovedades.ObtenerUno]", new object[,] {
                     {
                            "@liqMes",
                            liqMes
                        },
                      {
                            "@liqAnio",
                            liqAnio
                        },
                       {
                            "@liqEtapa",
                            liqEtapa
                        }
                });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Tabla;
            }

            public Liquidacion ObtenerUno(int liqId)
            {
                Liquidacion objetoLiquidacion = new Liquidacion();
                try
                {
                    Tabla = new DataTable();
                    Tabla = ocdGestor.EjecutarReader("[LiquidacionNovedades.ObtenerUnoPorLiqId]", new object[,] {
                     {
                            "@liqId",
                            liqId
                        }
                });
                    if (Tabla.Rows.Count > 0)
                    {
                        if (Tabla.Rows[0]["liqId"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqId = Convert.ToInt32(Tabla.Rows[0]["liqId"]);
                        }
                        else
                        {
                            objetoLiquidacion.liqId = 0;
                        }

                        if (Tabla.Rows[0]["liqDescripcion"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqDescripcion = Tabla.Rows[0]["liqDescripcion"].ToString();
                        }
                        else
                        {
                            objetoLiquidacion.liqDescripcion = "";
                        }

                        if (Tabla.Rows[0]["liqMes"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqMes = Tabla.Rows[0]["liqMes"].ToString();
                        }
                        else
                        {
                            objetoLiquidacion.liqMes = "";
                        }

                        if (Tabla.Rows[0]["liqAnio"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqAnio = Tabla.Rows[0]["liqAnio"].ToString();
                        }
                        else
                        {
                            objetoLiquidacion.liqAnio = "";
                        }

                        if (Tabla.Rows[0]["liqEtapa"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqEtapa = Convert.ToInt32(Tabla.Rows[0]["liqEtapa"]);
                        }
                        else
                        {
                            objetoLiquidacion.liqEtapa = 0;
                        }

                        if (Tabla.Rows[0]["liqEstado"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqEstado = Tabla.Rows[0]["liqEstado"].ToString();
                        }
                        else
                        {
                            objetoLiquidacion.liqEstado = "";
                        }

                        if (Tabla.Rows[0]["liqFechaInicio"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqFechaInicio = Convert.ToDateTime(Tabla.Rows[0]["liqFechaInicio"].ToString());
                        }
                        else
                        {
                            objetoLiquidacion.liqFechaInicio = Convert.ToDateTime("01/01/2001");
                        }

                        if (Tabla.Rows[0]["liqFechaCierre"].ToString().Trim().Length > 0)
                        {
                            objetoLiquidacion.liqFechaCierre = Convert.ToDateTime(Tabla.Rows[0]["liqFechaCierre"].ToString());
                        }
                        else
                        {
                            objetoLiquidacion.liqFechaCierre = Convert.ToDateTime("01/01/2001");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return objetoLiquidacion;
            }

            public DataTable ObtenerTodosSelect()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[LiquidacionNovedades.ObtenerTodosSelect]", new object[,] { });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public void Actualizar(int liqId, string liqDescripcion, string liqMes, string liqAnio, int liqEtapa, string liqEstado, System.DateTime liqFechaInicio, System.DateTime? liqFechaCierre, int liqActivo)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Liquidacion.Actualizar]", new object[,] {
                        {
                            "@liqId",
                            liqId
                        },
                        {
                            "@liqDescripcion",
                            liqDescripcion
                        },
                        {
                            "@liqMes",
                            liqMes
                        },
                        {
                            "@liqAnio",
                            liqAnio
                        },
                        {
                            "@liqEtapa",
                            liqEtapa
                        },
                        {
                            "@liqEstado",
                            liqEstado
                        },
                        {
                            "@liqFechaInicio",
                            liqFechaInicio
                        },
                        {
                            "@liqFechaCierre",
                            liqFechaCierre
                        },
                        {
                            "@liqActivo",
                            liqActivo
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void ActualizarEstado(int liqId, string liqEstado)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[LiquidacionNovedades.ActualizarEstado]", new object[,] {
                        {
                            "@liqId",
                            liqId
                        },
                        {
                            "@liqEstado",
                            liqEstado
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public int ValidarRepetido(string liqMes, string liqAnio, int liqEtapa)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                int Existe = 0;
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[LiquidacionNovedades.ValidarDuplicado]", new object[,] {
                        {
                            "@liqMes",
                            liqMes
                        },
                        {
                            "@liqAnio",
                            liqAnio
                        },
                        {
                            "@liqEtapa",
                            liqEtapa
                        }
                    });

                    if (Tabla.Rows.Count > 0)
                        Existe = Convert.ToInt32(Tabla.Rows[0]["Existe"].ToString());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Existe;
            }



        }
    }
}
