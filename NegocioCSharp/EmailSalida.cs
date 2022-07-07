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
        public partial class EmailSalida
        {

            private Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila;

            private DataTable Tabla = new DataTable();
            private int _esaId;
            public int esaId
            {
                get { return _esaId; }
                set { _esaId = value; }
            }

            private System.DateTime _esaFecha;
            public System.DateTime esaFecha
            {
                get { return _esaFecha; }
                set { _esaFecha = value; }
            }

            private string _esaPara;
            public string esaPara
            {
                get { return _esaPara; }
                set { _esaPara = value; }
            }

            private string _esaTipo;
            public string esaTipo
            {
                get { return _esaTipo; }
                set { _esaTipo = value; }
            }

            private string _esaTitulo;
            public string esaTitulo
            {
                get { return _esaTitulo; }
                set { _esaTitulo = value; }
            }

            private string _esaCuerpo;
            public string esaCuerpo
            {
                get { return _esaCuerpo; }
                set { _esaCuerpo = value; }
            }

            private string _esaDescripcion;
            public string esaDescripcion
            {
                get { return _esaDescripcion; }
                set { _esaDescripcion = value; }
            }

            private bool _esaActivo;
            public bool esaActivo
            {
                get { return _esaActivo; }
                set { _esaActivo = value; }
            }

            private System.DateTime _esaFechaHoraCreacion;
            public System.DateTime esaFechaHoraCreacion
            {
                get { return _esaFechaHoraCreacion; }
                set { _esaFechaHoraCreacion = value; }
            }

            private System.DateTime _esaFechaHoraUltimaModificacion;
            public System.DateTime esaFechaHoraUltimaModificacion
            {
                get { return _esaFechaHoraUltimaModificacion; }
                set { _esaFechaHoraUltimaModificacion = value; }
            }

            private int _cuoId;
            public int cuoId
            {
                get { return _cuoId; }
                set { _cuoId = value; }
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

            public EmailSalida()
            {
                try
                {
                    this.esaId = 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public EmailSalida(int esaId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[EmailSalida.ObtenerUno]", new object[,] { {
                        "@esaId",
                        esaId
                    } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["esaId"].ToString().Trim().Length > 0)
                        {
                            this.esaId = Convert.ToInt32(Fila.Rows[0]["esaId"]);
                        }
                        else
                        {
                            this.esaId = 0;
                        }

                        if (Fila.Rows[0]["esaFecha"].ToString().Trim().Length > 0)
                        {
                            this.esaFecha = Convert.ToDateTime(Fila.Rows[0]["esaFecha"]);
                        }
                        else
                        {
                            this.esaFecha = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["esaPara"].ToString().Trim().Length > 0)
                        {
                            this.esaPara = Convert.ToString(Fila.Rows[0]["esaPara"]);
                        }
                        else
                        {
                            this.esaPara = "";
                        }

                        if (Fila.Rows[0]["esaTipo"].ToString().Trim().Length > 0)
                        {
                            this.esaTipo = Convert.ToString(Fila.Rows[0]["esaTipo"]);
                        }
                        else
                        {
                            this.esaTipo = "";
                        }

                        if (Fila.Rows[0]["esaTitulo"].ToString().Trim().Length > 0)
                        {
                            this.esaTitulo = Convert.ToString(Fila.Rows[0]["esaTitulo"]);
                        }
                        else
                        {
                            this.esaTitulo = "";
                        }

                        if (Fila.Rows[0]["esaCuerpo"].ToString().Trim().Length > 0)
                        {
                            this.esaCuerpo = Convert.ToString(Fila.Rows[0]["esaCuerpo"]);
                        }
                        else
                        {
                            this.esaCuerpo = "";
                        }

                        if (Fila.Rows[0]["esaDescripcion"].ToString().Trim().Length > 0)
                        {
                            this.esaDescripcion = Convert.ToString(Fila.Rows[0]["esaDescripcion"]);
                        }
                        else
                        {
                            this.esaDescripcion = "";
                        }

                        if (Fila.Rows[0]["esaFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.esaFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["esaFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.esaFechaHoraCreacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["esaFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.esaFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["esaFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.esaFechaHoraUltimaModificacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["esaActivo"].ToString().Trim().Length > 0)
                        {
                            this.esaActivo = (Convert.ToInt32(Fila.Rows[0]["esaActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.esaActivo = false;
                        }

                        if (Fila.Rows[0]["cuoId"].ToString().Trim().Length > 0)
                        {
                            this.cuoId = Convert.ToInt32(Fila.Rows[0]["cuoId"]);
                        }
                        else
                        {
                            this.cuoId = 0;
                        }

                        if (Fila.Rows[0]["usuIdCreacion"].ToString().Trim().Length > 0)
                        {
                            this.usuIdCreacion = Convert.ToInt32(Fila.Rows[0]["usuIdCreacion"]);
                        }
                        else
                        {
                            this.usuIdCreacion = 0;
                        }

                        if (Fila.Rows[0]["usuIdUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.usuIdUltimaModificacion = Convert.ToInt32(Fila.Rows[0]["usuIdUltimaModificacion"]);
                        }
                        else
                        {
                            this.usuIdUltimaModificacion = 0;
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public EmailSalida(int esaId, System.DateTime esaFecha, string esaPara, string esaTipo, string esaTitulo, string esaCuerpo, string esaDescripcion, bool esaActivo, System.DateTime esaFechaHoraCreacion, System.DateTime esaFechaHoraUltimaModificacion,
            int IcuoId, int IusuIdCreacion, int IusuIdUltimaModificacion)
            {
                try
                {
                    this.esaId = esaId;
                    this.esaFecha = esaFecha;
                    this.esaPara = esaPara;
                    this.esaTipo = esaTipo;
                    this.esaTitulo = esaTitulo;
                    this.esaCuerpo = esaCuerpo;
                    this.esaDescripcion = esaDescripcion;
                    this.esaActivo = esaActivo;
                    this.esaFechaHoraCreacion = esaFechaHoraCreacion;
                    this.esaFechaHoraUltimaModificacion = esaFechaHoraUltimaModificacion;
                    this.cuoId = cuoId;
                    this.usuIdCreacion = usuIdCreacion;
                    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            public DataTable ObtenerParametros()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EmailSalida.ObtenerParametros]", new object[,]{});
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EmailSalida.ObtenerTodo]", new object[,]{});
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoCustom()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EmailSalida.ObtenerTodoCustom]", new object[,]{});
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(int esaId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EmailSalida.ObtenerUno]", new object[,] { {
                        "@esaId",
                        esaId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerValidarParametro()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[EmailSalida.ObtenerValidarParametro]", new object[,]{});
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public void Actualizar(int esaId, System.DateTime esaFecha, string esaPara, string esaTipo, string esaTitulo, string esaCuerpo, string esaDescripcion, int cuoId, bool esaActivo, int usuIdCreacion,
            int usuIdUltimaModificacion, System.DateTime esaFechaHoraCreacion, System.DateTime esaFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[EmailSalida.Actualizar]", new object[,] {
                        {
                            "@esaId",
                            esaId
                        },
                        {
                            "@esaFecha",
                            esaFecha
                        },
                        {
                            "@esaPara",
                            esaPara
                        },
                        {
                            "@esaTipo",
                            esaTipo
                        },
                        {
                            "@esaTitulo",
                            esaTitulo
                        },
                        {
                            "@esaCuerpo",
                            esaCuerpo
                        },
                        {
                            "@esaDescripcion",
                            esaDescripcion
                        },
                        {
                            "@cuoId",
                            cuoId
                        },
                        {
                            "@esaActivo",
                            esaActivo
                        },
                        {
                            "@usuIdCreacion",
                            usuIdCreacion
                        },
                        {
                            "@usuIdUltimaModificacion",
                            usuIdUltimaModificacion
                        },
                        {
                            "@esaFechaHoraCreacion",
                            esaFechaHoraCreacion
                        },
                        {
                            "@esaFechaHoraUltimaModificacion",
                            esaFechaHoraUltimaModificacion
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Eliminar(int esaId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[EmailSalida.Eliminar]", new object[,] { {
                        "@esaId",
                        esaId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Generar(string QueEnviar, int Mes, int Año, int usuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[EmailSalida.Generar]", new object[,] {
                        {
                            "@QueEnviar",
                            QueEnviar
                        },
                        {
                            "@Mes",
                            Mes
                        },
                        {
                            "@Año",
                            Año
                        },
                        {
                            "@usuId",
                            usuId
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Insertar(System.DateTime esaFecha, string esaPara, string esaTipo, string esaTitulo, string esaCuerpo, string esaDescripcion, int cuoId, bool esaActivo, int usuIdCreacion, int usuIdUltimaModificacion,
            System.DateTime esaFechaHoraCreacion, System.DateTime esaFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[EmailSalida.Insertar]", new object[,] {
                        {
                            "@esaFecha",
                            esaFecha
                        },
                        {
                            "@esaPara",
                            esaPara
                        },
                        {
                            "@esaTipo",
                            esaTipo
                        },
                        {
                            "@esaTitulo",
                            esaTitulo
                        },
                        {
                            "@esaCuerpo",
                            esaCuerpo
                        },
                        {
                            "@esaDescripcion",
                            esaDescripcion
                        },
                        {
                            "@cuoId",
                            cuoId
                        },
                        {
                            "@esaActivo",
                            esaActivo
                        },
                        {
                            "@usuIdCreacion",
                            usuIdCreacion
                        },
                        {
                            "@usuIdUltimaModificacion",
                            usuIdUltimaModificacion
                        },
                        {
                            "@esaFechaHoraCreacion",
                            esaFechaHoraCreacion
                        },
                        {
                            "@esaFechaHoraUltimaModificacion",
                            esaFechaHoraUltimaModificacion
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void RegistrarEnvio(int esaId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[EmailSalida.RegistrarEnvio]", new object[,] { {
                        "@esaId",
                        esaId
                    } });
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
                    if (this.esaId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[EmailSalida.Actualizar]", new object[,] {
                            {
                                "@esaId",
                                esaId
                            },
                            {
                                "@esaFecha",
                                esaFecha
                            },
                            {
                                "@esaPara",
                                esaPara
                            },
                            {
                                "@esaTipo",
                                esaTipo
                            },
                            {
                                "@esaTitulo",
                                esaTitulo
                            },
                            {
                                "@esaCuerpo",
                                esaCuerpo
                            },
                            {
                                "@esaDescripcion",
                                esaDescripcion
                            },
                            {
                                "@cuoId",
                                cuoId
                            },
                            {
                                "@esaActivo",
                                esaActivo
                            },
                            {
                                "@usuIdCreacion",
                                usuIdCreacion
                            },
                            {
                                "@usuIdUltimaModificacion",
                                usuIdUltimaModificacion
                            },
                            {
                                "@esaFechaHoraCreacion",
                                esaFechaHoraCreacion
                            },
                            {
                                "@esaFechaHoraUltimaModificacion",
                                esaFechaHoraUltimaModificacion
                            }
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Eliminar()
            {
                try
                {
                    if (this.esaId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[EmailSalida.Eliminar]", new object[,] { {
                            "@esaId",
                            esaId
                        } });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public int Insertar()
            {
                int IdMax = 0;
                try
                {
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[EmailSalida.Insertar]", new object[,] {
                        {
                            "@esaFecha",
                            esaFecha
                        },
                        {
                            "@esaPara",
                            esaPara
                        },
                        {
                            "@esaTipo",
                            esaTipo
                        },
                        {
                            "@esaTitulo",
                            esaTitulo
                        },
                        {
                            "@esaCuerpo",
                            esaCuerpo
                        },
                        {
                            "@esaDescripcion",
                            esaDescripcion
                        },
                        {
                            "@cuoId",
                            cuoId
                        },
                        {
                            "@esaActivo",
                            esaActivo
                        },
                        {
                            "@usuIdCreacion",
                            usuIdCreacion
                        },
                        {
                            "@usuIdUltimaModificacion",
                            usuIdUltimaModificacion
                        },
                        {
                            "@esaFechaHoraCreacion",
                            esaFechaHoraCreacion
                        },
                        {
                            "@esaFechaHoraUltimaModificacion",
                            esaFechaHoraUltimaModificacion
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdMax;
            }

        }
    }
}







