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
        public class LiquidacionExtensionDocente
        {
            #region Propiedades

            private Datos.Gestor ocdGestor = new Datos.Gestor();
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[LiquidacionNovedades.Insertar]", new object[,] {
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

                        if (Tabla.Rows[0]["mes"].ToString().Trim().Length > 0)
                            objetoLiquidacion.mes = Tabla.Rows[0]["mes"].ToString();
                        else
                            objetoLiquidacion.mes = "";

                        if (Tabla.Rows[0]["anio"].ToString().Trim().Length > 0)
                            objetoLiquidacion.anio = Tabla.Rows[0]["anio"].ToString();
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
         
            #endregion
        }
    }
}
