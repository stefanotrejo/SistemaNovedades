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
        public partial class Parametro
        {

            private Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila;

            private DataTable Tabla = new DataTable();
            private int _parId;
            public int parId
            {
                get { return _parId; }
                set { _parId = value; }
            }

            private string _parNombre;
            public string parNombre
            {
                get { return _parNombre; }
                set { _parNombre = value; }
            }

            private string _parValor;
            public string parValor
            {
                get { return _parValor; }
                set { _parValor = value; }
            }

            private bool _parActivo;
            public bool parActivo
            {
                get { return _parActivo; }
                set { _parActivo = value; }
            }

            private System.DateTime _parFechaHoraCreacion;
            public System.DateTime parFechaHoraCreacion
            {
                get { return _parFechaHoraCreacion; }
                set { _parFechaHoraCreacion = value; }
            }

            private System.DateTime _parFechaHoraUltimaModificacion;
            public System.DateTime parFechaHoraUltimaModificacion
            {
                get { return _parFechaHoraUltimaModificacion; }
                set { _parFechaHoraUltimaModificacion = value; }
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

            public Parametro()
            {
                try
                {
                    this.parId = 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public Parametro(int parId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Parametro.ObtenerUno]", new object[,] { {
                        "@parId",
                        parId
                    } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["parId"].ToString().Trim().Length > 0)
                        {
                            this.parId = Convert.ToInt32(Fila.Rows[0]["parId"]);
                        }
                        else
                        {
                            this.parId = 0;
                        }

                        if (Fila.Rows[0]["parNombre"].ToString().Trim().Length > 0)
                        {
                            this.parNombre = Convert.ToString(Fila.Rows[0]["parNombre"]);
                        }
                        else
                        {
                            this.parNombre = "";
                        }

                        if (Fila.Rows[0]["parValor"].ToString().Trim().Length > 0)
                        {
                            this.parValor = Convert.ToString(Fila.Rows[0]["parValor"]);
                        }
                        else
                        {
                            this.parValor = "";
                        }

                        if (Fila.Rows[0]["parFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.parFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["parFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.parFechaHoraCreacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["parFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.parFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["parFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.parFechaHoraUltimaModificacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["parActivo"].ToString().Trim().Length > 0)
                        {
                            this.parActivo = (Convert.ToInt32(Fila.Rows[0]["parActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.parActivo = false;
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

            public Parametro(int parId, string parNombre, string parValor, bool parActivo, System.DateTime parFechaHoraCreacion, System.DateTime parFechaHoraUltimaModificacion, int IusuIdCreacion, int IusuIdUltimaModificacion)
            {
                try
                {
                    this.parId = parId;
                    this.parNombre = parNombre;
                    this.parValor = parValor;
                    this.parActivo = parActivo;
                    this.parFechaHoraCreacion = parFechaHoraCreacion;
                    this.parFechaHoraUltimaModificacion = parFechaHoraUltimaModificacion;
                    this.usuIdCreacion = usuIdCreacion;
                    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            public DataTable ObtenerBuscador(string ValorABuscar)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerBuscador]", new object[,] { {
                        "@ValorABuscar",
                        ValorABuscar
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerCompararBasesDatos()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerCompararBasesDatos]", new object[,]{});
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerLista(string PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerLista]", new object[,] { {
                        "@PrimerItem",
                        PrimerItem
                    } });
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
                    Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerTodo]", new object[,]{});
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerTodoBuscarxNombre(string Nombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerTodoBuscarxNombre]", new object[,] { {
                        "@Nombre",
                        Nombre
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(int parId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerUno]", new object[,] { {
                        "@parId",
                        parId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerUsoTablas()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerUsoTablas]", new object[,]{});
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerValidarRepetido(int parId, string parNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerValidarRepetido]", new object[,] {
                        {
                            "@parId",
                            parId
                        },
                        {
                            "@parNombre",
                            parNombre
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public void Actualizar(int parId, string parNombre, string parValor, bool parActivo, int usuIdCreacion, int usuIdUltimaModificacion, System.DateTime parFechaHoraCreacion, System.DateTime parFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Parametro.Actualizar]", new object[,] {
                        {
                            "@parId",
                            parId
                        },
                        {
                            "@parNombre",
                            parNombre
                        },
                        {
                            "@parValor",
                            parValor
                        },
                        {
                            "@parActivo",
                            parActivo
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
                            "@parFechaHoraCreacion",
                            parFechaHoraCreacion
                        },
                        {
                            "@parFechaHoraUltimaModificacion",
                            parFechaHoraUltimaModificacion
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void ActualizarPorparNombre(string parNombre, string parValor, int usuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Parametro.ActualizarPorparNombre]", new object[,] {
                        {
                            "@parNombre",
                            parNombre
                        },
                        {
                            "@parValor",
                            parValor
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

            public void Copiar(string parNombre, string parValor, bool parActivo, int usuIdCreacion, int usuIdUltimaModificacion, System.DateTime parFechaHoraCreacion, System.DateTime parFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Parametro.Copiar]", new object[,] {
                        {
                            "@parNombre",
                            parNombre
                        },
                        {
                            "@parValor",
                            parValor
                        },
                        {
                            "@parActivo",
                            parActivo
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
                            "@parFechaHoraCreacion",
                            parFechaHoraCreacion
                        },
                        {
                            "@parFechaHoraUltimaModificacion",
                            parFechaHoraUltimaModificacion
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Eliminar(int parId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Parametro.Eliminar]", new object[,] { {
                        "@parId",
                        parId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void EliminarBloqueos(string BaseDatos)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Parametro.EliminarBloqueos]", new object[,] { {
                        "@BaseDatos",
                        BaseDatos
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Insertar(string parNombre, string parValor, bool parActivo, int usuIdCreacion, int usuIdUltimaModificacion, System.DateTime parFechaHoraCreacion, System.DateTime parFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Parametro.Insertar]", new object[,] {
                        {
                            "@parNombre",
                            parNombre
                        },
                        {
                            "@parValor",
                            parValor
                        },
                        {
                            "@parActivo",
                            parActivo
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
                            "@parFechaHoraCreacion",
                            parFechaHoraCreacion
                        },
                        {
                            "@parFechaHoraUltimaModificacion",
                            parFechaHoraUltimaModificacion
                        }
                    });
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
                    if (this.parId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Parametro.Actualizar]", new object[,] {
                            {
                                "@parId",
                                parId
                            },
                            {
                                "@parNombre",
                                parNombre
                            },
                            {
                                "@parValor",
                                parValor
                            },
                            {
                                "@parActivo",
                                parActivo
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
                                "@parFechaHoraCreacion",
                                parFechaHoraCreacion
                            },
                            {
                                "@parFechaHoraUltimaModificacion",
                                parFechaHoraUltimaModificacion
                            }
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Copiar()
            {
                try
                {
                    if (this.parId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Parametro.Copiar]", new object[,] {
                            {
                                "@parNombre",
                                parNombre
                            },
                            {
                                "@parValor",
                                parValor
                            },
                            {
                                "@parActivo",
                                parActivo
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
                                "@parFechaHoraCreacion",
                                parFechaHoraCreacion
                            },
                            {
                                "@parFechaHoraUltimaModificacion",
                                parFechaHoraUltimaModificacion
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
                    if (this.parId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Parametro.Eliminar]", new object[,] { {
                            "@parId",
                            parId
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Parametro.Insertar]", new object[,] {
                        {
                            "@parNombre",
                            parNombre
                        },
                        {
                            "@parValor",
                            parValor
                        },
                        {
                            "@parActivo",
                            parActivo
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
                            "@parFechaHoraCreacion",
                            parFechaHoraCreacion
                        },
                        {
                            "@parFechaHoraUltimaModificacion",
                            parFechaHoraUltimaModificacion
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







