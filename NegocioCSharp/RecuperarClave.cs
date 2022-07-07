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
        public partial class RecuperarClave
        {
            private Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila;

            private DataTable Tabla = new DataTable();
            private int _rclId;
            public int rclId
            {
                get { return _rclId; }
                set { _rclId = value; }
            }

            private System.DateTime _rclFecha;
            public System.DateTime rclFecha
            {
                get { return _rclFecha; }
                set { _rclFecha = value; }
            }

            private string _rclUsuario;
            public string rclUsuario
            {
                get { return _rclUsuario; }
                set { _rclUsuario = value; }
            }

            private string _rclEmailRecuperacion;
            public string rclEmailRecuperacion
            {
                get { return _rclEmailRecuperacion; }
                set { _rclEmailRecuperacion = value; }
            }

            private string _rclUsuarioEncriptado;
            public string rclUsuarioEncriptado
            {
                get { return _rclUsuarioEncriptado; }
                set { _rclUsuarioEncriptado = value; }
            }

            private string _rclEmailRecuperacionEncriptado;
            public string rclEmailRecuperacionEncriptado
            {
                get { return _rclEmailRecuperacionEncriptado; }
                set { _rclEmailRecuperacionEncriptado = value; }
            }

            private bool _rclActivo;
            public bool rclActivo
            {
                get { return _rclActivo; }
                set { _rclActivo = value; }
            }

            private System.DateTime _rclFechaHoraCreacion;
            public System.DateTime rclFechaHoraCreacion
            {
                get { return _rclFechaHoraCreacion; }
                set { _rclFechaHoraCreacion = value; }
            }

            private System.DateTime _rclFechaHoraUltimaModificacion;
            public System.DateTime rclFechaHoraUltimaModificacion
            {
                get { return _rclFechaHoraUltimaModificacion; }
                set { _rclFechaHoraUltimaModificacion = value; }
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

            public RecuperarClave()
            {
                try
                {
                    this.rclId = 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public RecuperarClave(int rclId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[RecuperarClave.ObtenerUno]", new object[,] { {
                        "@rclId",
                        rclId
                    } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["rclId"].ToString().Trim().Length > 0)
                        {
                            this.rclId = Convert.ToInt32(Fila.Rows[0]["rclId"]);
                        }
                        else
                        {
                            this.rclId = 0;
                        }

                        if (Fila.Rows[0]["rclFecha"].ToString().Trim().Length > 0)
                        {
                            this.rclFecha = Convert.ToDateTime(Fila.Rows[0]["rclFecha"]);
                        }
                        else
                        {
                            this.rclFecha = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["rclUsuario"].ToString().Trim().Length > 0)
                        {
                            this.rclUsuario = Convert.ToString(Fila.Rows[0]["rclUsuario"]);
                        }
                        else
                        {
                            this.rclUsuario = "";
                        }

                        if (Fila.Rows[0]["rclEmailRecuperacion"].ToString().Trim().Length > 0)
                        {
                            this.rclEmailRecuperacion = Convert.ToString(Fila.Rows[0]["rclEmailRecuperacion"]);
                        }
                        else
                        {
                            this.rclEmailRecuperacion = "";
                        }

                        if (Fila.Rows[0]["rclUsuarioEncriptado"].ToString().Trim().Length > 0)
                        {
                            this.rclUsuarioEncriptado = Convert.ToString(Fila.Rows[0]["rclUsuarioEncriptado"]);
                        }
                        else
                        {
                            this.rclUsuarioEncriptado = "";
                        }

                        if (Fila.Rows[0]["rclEmailRecuperacionEncriptado"].ToString().Trim().Length > 0)
                        {
                            this.rclEmailRecuperacionEncriptado = Convert.ToString(Fila.Rows[0]["rclEmailRecuperacionEncriptado"]);
                        }
                        else
                        {
                            this.rclEmailRecuperacionEncriptado = "";
                        }

                        if (Fila.Rows[0]["rclFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.rclFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["rclFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.rclFechaHoraCreacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["rclFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.rclFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["rclFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.rclFechaHoraUltimaModificacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["rclActivo"].ToString().Trim().Length > 0)
                        {
                            this.rclActivo = (Convert.ToInt32(Fila.Rows[0]["rclActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.rclActivo = false;
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

            public RecuperarClave(int rclId, System.DateTime rclFecha, string rclUsuario, string rclEmailRecuperacion, string rclUsuarioEncriptado, string rclEmailRecuperacionEncriptado, bool rclActivo, System.DateTime rclFechaHoraCreacion, System.DateTime rclFechaHoraUltimaModificacion, int IusuIdCreacion,
            int IusuIdUltimaModificacion)
            {
                try
                {
                    this.rclId = rclId;
                    this.rclFecha = rclFecha;
                    this.rclUsuario = rclUsuario;
                    this.rclEmailRecuperacion = rclEmailRecuperacion;
                    this.rclUsuarioEncriptado = rclUsuarioEncriptado;
                    this.rclEmailRecuperacionEncriptado = rclEmailRecuperacionEncriptado;
                    this.rclActivo = rclActivo;
                    this.rclFechaHoraCreacion = rclFechaHoraCreacion;
                    this.rclFechaHoraUltimaModificacion = rclFechaHoraUltimaModificacion;
                    this.usuIdCreacion = usuIdCreacion;
                    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            public DataTable ObtenerConValoresEncriptados(string UsuarioEncriptado, string EmailEncriptado)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RecuperarClave.ObtenerConValoresEncriptados]", new object[,] {
                        {
                            "@UsuarioEncriptado",
                            UsuarioEncriptado
                        },
                        {
                            "@EmailEncriptado",
                            EmailEncriptado
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
                    Tabla = ocdGestor.EjecutarReader("[RecuperarClave.ObtenerTodo]", new object[,]{});
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(int rclId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[RecuperarClave.ObtenerUno]", new object[,] { {
                        "@rclId",
                        rclId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public void Actualizar(int rclId, System.DateTime rclFecha, string rclUsuario, string rclEmailRecuperacion, string rclUsuarioEncriptado, string rclEmailRecuperacionEncriptado, bool rclActivo, int usuIdCreacion, int usuIdUltimaModificacion, System.DateTime rclFechaHoraCreacion,
            System.DateTime rclFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RecuperarClave.Actualizar]", new object[,] {
                        {
                            "@rclId",
                            rclId
                        },
                        {
                            "@rclFecha",
                            rclFecha
                        },
                        {
                            "@rclUsuario",
                            rclUsuario
                        },
                        {
                            "@rclEmailRecuperacion",
                            rclEmailRecuperacion
                        },
                        {
                            "@rclUsuarioEncriptado",
                            rclUsuarioEncriptado
                        },
                        {
                            "@rclEmailRecuperacionEncriptado",
                            rclEmailRecuperacionEncriptado
                        },
                        {
                            "@rclActivo",
                            rclActivo
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
                            "@rclFechaHoraCreacion",
                            rclFechaHoraCreacion
                        },
                        {
                            "@rclFechaHoraUltimaModificacion",
                            rclFechaHoraUltimaModificacion
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Eliminar(int rclId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RecuperarClave.Eliminar]", new object[,] { {
                        "@rclId",
                        rclId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Insertar(System.DateTime rclFecha, string rclUsuario, string rclEmailRecuperacion, string rclUsuarioEncriptado, string rclEmailRecuperacionEncriptado, bool rclActivo, int usuIdCreacion, int usuIdUltimaModificacion, System.DateTime rclFechaHoraCreacion, System.DateTime rclFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RecuperarClave.Insertar]", new object[,] {
                        {
                            "@rclFecha",
                            rclFecha
                        },
                        {
                            "@rclUsuario",
                            rclUsuario
                        },
                        {
                            "@rclEmailRecuperacion",
                            rclEmailRecuperacion
                        },
                        {
                            "@rclUsuarioEncriptado",
                            rclUsuarioEncriptado
                        },
                        {
                            "@rclEmailRecuperacionEncriptado",
                            rclEmailRecuperacionEncriptado
                        },
                        {
                            "@rclActivo",
                            rclActivo
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
                            "@rclFechaHoraCreacion",
                            rclFechaHoraCreacion
                        },
                        {
                            "@rclFechaHoraUltimaModificacion",
                            rclFechaHoraUltimaModificacion
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void InsertarCustom(string Usuario, string Email, string UsuarioEncriptado, string EmailEncriptado)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[RecuperarClave.InsertarCustom]", new object[,] {
                        {
                            "@Usuario",
                            Usuario
                        },
                        {
                            "@Email",
                            Email
                        },
                        {
                            "@UsuarioEncriptado",
                            UsuarioEncriptado
                        },
                        {
                            "@EmailEncriptado",
                            EmailEncriptado
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
                    if (this.rclId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[RecuperarClave.Actualizar]", new object[,] {
                            {
                                "@rclId",
                                rclId
                            },
                            {
                                "@rclFecha",
                                rclFecha
                            },
                            {
                                "@rclUsuario",
                                rclUsuario
                            },
                            {
                                "@rclEmailRecuperacion",
                                rclEmailRecuperacion
                            },
                            {
                                "@rclUsuarioEncriptado",
                                rclUsuarioEncriptado
                            },
                            {
                                "@rclEmailRecuperacionEncriptado",
                                rclEmailRecuperacionEncriptado
                            },
                            {
                                "@rclActivo",
                                rclActivo
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
                                "@rclFechaHoraCreacion",
                                rclFechaHoraCreacion
                            },
                            {
                                "@rclFechaHoraUltimaModificacion",
                                rclFechaHoraUltimaModificacion
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
                    if (this.rclId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[RecuperarClave.Eliminar]", new object[,] { {
                            "@rclId",
                            rclId
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[RecuperarClave.Insertar]", new object[,] {
                        {
                            "@rclFecha",
                            rclFecha
                        },
                        {
                            "@rclUsuario",
                            rclUsuario
                        },
                        {
                            "@rclEmailRecuperacion",
                            rclEmailRecuperacion
                        },
                        {
                            "@rclUsuarioEncriptado",
                            rclUsuarioEncriptado
                        },
                        {
                            "@rclEmailRecuperacionEncriptado",
                            rclEmailRecuperacionEncriptado
                        },
                        {
                            "@rclActivo",
                            rclActivo
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
                            "@rclFechaHoraCreacion",
                            rclFechaHoraCreacion
                        },
                        {
                            "@rclFechaHoraUltimaModificacion",
                            rclFechaHoraUltimaModificacion
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







