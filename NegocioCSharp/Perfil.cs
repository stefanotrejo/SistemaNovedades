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
        public partial class Perfil
        {
            private Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila;

            private DataTable Tabla = new DataTable();
            private int _perId;
            public int perId
            {
                get { return _perId; }
                set { _perId = value; }
            }

            private string _perNombre;
            public string perNombre
            {
                get { return _perNombre; }
                set { _perNombre = value; }
            }

            private string _perDescripcion;
            public string perDescripcion
            {
                get { return _perDescripcion; }
                set { _perDescripcion = value; }
            }

            private bool _perEsAdministrador;
            public bool perEsAdministrador
            {
                get { return _perEsAdministrador; }
                set { _perEsAdministrador = value; }
            }

            private System.DateTime _perFechaHoraCreacion;
            public System.DateTime perFechaHoraCreacion
            {
                get { return _perFechaHoraCreacion; }
                set { _perFechaHoraCreacion = value; }
            }

            private System.DateTime _perFechaHoraUltimaModificacion;
            public System.DateTime perFechaHoraUltimaModificacion
            {
                get { return _perFechaHoraUltimaModificacion; }
                set { _perFechaHoraUltimaModificacion = value; }
            }

            private bool _perActivo;
            public bool perActivo
            {
                get { return _perActivo; }
                set { _perActivo = value; }
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

            public Perfil()
            {
                try
                {
                    this.perId = 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public Perfil(int perId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Perfil.ObtenerUno]", new object[,] { {
                        "@perId",
                        perId
                    } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["perId"].ToString().Trim().Length > 0)
                        {
                            this.perId = Convert.ToInt32(Fila.Rows[0]["perId"]);
                        }
                        else
                        {
                            this.perId = 0;
                        }

                        if (Fila.Rows[0]["perNombre"].ToString().Trim().Length > 0)
                        {
                            this.perNombre = Convert.ToString(Fila.Rows[0]["perNombre"]);
                        }
                        else
                        {
                            this.perNombre = "";
                        }

                        if (Fila.Rows[0]["perDescripcion"].ToString().Trim().Length > 0)
                        {
                            this.perDescripcion = Convert.ToString(Fila.Rows[0]["perDescripcion"]);
                        }
                        else
                        {
                            this.perDescripcion = "";
                        }

                        if (Fila.Rows[0]["perFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.perFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["perFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.perFechaHoraCreacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["perFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.perFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["perFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.perFechaHoraUltimaModificacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["perEsAdministrador"].ToString().Trim().Length > 0)
                        {
                            this.perEsAdministrador = (Convert.ToInt32(Fila.Rows[0]["perEsAdministrador"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.perEsAdministrador = false;
                        }

                        if (Fila.Rows[0]["perActivo"].ToString().Trim().Length > 0)
                        {
                            this.perActivo = (Convert.ToInt32(Fila.Rows[0]["perActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.perActivo = false;
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

            public Perfil(int perId, string perNombre, string perDescripcion, bool perEsAdministrador, System.DateTime perFechaHoraCreacion, System.DateTime perFechaHoraUltimaModificacion, bool perActivo, int IusuIdCreacion, int IusuIdUltimaModificacion)
            {
                try
                {
                    this.perId = perId;
                    this.perNombre = perNombre;
                    this.perDescripcion = perDescripcion;
                    this.perEsAdministrador = perEsAdministrador;
                    this.perFechaHoraCreacion = perFechaHoraCreacion;
                    this.perFechaHoraUltimaModificacion = perFechaHoraUltimaModificacion;
                    this.perActivo = perActivo;
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
                    Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerBuscador]", new object[,] { {
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

            public DataTable ObtenerLista(string PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerLista]", new object[,] { {
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

            public DataTable ObtenerNovedad(int novId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerNovedad]", new object[,] { {
                        "@novId",
                        novId
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
                    Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerTodo]", new object[,] { });
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
                    Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerTodoBuscarxNombre]", new object[,] { {
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

            public DataTable ObtenerUno(int perId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerUno]", new object[,] { {
                        "@perId",
                        perId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerValidarRepetido(int perId, string perNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerValidarRepetido]", new object[,] {
                        {
                            "@perId",
                            perId
                        },
                        {
                            "@perNombre",
                            perNombre
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public void Actualizar(int perId, string perNombre, string perDescripcion, bool perEsAdministrador, int usuIdCreacion, int usuIdUltimaModificacion, System.DateTime perFechaHoraCreacion, System.DateTime perFechaHoraUltimaModificacion, bool perActivo)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Perfil.Actualizar]", new object[,] {
                        {
                            "@perId",
                            perId
                        },
                        {
                            "@perNombre",
                            perNombre
                        },
                        {
                            "@perDescripcion",
                            perDescripcion
                        },
                        {
                            "@perEsAdministrador",
                            perEsAdministrador
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
                            "@perFechaHoraCreacion",
                            perFechaHoraCreacion
                        },
                        {
                            "@perFechaHoraUltimaModificacion",
                            perFechaHoraUltimaModificacion
                        },
                        {
                            "@perActivo",
                            perActivo
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Copiar(string perNombre, string perDescripcion, bool perEsAdministrador, int usuIdCreacion, int usuIdUltimaModificacion, System.DateTime perFechaHoraCreacion, System.DateTime perFechaHoraUltimaModificacion, bool perActivo)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Perfil.Copiar]", new object[,] {
                        {
                            "@perNombre",
                            perNombre
                        },
                        {
                            "@perDescripcion",
                            perDescripcion
                        },
                        {
                            "@perEsAdministrador",
                            perEsAdministrador
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
                            "@perFechaHoraCreacion",
                            perFechaHoraCreacion
                        },
                        {
                            "@perFechaHoraUltimaModificacion",
                            perFechaHoraUltimaModificacion
                        },
                        {
                            "@perActivo",
                            perActivo
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Eliminar(int perId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Perfil.Eliminar]", new object[,] { {
                        "@perId",
                        perId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Insertar(string perNombre, string perDescripcion, bool perEsAdministrador, int usuIdCreacion, int usuIdUltimaModificacion, System.DateTime perFechaHoraCreacion, System.DateTime perFechaHoraUltimaModificacion, bool perActivo)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Perfil.Insertar]", new object[,] {
                        {
                            "@perNombre",
                            perNombre
                        },
                        {
                            "@perDescripcion",
                            perDescripcion
                        },
                        {
                            "@perEsAdministrador",
                            perEsAdministrador
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
                            "@perFechaHoraCreacion",
                            perFechaHoraCreacion
                        },
                        {
                            "@perFechaHoraUltimaModificacion",
                            perFechaHoraUltimaModificacion
                        },
                        {
                            "@perActivo",
                            perActivo
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
                    if (this.perId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Perfil.Actualizar]", new object[,] {
                            {
                                "@perId",
                                perId
                            },
                            {
                                "@perNombre",
                                perNombre
                            },
                            {
                                "@perDescripcion",
                                perDescripcion
                            },
                            {
                                "@perEsAdministrador",
                                perEsAdministrador
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
                                "@perFechaHoraCreacion",
                                perFechaHoraCreacion
                            },
                            {
                                "@perFechaHoraUltimaModificacion",
                                perFechaHoraUltimaModificacion
                            },
                            {
                                "@perActivo",
                                perActivo
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
                    if (this.perId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Perfil.Copiar]", new object[,] {
                            {
                                "@perNombre",
                                perNombre
                            },
                            {
                                "@perDescripcion",
                                perDescripcion
                            },
                            {
                                "@perEsAdministrador",
                                perEsAdministrador
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
                                "@perFechaHoraCreacion",
                                perFechaHoraCreacion
                            },
                            {
                                "@perFechaHoraUltimaModificacion",
                                perFechaHoraUltimaModificacion
                            },
                            {
                                "@perActivo",
                                perActivo
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
                    if (this.perId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Perfil.Eliminar]", new object[,] { {
                            "@perId",
                            perId
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Perfil.Insertar]", new object[,] {
                        {
                            "@perNombre",
                            perNombre
                        },
                        {
                            "@perDescripcion",
                            perDescripcion
                        },
                        {
                            "@perEsAdministrador",
                            perEsAdministrador
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
                            "@perFechaHoraCreacion",
                            perFechaHoraCreacion
                        },
                        {
                            "@perFechaHoraUltimaModificacion",
                            perFechaHoraUltimaModificacion
                        },
                        {
                            "@perActivo",
                            perActivo
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







