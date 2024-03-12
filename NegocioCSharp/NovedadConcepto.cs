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
        public partial class NovedadConcepto
        {
            #region Propiedades

            private Datos.Gestor ocdGestor = new Datos.Gestor();

            private DataTable Fila;
            private DataTable Tabla = new DataTable();

            private int _ncoId;
            public int ncoId
            {
                get { return _ncoId; }
                set { _ncoId = value; }
            }

            private String _ncoCod;
            public string ncoCod
            {
                get { return _ncoCod; }
                set { _ncoCod = value; }
            }

            private String _ncoNombre;
            public string ncoNombre
            {
                get { return _ncoNombre; }
                set { _ncoNombre = value; }
            }

            private int _ncoActivo;
            public int ncoActivo
            {
                get { return _ncoActivo; }
                set { _ncoActivo = value; }
            }
            #endregion

            #region Metodos        
                
            //public int Insertar()
            //{
            //    /* Verificar que no se haya agregado antes una novedad con ese codigo para ese id y etapa
            //     */
            //    try
            //    {
            //        int IdMax = 0;
            //        IdMax = ocdGestor.EjecutarNonQueryRetornaId("[NovedadInasistencia.Insertar]", new object[,] {
            //            {
            //                "@NuevoAgeId1",
            //                NuevoAgeId1
            //            },
            //            {
            //                "@ncoId",
            //                ncoId
            //            },
            //            {
            //                "@ninFechaRegistra",
            //                ninFechaRegistra
            //            },

            //            {
            //                "@ninFechaDesde",
            //                ninFechaDesde
            //            },
            //            {
            //                "@ninCantidad",
            //                ninCantidad
            //            },
            //            {
            //                "@liqId",
            //                liqId
            //            },
            //            {
            //                "@ninActivo",
            //                ninActivo
            //            }
            //        });
            //        return IdMax;
            //    }

            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}

            //public DataTable ObtenerTodo()
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();
            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[NovedadInasistencia.ObtenerTodo]", new object[,] { });
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }

            //    return Tabla;
            //}

            //public DataTable ObtenerTodoPorAgenteEtapa(int ageId, int liqId)
            //{
            //    ocdGestor = new Datos.Gestor();
            //    Tabla = new DataTable();
            //    /*Traer liqId basandome en cual esta con estado=abierto en la tabla Liquidacion*/
            //    try
            //    {
            //        Tabla = ocdGestor.EjecutarReader("[NovedadInasistencia.ObtenerTodo]", new object[,] { });
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }

            //    return Tabla;
            //}

            //public void Eliminar(int ninId)
            //{
            //    //Poner la columna Activo del registro de Novedad Inasistencia en 0. 
            //    try
            //    {
            //        ocdGestor.EjecutarNonQuery("[NovedadInasistencia.Eliminar]", new object[,] { {
            //            "@ninId",
            //            ninId
            //        } });
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}

            public DataTable ObtenerListaConceptos()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[NovedadConceptos.ObtenerLista]", new object[,] { {
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Tabla;
            }

            public DataTable ObtenerListaConceptosDocentes()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[NovedadConceptos.ObtenerListaDocentes]", new object[,] { {
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Tabla;
            }

            public DataTable ObtenerListaConceptosDescentralizados()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[NovedadConceptos.ObtenerListaDescentralizados]", new object[,] { {
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Tabla;
            }

            public DataTable ObtenerListaBajas()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[NovedadConceptos.ObtenerListaBajas]", new object[,] { {
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Tabla;
            }

            public DataTable ObtenerListaConceptosPlantaContratados()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[NovedadConceptos.ObtenerListaPlantaContratados]", new object[,] { {
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Tabla;
            }

            #endregion
        }
    }
}
