using LiquidacionSueldos.Datos;
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
        public partial class NovedadInasistencia
        {
            #region Variables
            private Datos.Gestor ocdGestor = new Datos.Gestor();

            private DataTable Fila;
            private DataTable Tabla = new DataTable();

            #endregion

            #region Propiedades
            private int _NuevoAgeId1;
            public int NuevoAgeId1
            {
                get { return _NuevoAgeId1; }
                set { _NuevoAgeId1 = value; }
            }

            private int _ncoId;
            public int ncoId
            {
                get { return _ncoId; }
                set { _ncoId = value; }
            }

            private int _perEsAdministrador;
            public int perEsAdministrador
            {
                get { return _perEsAdministrador; }
                set { _perEsAdministrador = value; }
            }

            private DateTime _ninFechaRegistro;
            public DateTime ninFechaRegistro
            {
                get { return _ninFechaRegistro; }
                set { _ninFechaRegistro = value; }
            }

            private DateTime _ninFechaDesde;
            public DateTime ninFechaDesde
            {
                get { return _ninFechaDesde; }
                set { _ninFechaDesde = value; }
            }

            private String _ninFechaDesdeString;
            public String ninFechaDesdeString
            {
                get { return _ninFechaDesdeString; }
                set { _ninFechaDesdeString = value; }
            }

            private int _ninCantidad;
            public int ninCantidad
            {
                get { return _ninCantidad; }
                set { _ninCantidad = value; }
            }

            private int _liqId;
            public int liqId
            {
                get { return _liqId; }
                set { _liqId = value; }
            }

            private int _usuCreaID;
            public int usuCreaID
            {
                get { return _usuCreaID; }
                set { _usuCreaID = value; }
            }

            private int _usuEliminaID;
            public int usuEliminaID
            {
                get { return _usuEliminaID; }
                set { _usuEliminaID = value; }
            }

            private int _usuActualizaID;
            public int usuActualizaID
            {
                get { return _usuActualizaID; }
                set { _usuActualizaID = value; }
            }

            // INICIO - PARA INFORMES

            private string _numeroControl;
            public string numeroControl
            {
                get { return _numeroControl; }
                set { _numeroControl = value; }
            }

            private string _planta;
            public string planta
            {
                get { return _planta; }
                set { _planta = value; }
            }

            private string _mes;
            public string mes
            {
                get { return _mes; }
                set { _mes = value; }
            }

            private string _anio;
            public string anio
            {
                get { return _anio; }
                set { _anio = value; }
            }

            private int _ninActivo;
            public int ninActivo
            {
                get { return _ninActivo; }
                set { _ninActivo = value; }
            }
            #endregion

            public int Insertar()
            {
                /* Verificar que no se haya agregado antes una novedad con ese codigo para ese id y etapa
                 */
                try
                {
                    int IdMax = 0;
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[NovedadInasistencia.Insertar]", new object[,] {
                        {
                            "@NuevoAgeId1",
                            NuevoAgeId1
                        },
                        {
                            "@ncoId",
                            ncoId
                        },
                        {
                            "@ninFechaRegistro",
                            ninFechaRegistro
                        },

                        {
                            "@ninFechaDesde",
                            ninFechaDesde
                        },
                        {
                            "@ninCantidad",
                            ninCantidad
                        },
                        {
                            "@liqId",
                            liqId
                        },
                         {
                            "@perEsAdministrador",
                            perEsAdministrador
                        },
                        {
                            "@usuCreaID",
                            usuCreaID
                        },
                        {
                            "@ninActivo",
                            ninActivo
                        }
                    });
                    return IdMax;
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public DataTable ObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[NovedadInasistencia.ObtenerTodo]", new object[,] { });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoPorAgenteEtapa(int ageId, int liqId, int userId)
            {
                ocdGestor = new Datos.Gestor();
                /*Traer liqId basandome en cual esta con estado=abierto en la tabla Liquidacion*/
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[NovedadInasistencia.ObtenerTodoPorAgenteEtapaV2]", new object[,] {
                     {
                            "@liqEtapa",
                            liqId
                        },
                     {
                             "@NuevoAgeId1",
                            ageId
                        },
                     {
                             "@userId",
                            userId
                        }
                });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Fila;
            }

            public DataTable ObtenerTodoLiquidacionJurisdiccion(int liqId, int jurId)
            {
                ocdGestor = new Datos.Gestor();
                /*Traer liqId basandome en cual esta con estado=abierto en la tabla Liquidacion*/
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[NovedadInasistencia.InformeNovedadesCargadasJurisdiccion]", new object[,] {
                     {
                            "@liqId",
                            liqId
                        },
                     {
                             "@jurId",
                            jurId
                        }
                });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Fila;
            }

            public NovedadInasistencia ObtenerUno(int ninId)
            {
                Tabla = new DataTable();
                NovedadInasistencia novedadInasistencia = new NovedadInasistencia();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[NovedadInasistencia.ObtenerUno]", new object[,] {
                     {
                            "@ninId",
                            ninId
                        }});

                    if (Tabla == null)
                    {
                        return null;
                    }

                    novedadInasistencia.ncoId = Int32.Parse(Convert.ToString(Tabla.Rows[0]["ncoId"]));
                    novedadInasistencia.ninCantidad = Int32.Parse(Convert.ToString(Tabla.Rows[0]["ninCantidad"]));
                    novedadInasistencia.ninFechaDesdeString = Tabla.Rows[0]["ninFechaDesde"].ToString();
                    return novedadInasistencia;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public DataTable GenerarNoPresentismo(int liqId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[NovedadInasistencia.GenerarNoPresentismo]", new object[,] {
                    {
                            "@liqId",
                            liqId
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable GenerarMultasSuspensiones(int liqId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[NovedadInasistencia.GenerarMultasSuspensiones]", new object[,] {
                    {
                            "@liqId",
                            liqId
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable GenerarListadoTestigoNoPresentismo(int liqId, int perEsAdministrador)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[NovedadInasistencia.ListadoTestigoNoPresentismo]", new object[,] {
                    {
                            "@liqId",
                            liqId
                        },
                      {
                            "@perEsAdministrador",
                            perEsAdministrador
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable GenerarArchivoNoPresentismo(int liqId, int perEsAdministrador)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[NovedadInasistencia.ArchivoNoPresentismo]", new object[,] {
                    {
                            "@liqId",
                            liqId
                        },
                      {
                            "@perEsAdministrador",
                            perEsAdministrador
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable PerfilesConNovedades(int liqId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[NovedadInasistencia.PerfilesConNovedades]", new object[,] {
                    {
                            "@liqId",
                            liqId
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable GenerarDbfMultasSuspensiones(int liqId, string rutaDestino, string etapaLiquidacion)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[NovedadInasistencia.GenerarMultasSuspensionesFinal]", new object[,] {
                    {
                            "@liqId",
                            liqId
                        }
                    });
                    ocdGestor.GenerarDbfMultasSuspensiones(Tabla, rutaDestino, etapaLiquidacion);
                }

                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable GenerarDbfBajas(int liqId, string rutaDestino, string etapaLiquidacion)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[NovedadInasistencia.GenerarBajasFinal]", new object[,] {
                    {
                            "@liqId",
                            liqId
                        }
                    });
                    ocdGestor.GenerarDbfBajas(Tabla, rutaDestino, etapaLiquidacion);
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
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[NovedadInasistencia.ValidarConceptoRepetido]", new object[,] {
                     {
                            "@liqId",
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
                    Fila = ocdGestor.EjecutarReader("[NovedadInasistencia.ValidarConceptoRepetido]", new object[,] {
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
                    ocdGestor.EjecutarNonQuery("[NovedadInasistencia.Actualizar]", new object[,] { {
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
                    ocdGestor.EjecutarNonQuery("[NovedadInasistencia.Eliminar]", new object[,] { {
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

            public int ValidarBajaCargoRetenido(int NuevoAgeId1, int liqId)
            {                
                try
                {
                    Gestor gestor = this.ocdGestor;
                    object[,] nuevoAgeId1 = new object[2, 2];
                    nuevoAgeId1[0, 0] = "@NuevoAgeId1";
                    nuevoAgeId1[0, 1] = NuevoAgeId1;
                    nuevoAgeId1[1, 0] = "@liqId";
                    nuevoAgeId1[1, 1] = liqId;
                    return gestor.EjecutarNonQueryRetornaId("[NovedadInasistencia.ValidarBajaCargoRetenido]", nuevoAgeId1);
                }
                catch (Exception exception)
                {
                    throw exception;
                }                
            }
        }
    }
}
