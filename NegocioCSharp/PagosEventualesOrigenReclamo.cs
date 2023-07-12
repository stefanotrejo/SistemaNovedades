using System;
using System.Data;

namespace LiquidacionSueldos
{
    namespace Negocio
    {
        public class PagosEventualesOrigenReclamo
        {
            #region Propiedades
            private Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila;
            private DataTable Tabla = new DataTable();

            private int _id;
            public int id
            {
                get { return _id; }
                set { _id = value; }
            }

            private String _gedoTipo;
            public string gedoTipo
            {
                get { return _gedoTipo; }
                set { _gedoTipo = value; }
            }
         
            private int _gedoAnio;
            public int gedoAnio
            {
                get { return _gedoAnio; }
                set { _gedoAnio = value; }
            }

            private String _gedoNumero;
            public string gedoNumero
            {
                get { return _gedoNumero; }
                set { _gedoNumero = value; }
            }

            private String _gedoReparticion;
            public string gedoReparticion
            {
                get { return _gedoReparticion; }
                set { _gedoReparticion = value; }
            }

            private String _observacion;
            public string observacion
            {
                get { return _observacion; }
                set { _observacion = value; }
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

            public DataTable ObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[PagosEventualesOrigenReclamo.ObtenerTodo]", new object[,] { {
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
