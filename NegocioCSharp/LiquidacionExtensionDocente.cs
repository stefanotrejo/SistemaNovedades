using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using LiquidacionSueldos.Datos;

namespace LiquidacionSueldos
{
    namespace Negocio
    {
        public class LiquidacionExtensionDocente
        {
            #region Propiedades

            private Gestor ocdGestor = new Gestor();
            private DataTable Tabla = new DataTable();

            private int _id;
            public int id
            {
                get { return _id; }
                set { _id = value; }
            }

            private String _descripcion;
            public string descripcion
            {
                get { return _descripcion; }
                set { _descripcion = value; }
            }

            private String _mes;
            public string mes
            {
                get { return _mes; }
                set { _mes = value; }
            }

            private String _anio;
            public string anio
            {
                get { return _anio; }
                set { _anio = value; }
            }

            private String _mesanio;
            public string mesanio
            {
                get { return _mesanio; }
                set { _mesanio = value; }
            }

            private int _etapa;
            public int etapa
            {
                get { return _etapa; }
                set { _etapa = value; }
            }

            private String _estado;
            public string estado
            {
                get { return _estado; }
                set { _estado = value; }
            }

            private DateTime _fechaInicio;
            public DateTime fechaInicio
            {
                get { return _fechaInicio; }
                set { _fechaInicio = value; }
            }

            private DateTime? _fechaCierre;
            public DateTime? fechaCierre
            {
                get { return _fechaCierre; }
                set { _fechaCierre = value; }
            }
            private int _activo;
            public int activo
            {
                get { return _activo; }
                set { _activo = value; }
            }
            #endregion

            #region Metodos       

