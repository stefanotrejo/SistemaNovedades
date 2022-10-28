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
        public class NovedadExtensionDocente
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

            private string _ageNrocontrol;
            public string ageNrocontrol
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

            public int Insertar()
            {
                //Verificar que no se haya agregado antes una novedad con ese codigo para ese id y etapa
                try
                {
                    int IdMax = 0;
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[NovedadesExtensionDocente.Insertar] ", new object[,] {                        
                        {
                            "@age_nrocontrol",
                            ageNrocontrol
                        },
                        {
                            "@dias_descontar",
                            dias_descontar
                        },
                        {
                            "@liq_id",
                            liqId
                        },
                        {
                            "@usu_id",
                            usuId
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

            public DataTable ObtenerUno(int id)
            {
                try
                {
                    Tabla = new DataTable();
                    Tabla = ocdGestor.EjecutarReader("[NovedadExtensionDocente.ObtenerUno]", new object[,] {
                     {
                            "@id",
                            id
                        }
                });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Tabla;
            }

            public int ValidarRepetido(int liq_id, string nro_control)
            {
                ocdGestor = new Datos.Gestor();
                int repetido = 0;

                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[NovedadesExtensionDocente.ValidarRepetido]", new object[,] {
                     {
                            "@nro_control",
                            nro_control
                        },
                     {
                             "@liq_id",
                            liq_id
                        }
                });

                    if (Fila.Rows.Count > 0)
                        repetido = Convert.ToInt32(Fila.Rows[0][0]);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return repetido;
            }
                    
            public void Eliminar(int id, int usu_id)
            {                
                try
                {
                    ocdGestor.EjecutarNonQuery("[NovedadesExtensionDocente.Eliminar]", new object[,] { {
                        "@id",
                        id
                    },
                    {
                        "@usu_id",
                        usu_id
                    }});
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }                    
        }
    }
}
