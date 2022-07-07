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
        public partial class Jurisdiccion
        {
            #region Variables
            private Datos.Gestor ocdGestor = new Datos.Gestor();

            private DataTable Fila;
            private DataTable Tabla = new DataTable();

            #endregion

            #region Propiedades
            private int _jurId;
            public int jurId
            {
                get { return _jurId; }
                set { _jurId = value; }
            }

            private string _jurCodigo;
            public string jurCodigo
            {
                get { return _jurCodigo; }
                set { _jurCodigo = value; }
            }

            private string _jurNombre;
            public string jurNombre
            {
                get { return _jurNombre; }
                set { _jurNombre = value; }
            }


            private int _ftiId;
            public int ftiId
            {
                get { return _ftiId; }
                set { _ftiId = value; }
            }

            private int _jurActivo;
            public int jurActivo
            {
                get { return _jurActivo; }
                set { _jurActivo = value; }
            }

            private int _usuIdCreacion;
            public int usuIdCreacion
            {
                get { return _usuIdCreacion; }
                set { _usuIdCreacion = value; }
            }


            private int _usuIdUltimaModificacion;
            public int usuIdUltimaModificacion
            {
                get { return _usuIdUltimaModificacion; }
                set { _usuIdUltimaModificacion = value; }
            }

            private int _jurFechaHoraCreacion;
            public int jurFechaHoraCreacion
            {
                get { return _jurFechaHoraCreacion; }
                set { _jurFechaHoraCreacion = value; }
            }

            private int _jurFechaHoraUltimaModificacion;
            public int jurFechaHoraUltimaModificacion
            {
                get { return _jurFechaHoraUltimaModificacion; }
                set { _jurFechaHoraUltimaModificacion = value; }
            }
            #endregion

            #region Metodos

            public int Insertar()
            {
                /* Verificar que no se haya agregado antes una novedad con ese codigo para ese id y etapa
                 */
                try
                {
                    int IdMax = 0;
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Jurisdiccion.Insertar]", new object[,] {
                        {
                            "@jurCodigo",
                            jurCodigo
                        },
                        {
                            "@jurNombre",
                            jurNombre
                        },
                        {
                            "@ftiId",
                            ftiId
                        },

                        {
                            "@jurActivo",
                            jurActivo
                        },
                        {
                            "@usuIdCreacion",
                            usuIdCreacion
                        },
                        {
                            "@jurFechaHoraCreacion",
                            jurFechaHoraCreacion
                        }
                    });
                    return IdMax;
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public DataTable ObtenerTodos()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Jurisdiccion.ObtenerTodo]", new object[,] { });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerTodosSelect()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Jurisdiccion.ObtenerTodosSelect]", new object[,] { });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoPorAgenteEtapa(int ageId, int liqId)
            {
                ocdGestor = new Datos.Gestor();
                /*Traer liqId basandome en cual esta con estado=abierto en la tabla Liquidacion*/
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[.ObtenerTodoPorAgenteEtapa]", new object[,] {
                     {
                            "@liqEtapa",
                            liqId
                        },
                     {
                             "@NuevoAgeId1",
                            ageId
                        }
                });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Fila;
            }

            public DataTable ObtenerUno(int ninId)
            {
                try
                {
                    Tabla = new DataTable();
                    Tabla = ocdGestor.EjecutarReader("[.ObtenerUno]", new object[,] {
                     {
                            "@ninId",
                            ninId
                        }
                });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Tabla;
            }

            public int ValidarConceptoRepetido(int ncoId, int ageId, int liqId)
            {
                ocdGestor = new Datos.Gestor();
                int conceptoRepetido = 0;

                // si el  

                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Jurisdiccion.ValidarConceptoRepetido]", new object[,] {
                     {
                            "@liqEtapa",
                            liqId
                        },
                     {
                             "@NuevoAgeId1",
                            ageId
                        },
                       {
                             "@ncoId",
                            ncoId
                        }
                });

                    if (Fila.Rows.Count > 0)
                        conceptoRepetido = Convert.ToInt32(Fila.Rows[0][0]);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return conceptoRepetido;
            }

            public int ValidarConsistencia(int ncoId, int ageId, int liqId)
            {
                ocdGestor = new Datos.Gestor();
                int conceptoRepetido = 0;
                /*Traer liqId basandome en cual esta con estado=abierto en la tabla Liquidacion*/
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Jurisdiccion.ValidarConceptoRepetido]", new object[,] {
                     {
                            "@liqEtapa",
                            liqId
                        },
                     {
                             "@NuevoAgeId1",
                            ageId
                        },
                       {
                             "@ncoId",
                            ncoId
                        }
                });

                    if (Fila.Rows.Count > 0)
                        conceptoRepetido = Convert.ToInt32(Fila.Rows[0][0]);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return conceptoRepetido;
            }

            public void Actualizar(int ninId, int ninCantidad, DateTime ninFechaDesde, int usuActualizaID)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Jurisdiccion.Actualizar]", new object[,] { {
                        "@ninId",
                        ninId
                    },
                    {
                        "@ninCantidad",
                        ninCantidad
                    },
                    {
                        "@ninFechaDesde",
                        ninFechaDesde
                    },
                    {
                        "@usuActualizaID",
                        usuActualizaID
                    }});
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Eliminar(int ninId, int usuEliminaID)
            {
                //Poner la columna Activo del registro de Novedad Inasistencia en 0. 
                try
                {
                    ocdGestor.EjecutarNonQuery("[Jurisdiccion.Eliminar]", new object[,] { {
                        "@ninId",
                        ninId
                    },
                    {
                        "@usuEliminaID",
                        usuEliminaID
                    }});
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
