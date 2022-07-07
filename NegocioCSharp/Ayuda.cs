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
        public partial class Ayuda
        {
            private Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila;

            private DataTable Tabla = new DataTable();
            private int _ayuId;
            public int ayuId
            {
                get { return _ayuId; }
                set { _ayuId = value; }
            }

            private string _ayuPaginaNombre;
            public string ayuPaginaNombre
            {
                get { return _ayuPaginaNombre; }
                set { _ayuPaginaNombre = value; }
            }

            private string _ayuDescripcion;
            public string ayuDescripcion
            {
                get { return _ayuDescripcion; }
                set { _ayuDescripcion = value; }
            }

            private bool _ayuActivo;
            public bool ayuActivo
            {
                get { return _ayuActivo; }
                set { _ayuActivo = value; }
            }

            private System.DateTime _ayuFechaHoraCreacion;
            public System.DateTime ayuFechaHoraCreacion
            {
                get { return _ayuFechaHoraCreacion; }
                set { _ayuFechaHoraCreacion = value; }
            }

            private System.DateTime _ayuFechaHoraUltimaModificacion;
            public System.DateTime ayuFechaHoraUltimaModificacion
            {
                get { return _ayuFechaHoraUltimaModificacion; }
                set { _ayuFechaHoraUltimaModificacion = value; }
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

            public Ayuda()
            {
                try
                {
                    this.ayuId = 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public Ayuda(int ayuId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Ayuda.ObtenerUno]", new object[,] { {
                        "@ayuId",
                        ayuId
                    } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["ayuId"].ToString().Trim().Length > 0)
                        {
                            this.ayuId = Convert.ToInt32(Fila.Rows[0]["ayuId"]);
                        }
                        else
                        {
                            this.ayuId = 0;
                        }

                        if (Fila.Rows[0]["ayuPaginaNombre"].ToString().Trim().Length > 0)
                        {
                            this.ayuPaginaNombre = Convert.ToString(Fila.Rows[0]["ayuPaginaNombre"]);
                        }
                        else
                        {
                            this.ayuPaginaNombre = "";
                        }

                        if (Fila.Rows[0]["ayuDescripcion"].ToString().Trim().Length > 0)
                        {
                            this.ayuDescripcion = Convert.ToString(Fila.Rows[0]["ayuDescripcion"]);
                        }
                        else
                        {
                            this.ayuDescripcion = "";
                        }

                        if (Fila.Rows[0]["ayuFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.ayuFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["ayuFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.ayuFechaHoraCreacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["ayuFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.ayuFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["ayuFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.ayuFechaHoraUltimaModificacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["ayuActivo"].ToString().Trim().Length > 0)
                        {
                            this.ayuActivo = (Convert.ToInt32(Fila.Rows[0]["ayuActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.ayuActivo = false;
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

            public Ayuda(int ayuId, string ayuPaginaNombre, string ayuDescripcion, bool ayuActivo, System.DateTime ayuFechaHoraCreacion, System.DateTime ayuFechaHoraUltimaModificacion, int IusuIdCreacion, int IusuIdUltimaModificacion)
            {
                try
                {
                    this.ayuId = ayuId;
                    this.ayuPaginaNombre = ayuPaginaNombre;
                    this.ayuDescripcion = ayuDescripcion;
                    this.ayuActivo = ayuActivo;
                    this.ayuFechaHoraCreacion = ayuFechaHoraCreacion;
                    this.ayuFechaHoraUltimaModificacion = ayuFechaHoraUltimaModificacion;
                    this.usuIdCreacion = usuIdCreacion;
                    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
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
                    Tabla = ocdGestor.EjecutarReader("[Ayuda.ObtenerTodo]", new object[,]{});
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(int ayuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Ayuda.ObtenerUno]", new object[,] { {
                        "@ayuId",
                        ayuId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerxNombrePagina(string ayuPaginaNombre, int usuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Ayuda.ObtenerxNombrePagina]", new object[,] {
                        {
                            "@ayuPaginaNombre",
                            ayuPaginaNombre
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

                return Tabla;
            }

            public void Actualizar(int ayuId, string ayuPaginaNombre, string ayuDescripcion, bool ayuActivo, int usuIdCreacion, int usuIdUltimaModificacion, System.DateTime ayuFechaHoraCreacion, System.DateTime ayuFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Ayuda.Actualizar]", new object[,] {
                        {
                            "@ayuId",
                            ayuId
                        },
                        {
                            "@ayuPaginaNombre",
                            ayuPaginaNombre
                        },
                        {
                            "@ayuDescripcion",
                            ayuDescripcion
                        },
                        {
                            "@ayuActivo",
                            ayuActivo
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
                            "@ayuFechaHoraCreacion",
                            ayuFechaHoraCreacion
                        },
                        {
                            "@ayuFechaHoraUltimaModificacion",
                            ayuFechaHoraUltimaModificacion
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Eliminar(int ayuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Ayuda.Eliminar]", new object[,] { {
                        "@ayuId",
                        ayuId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Insertar(string ayuPaginaNombre, string ayuDescripcion, bool ayuActivo, int usuIdCreacion, int usuIdUltimaModificacion, System.DateTime ayuFechaHoraCreacion, System.DateTime ayuFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Ayuda.Insertar]", new object[,] {
                        {
                            "@ayuPaginaNombre",
                            ayuPaginaNombre
                        },
                        {
                            "@ayuDescripcion",
                            ayuDescripcion
                        },
                        {
                            "@ayuActivo",
                            ayuActivo
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
                            "@ayuFechaHoraCreacion",
                            ayuFechaHoraCreacion
                        },
                        {
                            "@ayuFechaHoraUltimaModificacion",
                            ayuFechaHoraUltimaModificacion
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
                    if (this.ayuId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Ayuda.Actualizar]", new object[,] {
                            {
                                "@ayuId",
                                ayuId
                            },
                            {
                                "@ayuPaginaNombre",
                                ayuPaginaNombre
                            },
                            {
                                "@ayuDescripcion",
                                ayuDescripcion
                            },
                            {
                                "@ayuActivo",
                                ayuActivo
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
                                "@ayuFechaHoraCreacion",
                                ayuFechaHoraCreacion
                            },
                            {
                                "@ayuFechaHoraUltimaModificacion",
                                ayuFechaHoraUltimaModificacion
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
                    if (this.ayuId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Ayuda.Eliminar]", new object[,] { {
                            "@ayuId",
                            ayuId
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Ayuda.Insertar]", new object[,] {
                        {
                            "@ayuPaginaNombre",
                            ayuPaginaNombre
                        },
                        {
                            "@ayuDescripcion",
                            ayuDescripcion
                        },
                        {
                            "@ayuActivo",
                            ayuActivo
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
                            "@ayuFechaHoraCreacion",
                            ayuFechaHoraCreacion
                        },
                        {
                            "@ayuFechaHoraUltimaModificacion",
                            ayuFechaHoraUltimaModificacion
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







