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
        public partial class UsuarioConectado
        {
            private Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila;

            private DataTable Tabla = new DataTable();
            private int _ucoId;
            public int ucoId
            {
                get { return _ucoId; }
                set { _ucoId = value; }
            }

            private System.DateTime _ucoFechaHoraUltimaConexion;
            public System.DateTime ucoFechaHoraUltimaConexion
            {
                get { return _ucoFechaHoraUltimaConexion; }
                set { _ucoFechaHoraUltimaConexion = value; }
            }

            private string _ucoGuid;
            public string ucoGuid
            {
                get { return _ucoGuid; }
                set { _ucoGuid = value; }
            }

            private string _ucoIpPublica;
            public string ucoIpPublica
            {
                get { return _ucoIpPublica; }
                set { _ucoIpPublica = value; }
            }

            private bool _ucoDesconectar;
            public bool ucoDesconectar
            {
                get { return _ucoDesconectar; }
                set { _ucoDesconectar = value; }
            }

            private bool _ucoActivo;
            public bool ucoActivo
            {
                get { return _ucoActivo; }
                set { _ucoActivo = value; }
            }

            private System.DateTime _ucoFechaHoraCreacion;
            public System.DateTime ucoFechaHoraCreacion
            {
                get { return _ucoFechaHoraCreacion; }
                set { _ucoFechaHoraCreacion = value; }
            }

            private System.DateTime _ucoFechaHoraUltimaModificacion;
            public System.DateTime ucoFechaHoraUltimaModificacion
            {
                get { return _ucoFechaHoraUltimaModificacion; }
                set { _ucoFechaHoraUltimaModificacion = value; }
            }

            private int _usuId;
            public int usuId
            {
                get { return _usuId; }
                set { _usuId = value; }
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

            public UsuarioConectado()
            {
                try
                {
                    this.ucoId = 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public UsuarioConectado(int ucoId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[UsuarioConectado.ObtenerUno]", new object[,] { {
                        "@ucoId",
                        ucoId
                    } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["ucoId"].ToString().Trim().Length > 0)
                        {
                            this.ucoId = Convert.ToInt32(Fila.Rows[0]["ucoId"]);
                        }
                        else
                        {
                            this.ucoId = 0;
                        }

                        if (Fila.Rows[0]["ucoFechaHoraUltimaConexion"].ToString().Trim().Length > 0)
                        {
                            this.ucoFechaHoraUltimaConexion = Convert.ToDateTime(Fila.Rows[0]["ucoFechaHoraUltimaConexion"]);
                        }
                        else
                        {
                            this.ucoFechaHoraUltimaConexion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["ucoGuid"].ToString().Trim().Length > 0)
                        {
                            this.ucoGuid = Convert.ToString(Fila.Rows[0]["ucoGuid"]);
                        }
                        else
                        {
                            this.ucoGuid = "";
                        }

                        if (Fila.Rows[0]["ucoIpPublica"].ToString().Trim().Length > 0)
                        {
                            this.ucoIpPublica = Convert.ToString(Fila.Rows[0]["ucoIpPublica"]);
                        }
                        else
                        {
                            this.ucoIpPublica = "";
                        }

                        if (Fila.Rows[0]["ucoFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.ucoFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["ucoFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.ucoFechaHoraCreacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["ucoFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.ucoFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["ucoFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.ucoFechaHoraUltimaModificacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["ucoDesconectar"].ToString().Trim().Length > 0)
                        {
                            this.ucoDesconectar = (Convert.ToInt32(Fila.Rows[0]["ucoDesconectar"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.ucoDesconectar = false;
                        }

                        if (Fila.Rows[0]["ucoActivo"].ToString().Trim().Length > 0)
                        {
                            this.ucoActivo = (Convert.ToInt32(Fila.Rows[0]["ucoActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.ucoActivo = false;
                        }

                        if (Fila.Rows[0]["usuId"].ToString().Trim().Length > 0)
                        {
                            this.usuId = Convert.ToInt32(Fila.Rows[0]["usuId"]);
                        }
                        else
                        {
                            this.usuId = 0;
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

            public UsuarioConectado(int ucoId, System.DateTime ucoFechaHoraUltimaConexion, string ucoGuid, string ucoIpPublica, bool ucoDesconectar, bool ucoActivo, System.DateTime ucoFechaHoraCreacion, System.DateTime ucoFechaHoraUltimaModificacion, int IusuId, int IusuIdCreacion,
            int IusuIdUltimaModificacion)
            {
                try
                {
                    this.ucoId = ucoId;
                    this.ucoFechaHoraUltimaConexion = ucoFechaHoraUltimaConexion;
                    this.ucoGuid = ucoGuid;
                    this.ucoIpPublica = ucoIpPublica;
                    this.ucoDesconectar = ucoDesconectar;
                    this.ucoActivo = ucoActivo;
                    this.ucoFechaHoraCreacion = ucoFechaHoraCreacion;
                    this.ucoFechaHoraUltimaModificacion = ucoFechaHoraUltimaModificacion;
                    this.usuId = usuId;
                    this.usuIdCreacion = usuIdCreacion;
                    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            public DataTable ObtenerConectar(int usuId, string ucoGuid, string ucoIpPublica)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioConectado.ObtenerConectar]", new object[,] {
                        {
                            "@usuId",
                            usuId
                        },
                        {
                            "@ucoGuid",
                            ucoGuid
                        },
                        {
                            "@ucoIpPublica",
                            ucoIpPublica
                        }
                    });
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
                    Tabla = ocdGestor.EjecutarReader("[UsuarioConectado.ObtenerTodo]", new object[,] { });
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
                    Tabla = ocdGestor.EjecutarReader("[UsuarioConectado.ObtenerTodoCustom]", new object[,]{});
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(int ucoId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[UsuarioConectado.ObtenerUno]", new object[,] { {
                        "@ucoId",
                        ucoId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public void Actualizar(int ucoId, int usuId, System.DateTime ucoFechaHoraUltimaConexion, string ucoGuid, string ucoIpPublica, bool ucoDesconectar, bool ucoActivo, int usuIdCreacion, int usuIdUltimaModificacion, System.DateTime ucoFechaHoraCreacion,
            System.DateTime ucoFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[UsuarioConectado.Actualizar]", new object[,] {
                        {
                            "@ucoId",
                            ucoId
                        },
                        {
                            "@usuId",
                            usuId
                        },
                        {
                            "@ucoFechaHoraUltimaConexion",
                            ucoFechaHoraUltimaConexion
                        },
                        {
                            "@ucoGuid",
                            ucoGuid
                        },
                        {
                            "@ucoIpPublica",
                            ucoIpPublica
                        },
                        {
                            "@ucoDesconectar",
                            ucoDesconectar
                        },
                        {
                            "@ucoActivo",
                            ucoActivo
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
                            "@ucoFechaHoraCreacion",
                            ucoFechaHoraCreacion
                        },
                        {
                            "@ucoFechaHoraUltimaModificacion",
                            ucoFechaHoraUltimaModificacion
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void DesconectarOtros(int usuId, string ucoGuid, string ucoIpPublica)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[UsuarioConectado.DesconectarOtros]", new object[,] {
                        {
                            "@usuId",
                            usuId
                        },
                        {
                            "@ucoGuid",
                            ucoGuid
                        },
                        {
                            "@ucoIpPublica",
                            ucoIpPublica
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Eliminar(int ucoId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[UsuarioConectado.Eliminar]", new object[,] { {
                        "@ucoId",
                        ucoId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Insertar(int usuId, System.DateTime ucoFechaHoraUltimaConexion, string ucoGuid, string ucoIpPublica, bool ucoDesconectar, bool ucoActivo, int usuIdCreacion, int usuIdUltimaModificacion, System.DateTime ucoFechaHoraCreacion, System.DateTime ucoFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[UsuarioConectado.Insertar]", new object[,] {
                        {
                            "@usuId",
                            usuId
                        },
                        {
                            "@ucoFechaHoraUltimaConexion",
                            ucoFechaHoraUltimaConexion
                        },
                        {
                            "@ucoGuid",
                            ucoGuid
                        },
                        {
                            "@ucoIpPublica",
                            ucoIpPublica
                        },
                        {
                            "@ucoDesconectar",
                            ucoDesconectar
                        },
                        {
                            "@ucoActivo",
                            ucoActivo
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
                            "@ucoFechaHoraCreacion",
                            ucoFechaHoraCreacion
                        },
                        {
                            "@ucoFechaHoraUltimaModificacion",
                            ucoFechaHoraUltimaModificacion
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
                    if (this.ucoId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[UsuarioConectado.Actualizar]", new object[,] {
                            {
                                "@ucoId",
                                ucoId
                            },
                            {
                                "@usuId",
                                usuId
                            },
                            {
                                "@ucoFechaHoraUltimaConexion",
                                ucoFechaHoraUltimaConexion
                            },
                            {
                                "@ucoGuid",
                                ucoGuid
                            },
                            {
                                "@ucoIpPublica",
                                ucoIpPublica
                            },
                            {
                                "@ucoDesconectar",
                                ucoDesconectar
                            },
                            {
                                "@ucoActivo",
                                ucoActivo
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
                                "@ucoFechaHoraCreacion",
                                ucoFechaHoraCreacion
                            },
                            {
                                "@ucoFechaHoraUltimaModificacion",
                                ucoFechaHoraUltimaModificacion
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
                    if (this.ucoId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[UsuarioConectado.Eliminar]", new object[,] { {
                            "@ucoId",
                            ucoId
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[UsuarioConectado.Insertar]", new object[,] {
                        {
                            "@usuId",
                            usuId
                        },
                        {
                            "@ucoFechaHoraUltimaConexion",
                            ucoFechaHoraUltimaConexion
                        },
                        {
                            "@ucoGuid",
                            ucoGuid
                        },
                        {
                            "@ucoIpPublica",
                            ucoIpPublica
                        },
                        {
                            "@ucoDesconectar",
                            ucoDesconectar
                        },
                        {
                            "@ucoActivo",
                            ucoActivo
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
                            "@ucoFechaHoraCreacion",
                            ucoFechaHoraCreacion
                        },
                        {
                            "@ucoFechaHoraUltimaModificacion",
                            ucoFechaHoraUltimaModificacion
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