            public int Insertar()
            {
                try
                {
                    int IdMax = 0;
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[LiquidacionExtensionDocente.Insertar]", new object[,] {
                        {
                            "@descripcion",
                            descripcion
                        },
                        {
                            "@mes",
                            mes
                        },
                        {
                            "@anio",
                            anio
                        },
                        {
                            "@etapa",
                            etapa
                        },
                        {
                            "@estado",
                            estado
                        }
                    });
                    return IdMax;
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Devuelve la liquidacion Abierta. Sino, devuelve objeto Liquidacion null
            public LiquidacionExtensionDocente ObtenerLiquidacionAbierta()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                LiquidacionExtensionDocente objetoLiquidacion = new LiquidacionExtensionDocente();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[LiquidacionExtensionDocente.LiquidacionAbierta]", new object[,] { });                    
                    if (Tabla.Rows.Count > 0)
                    {
                        if (Tabla.Rows[0]["id"].ToString().Trim().Length > 0)
                            objetoLiquidacion.id = Convert.ToInt32(Tabla.Rows[0]["id"]);
                        else
                            objetoLiquidacion.id = 0;

                        if (Tabla.Rows[0]["descripcion"].ToString().Trim().Length > 0)
                            objetoLiquidacion.descripcion = Tabla.Rows[0]["descripcion"].ToString();
                        else
                            objetoLiquidacion.descripcion = "";

                        if (Tabla.Rows[0]["mes_referencia"].ToString().Trim().Length > 0)
                            objetoLiquidacion.mes = Tabla.Rows[0]["mes_referencia"].ToString();
                        else
                            objetoLiquidacion.mes = "";

                        if (Tabla.Rows[0]["anio_referencia"].ToString().Trim().Length > 0)
                            objetoLiquidacion.anio = Tabla.Rows[0]["anio_referencia"].ToString();
                        else
                            objetoLiquidacion.anio = "";

                        if (objetoLiquidacion.mes != "" & objetoLiquidacion.anio != "")
                            objetoLiquidacion.mesanio = objetoLiquidacion.mes + '/' + objetoLiquidacion.anio;

                        if (Tabla.Rows[0]["etapa"].ToString().Trim().Length > 0)
                            objetoLiquidacion.etapa = Convert.ToInt32(Tabla.Rows[0]["etapa"]);
                        else
                            objetoLiquidacion.etapa = 0;

                        if (Tabla.Rows[0]["estado"].ToString().Trim().Length > 0)

                            objetoLiquidacion.estado = Tabla.Rows[0]["estado"].ToString();
                        else
                            objetoLiquidacion.estado = "";

                        if (Tabla.Rows[0]["fechaInicio"].ToString().Trim().Length > 0)
                            objetoLiquidacion.fechaInicio = Convert.ToDateTime(Tabla.Rows[0]["fechaInicio"].ToString());
                        else
                            objetoLiquidacion.fechaInicio = Convert.ToDateTime("01/01/2001");

                        if (Tabla.Rows[0]["fechaCierre"].ToString().Trim().Length > 0)
                            objetoLiquidacion.fechaCierre = Convert.ToDateTime(Tabla.Rows[0]["fechaCierre"].ToString());
                        else
                            objetoLiquidacion.fechaCierre = Convert.ToDateTime("01/01/2001");

                        if (Tabla.Rows[0]["activo"].ToString().Trim().Length > 0)
                            objetoLiquidacion.activo = Convert.ToInt32(Tabla.Rows[0]["activo"]);
                        else
                            objetoLiquidacion.activo = 0;
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

            public void Actualizar(int liqId, string liqDescripcion, string liqMes, string liqAnio, int liqEtapa, string liqEstado, DateTime liqFechaInicio, DateTime? liqFechaCierre, int liqActivo)
            {
                try
                {
                    ocdGestor = new Datos.Gestor();
                    object[,] objArray = new object[9, 2];
                    objArray[0, 0] = "@id";
                    objArray[0, 1] = liqId;
                    objArray[1, 0] = "@descripcion";
                    objArray[1, 1] = liqDescripcion;
                    objArray[2, 0] = "@mes_referencia";
                    objArray[2, 1] = liqMes;
                    objArray[3, 0] = "@anio_referencia";
                    objArray[3, 1] = liqAnio;
                    objArray[4, 0] = "@etapa";
                    objArray[4, 1] = liqEtapa;
                    objArray[5, 0] = "@estado";
                    objArray[5, 1] = liqEstado;
                    objArray[6, 0] = "@fechaInicio";
                    objArray[6, 1] = liqFechaInicio;
                    objArray[7, 0] = "@fechaCierre";
                    objArray[7, 1] = liqFechaCierre;
                    objArray[8, 0] = "@activo";
                    objArray[8, 1] = liqActivo;

                    ocdGestor.EjecutarNonQuery("[LiquidacionExtensionDocente.Actualizar]", objArray);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }

            public DataTable ObtenerUno(string liqMes, string liqAnio, string liqEtapa)
            {
                try
                {
                    this.Tabla = new DataTable();
                    ocdGestor = new Datos.Gestor();
                    object[,] objArray = new object[3, 2];
                    objArray[0, 0] = "@liqMes";
                    objArray[0, 1] = liqMes;
                    objArray[1, 0] = "@liqAnio";
                    objArray[1, 1] = liqAnio;
                    objArray[2, 0] = "@liqEtapa";
                    objArray[2, 1] = liqEtapa;

                    this.Tabla = ocdGestor.EjecutarReader("[LiquidacionExtensionDocente.ObtenerUno]", objArray);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                return this.Tabla;
            }

            public LiquidacionExtensionDocente ObtenerUno(int id)
            {
                LiquidacionExtensionDocente liquidacionExtensionDocente = new LiquidacionExtensionDocente();
                try
                {
                    this.Tabla = new DataTable();
                    ocdGestor = new Datos.Gestor();
                    object[,] objArray = new object[1, 2];
                    objArray[0, 0] = "@id";
                    objArray[0, 1] = id;
                    this.Tabla = ocdGestor.EjecutarReader("[LiquidacionExtensionDocentes.ObtenerUnoPorLiqId]", objArray);

                    if (this.Tabla.Rows.Count > 0)
                    {
                        if (this.Tabla.Rows[0]["id"].ToString().Trim().Length <= 0)
                        {
                            liquidacionExtensionDocente.id = 0;
                        }
                        else
                        {
                            liquidacionExtensionDocente.id = Convert.ToInt32(this.Tabla.Rows[0]["id"]);
                        }

                        if (this.Tabla.Rows[0]["descripcion"].ToString().Trim().Length <= 0)
                        {
                            liquidacionExtensionDocente.descripcion = "";
                        }
                        else
                        {
                            liquidacionExtensionDocente.descripcion = this.Tabla.Rows[0]["descripcion"].ToString();
                        }

                        if (this.Tabla.Rows[0]["mes_referencia"].ToString().Trim().Length <= 0)
                        {
                            liquidacionExtensionDocente.mes = "";
                        }
                        else
                        {
                            liquidacionExtensionDocente.mes = this.Tabla.Rows[0]["mes_referencia"].ToString();
                        }

                        if (this.Tabla.Rows[0]["anio_referencia"].ToString().Trim().Length <= 0)
                        {
                            liquidacionExtensionDocente.anio = "";
                        }
                        else
                        {
                            liquidacionExtensionDocente.anio = this.Tabla.Rows[0]["anio_referencia"].ToString();
                        }

                        if (this.Tabla.Rows[0]["etapa"].ToString().Trim().Length <= 0)
                        {
                            liquidacionExtensionDocente.etapa = 0;
                        }
                        else
                        {
                            liquidacionExtensionDocente.etapa = Convert.ToInt32(this.Tabla.Rows[0]["etapa"]);
                        }

                        if (this.Tabla.Rows[0]["estado"].ToString().Trim().Length <= 0)
                        {
                            liquidacionExtensionDocente.estado = "";
                        }
                        else
                        {
                            liquidacionExtensionDocente.estado = this.Tabla.Rows[0]["estado"].ToString();
                        }

                        if (this.Tabla.Rows[0]["fechaInicio"].ToString().Trim().Length <= 0)
                        {
                            liquidacionExtensionDocente.fechaInicio = Convert.ToDateTime("01/01/2001");
                        }
                        else
                        {
                            liquidacionExtensionDocente.fechaInicio = Convert.ToDateTime(this.Tabla.Rows[0]["fechaInicio"].ToString());
                        }

                        if (this.Tabla.Rows[0]["fechaCierre"].ToString().Trim().Length <= 0)
                        {
                            liquidacionExtensionDocente.fechaCierre = new DateTime?(Convert.ToDateTime("01/01/2001"));
                        }
                        else
                        {
                            liquidacionExtensionDocente.fechaCierre = new DateTime?(Convert.ToDateTime(this.Tabla.Rows[0]["fechaCierre"].ToString()));
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }

                return liquidacionExtensionDocente;
            }

            public int ValidarRepetido(string liqMes, string liqAnio, int liqEtapa)
            {
                this.ocdGestor = new Gestor();
                this.Tabla = new DataTable();
                int num = 0;
                try
                {
                    Gestor gestor = this.ocdGestor;
                    object[,] objArray = new object[3, 2];
                    objArray[0, 0] = "@liqMes";
                    objArray[0, 1] = liqMes;
                    objArray[1, 0] = "@liqAnio";
                    objArray[1, 1] = liqAnio;
                    objArray[2, 0] = "@liqEtapa";
                    objArray[2, 1] = liqEtapa;
                    this.Tabla = gestor.EjecutarReader("[LiquidacionNovedades.ValidarDuplicado]", objArray);
                    if (this.Tabla.Rows.Count > 0)
                    {
                        num = Convert.ToInt32(this.Tabla.Rows[0]["Existe"].ToString());
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                return num;
            }

            public void AbrirEtapa(int liqId)
            {
                try
                {
                    Gestor gestor = this.ocdGestor;
                    object[,] objArray = new object[1, 2];
                    objArray[0, 0] = "@liqID_destino";
                    objArray[0, 1] = liqId;
                    gestor.EjecutarNonQuery("[LiquidacionExtensionDocente.AbrirEtapa]", objArray);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            #endregion
        }
    }
}
