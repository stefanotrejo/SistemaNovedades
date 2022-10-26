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
        public partial class NovedadExtensionDocente
        {
            #region Variables
            private Datos.Gestor ocdGestor = new Datos.Gestor();

            private DataTable Fila;
            private DataTable Tabla = new DataTable();

            #endregion

            #region Propiedades
            private int _id;
            public int id
            {
                get { return _id; }
                set { _id = value; }
            }

            private int _ageId;
            public int ageId
            {
                get { return _ageId; }
                set { _ageId = value; }
            }

            private int _ageNrocontrol;
            public int ageNrocontrol
            {
                get { return _ageNrocontrol; }
                set { _ageNrocontrol = value; }
            }

            private int _dias_descontar;
            public int dias_descontar
            {
                get { return _dias_descontar; }
                set { _dias_descontar = value; }
            }

            private int _liqId;
            public int liqId
            {
                get { return _liqId; }
                set { _liqId = value; }
            }

            private int _usuId;
            public int usuId
            {
                get { return _usuId; }
                set { _usuId = value; }
            }

            private DateTime _fechaHoraCrea;
            public DateTime fechaHoraCrea
            {
                get { return _fechaHoraCrea; }
                set { _fechaHoraCrea = value; }
            }

            private DateTime _fechaHoraActualiza;
            public DateTime fechaHoraActualiza
            {
                get { return _fechaHoraActualiza; }
                set { _fechaHoraActualiza = value; }
            }

            private DateTime _fechaHoraElimina;
            public DateTime fechaHoraElimina
            {
                get { return _fechaHoraElimina; }
                set { _fechaHoraElimina = value; }
            }

            private int _usuCrea_id;
            public int usuCrea_id
            {
                get { return _usuCrea_id; }
                set { _usuCrea_id = value; }
            }

            private int _usuActualiza_id;
            public int usuActualiza_id
            {
                get { return _usuActualiza_id; }
                set { _usuActualiza_id = value; }
            }

            private int _usuElimina_id;
            public int usuElimina_id
            {
                get { return _usuElimina_id; }
                set { _usuElimina_id = value; }
            }

            private int _activo;
            public int activo
            {
                get { return _activo; }
                set { _activo = value; }
            }

            #endregion

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
            // FIN - PARA INFORMES 
                        
            #region Metodos

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

            public DataTable ObtenerTodoPorAgenteEtapa(int ageId, int liqId)
            {
                ocdGestor = new Datos.Gestor();
                /*Traer liqId basandome en cual esta con estado=abierto en la tabla Liquidacion*/
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[NovedadInasistencia.ObtenerTodoPorAgenteEtapa]", new object[,] {
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

            public DataTable ObtenerUno(int ninId)
            {
                try
                {
                    Tabla = new DataTable();
                    Tabla = ocdGestor.EjecutarReader("[NovedadInasistencia.ObtenerUno]", new object[,] {
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

                // si el  

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
                int num;
                try
                {
                    Gestor gestor = this.ocdGestor;
                    object[,] nuevoAgeId1 = new object[2, 2];
                    nuevoAgeId1[0, 0] = "@NuevoAgeId1";
                    nuevoAgeId1[0, 1] = NuevoAgeId1;
                    nuevoAgeId1[1, 0] = "@liqId";
                    nuevoAgeId1[1, 1] = liqId;
                    num = gestor.EjecutarNonQueryRetornaId("[NovedadInasistencia.ValidarBajaCargoRetenido]", nuevoAgeId1);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                return num;
            }

            #endregion

        }
    }
}
