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
        public partial class Usuario
        {
            private Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila;

            private DataTable Tabla = new DataTable();
            private int _usuId;
            public int usuId
            {
                get { return _usuId; }
                set { _usuId = value; }
            }

            private string _usuApellido;
            public string usuApellido
            {
                get { return _usuApellido; }
                set { _usuApellido = value; }
            }

            private string _usuNombre;
            public string usuNombre
            {
                get { return _usuNombre; }
                set { _usuNombre = value; }
            }

            private string _usuNombreIngreso;
            public string usuNombreIngreso
            {
                get { return _usuNombreIngreso; }
                set { _usuNombreIngreso = value; }
            }

            private string _usuClave;
            public string usuClave
            {
                get { return _usuClave; }
                set { _usuClave = value; }
            }

            private string _usuClaveProvisoria;
            public string usuClaveProvisoria
            {
                get { return _usuClaveProvisoria; }
                set { _usuClaveProvisoria = value; }
            }

            private bool _usuCambiarClave;
            public bool usuCambiarClave
            {
                get { return _usuCambiarClave; }
                set { _usuCambiarClave = value; }
            }

            private string _usuEmail;
            public string usuEmail
            {
                get { return _usuEmail; }
                set { _usuEmail = value; }
            }

            private System.DateTime _usuFechaHoraCreacion;
            public System.DateTime usuFechaHoraCreacion
            {
                get { return _usuFechaHoraCreacion; }
                set { _usuFechaHoraCreacion = value; }
            }

            private System.DateTime _usuFechaHoraUltimaModificacion;
            public System.DateTime usuFechaHoraUltimaModificacion
            {
                get { return _usuFechaHoraUltimaModificacion; }
                set { _usuFechaHoraUltimaModificacion = value; }
            }

            private bool _usuActivo;
            public bool usuActivo
            {
                get { return _usuActivo; }
                set { _usuActivo = value; }
            }

            private int _perId;
            public int perId
            {
                get { return _perId; }
                set { _perId = value; }
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

            public Usuario()
            {
                try
                {
                    this.usuId = 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public Usuario(int usuId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Usuario.ObtenerUno]", new object[,] { {
                        "@usuId",
                        usuId
                    } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["usuId"].ToString().Trim().Length > 0)
                        {
                            this.usuId = Convert.ToInt32(Fila.Rows[0]["usuId"]);
                        }
                        else
                        {
                            this.usuId = 0;
                        }

                        if (Fila.Rows[0]["usuApellido"].ToString().Trim().Length > 0)
                        {
                            this.usuApellido = Convert.ToString(Fila.Rows[0]["usuApellido"]);
                        }
                        else
                        {
                            this.usuApellido = "";
                        }

                        if (Fila.Rows[0]["usuNombre"].ToString().Trim().Length > 0)
                        {
                            this.usuNombre = Convert.ToString(Fila.Rows[0]["usuNombre"]);
                        }
                        else
                        {
                            this.usuNombre = "";
                        }

                        if (Fila.Rows[0]["usuNombreIngreso"].ToString().Trim().Length > 0)
                        {
                            this.usuNombreIngreso = Convert.ToString(Fila.Rows[0]["usuNombreIngreso"]);
                        }
                        else
                        {
                            this.usuNombreIngreso = "";
                        }

                        if (Fila.Rows[0]["usuClave"].ToString().Trim().Length > 0)
                        {
                            this.usuClave = Convert.ToString(Fila.Rows[0]["usuClave"]);
                        }
                        else
                        {
                            this.usuClave = "";
                        }

                        if (Fila.Rows[0]["usuClaveProvisoria"].ToString().Trim().Length > 0)
                        {
                            this.usuClaveProvisoria = Convert.ToString(Fila.Rows[0]["usuClaveProvisoria"]);
                        }
                        else
                        {
                            this.usuClaveProvisoria = "";
                        }

                        if (Fila.Rows[0]["usuEmail"].ToString().Trim().Length > 0)
                        {
                            this.usuEmail = Convert.ToString(Fila.Rows[0]["usuEmail"]);
                        }
                        else
                        {
                            this.usuEmail = "";
                        }

                        if (Fila.Rows[0]["usuFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.usuFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["usuFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.usuFechaHoraCreacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["usuFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.usuFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["usuFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.usuFechaHoraUltimaModificacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["usuCambiarClave"].ToString().Trim().Length > 0)
                        {
                            this.usuCambiarClave = (Convert.ToInt32(Fila.Rows[0]["usuCambiarClave"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.usuCambiarClave = false;
                        }

                        if (Fila.Rows[0]["usuActivo"].ToString().Trim().Length > 0)
                        {
                            this.usuActivo = (Convert.ToInt32(Fila.Rows[0]["usuActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.usuActivo = false;
                        }

                        if (Fila.Rows[0]["perId"].ToString().Trim().Length > 0)
                        {
                            this.perId = Convert.ToInt32(Fila.Rows[0]["perId"]);
                        }
                        else
                        {
                            this.perId = 0;
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

            public Usuario(int usuId, string usuApellido, string usuNombre, string usuNombreIngreso, string usuClave, string usuClaveProvisoria, bool usuCambiarClave, string usuEmail, System.DateTime usuFechaHoraCreacion, System.DateTime usuFechaHoraUltimaModificacion,
            bool usuActivo, int IperId, int IusuIdCreacion, int IusuIdUltimaModificacion)
            {
                try
                {
                    this.usuId = usuId;
                    this.usuApellido = usuApellido;
                    this.usuNombre = usuNombre;
                    this.usuNombreIngreso = usuNombreIngreso;
                    this.usuClave = usuClave;
                    this.usuClaveProvisoria = usuClaveProvisoria;
                    this.usuCambiarClave = usuCambiarClave;
                    this.usuEmail = usuEmail;
                    this.usuFechaHoraCreacion = usuFechaHoraCreacion;
                    this.usuFechaHoraUltimaModificacion = usuFechaHoraUltimaModificacion;
                    this.usuActivo = usuActivo;
                    this.perId = perId;
                    this.usuIdCreacion = usuIdCreacion;
                    this.usuIdUltimaModificacion = usuIdUltimaModificacion;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            public DataTable ObtenerAutenticar(string usuNombreIngreso, string usuClave)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerAutenticar]", new object[,] {
                        {
                            "@usuNombreIngreso",
                            usuNombreIngreso
                        },
                        {
                            "@usuClave",
                            usuClave
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerBuscador(string ValorABuscar)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerBuscador]", new object[,] { {
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

            public DataTable ObtenerBuscadorCustomAlumnoDocente(string ValorABuscar)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerBuscadorCustomAlumnoDocente]", new object[,] { {
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

            public DataTable ObtenerGrupo(int usuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerGrupo]", new object[,] { {
                        "@usuId",
                        usuId
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
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerLista]", new object[,] { {
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

            public DataTable ObtenerListaCustom(string PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerListaCustom]", new object[,] { {
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
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerTodo]", new object[,] { });
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
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerTodoBuscarxNombre]", new object[,] { {
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

            public DataTable ObtenerTodoCustom(string Nombre, string Apellido, string Usuario, int perId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerTodoCustom]", new object[,] {
                        {
                            "@Nombre",
                            Nombre
                        },
                        {
                            "@Apellido",
                            Apellido
                        },
                        {
                            "@Usuario",
                            Usuario
                        },
                        {
                            "@perId",
                            perId
                        },
                         {
                            "@MostrarAlumnos",
                            1
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(int usuId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerUno]", new object[,] { {
                        "@usuId",
                        usuId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerUnoUsuarioEmail(string Usuario, string Email)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerUnoUsuarioEmail]", new object[,] {
                        {
                            "@Usuario",
                            Usuario
                        },
                        {
                            "@Email",
                            Email
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerValidarRepetido(int usuId, string usuNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerValidarRepetido]", new object[,] {
                        {
                            "@usuId",
                            usuId
                        },
                        {
                            "@usuNombre",
                            usuNombre
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerValidarSiExisteEmail(string Usuario, string Email)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerValidarSiExisteEmail]", new object[,] {
                        {
                            "@Usuario",
                            Usuario
                        },
                        {
                            "@Email",
                            Email
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public void ActivarInactivar(int usuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Usuario.ActivarInactivar]", new object[,] { {
                        "@usuId",
                        usuId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Actualizar(int usuId, string usuApellido, string usuNombre, string usuNombreIngreso, string usuClave, string usuClaveProvisoria, bool usuCambiarClave, string usuEmail, int perId, int usuIdCreacion,
            int usuIdUltimaModificacion, System.DateTime usuFechaHoraCreacion, System.DateTime usuFechaHoraUltimaModificacion, bool usuActivo)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Usuario.Actualizar]", new object[,] {
                        {
                            "@usuId",
                            usuId
                        },
                        {
                            "@usuApellido",
                            usuApellido
                        },
                        {
                            "@usuNombre",
                            usuNombre
                        },
                        {
                            "@usuNombreIngreso",
                            usuNombreIngreso
                        },
                        {
                            "@usuClave",
                            usuClave
                        },
                        {
                            "@usuClaveProvisoria",
                            usuClaveProvisoria
                        },
                        {
                            "@usuCambiarClave",
                            usuCambiarClave
                        },
                        {
                            "@usuEmail",
                            usuEmail
                        },
                        {
                            "@perId",
                            perId
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
                            "@usuFechaHoraCreacion",
                            usuFechaHoraCreacion
                        },
                        {
                            "@usuFechaHoraUltimaModificacion",
                            usuFechaHoraUltimaModificacion
                        },
                        {
                            "@usuActivo",
                            usuActivo
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void BlanquearClave(int usuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Usuario.BlanquearClave]", new object[,] { {
                        "@usuId",
                        usuId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void BlanquearClaveUsuarioEmail(string Usuario, string Email)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Usuario.BlanquearClaveUsuarioEmail]", new object[,] {
                        {
                            "@Usuario",
                            Usuario
                        },
                        {
                            "@Email",
                            Email
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void CambiarClave(int usuId, string usuClave)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Usuario.CambiarClave]", new object[,] {
                        {
                            "@usuId",
                            usuId
                        },
                        {
                            "@usuClave",
                            usuClave
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Copiar(string usuApellido, string usuNombre, string usuNombreIngreso, string usuClave, string usuClaveProvisoria, bool usuCambiarClave, string usuEmail, int perId, int usuIdCreacion, int usuIdUltimaModificacion,
            System.DateTime usuFechaHoraCreacion, System.DateTime usuFechaHoraUltimaModificacion, bool usuActivo)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Usuario.Copiar]", new object[,] {
                        {
                            "@usuApellido",
                            usuApellido
                        },
                        {
                            "@usuNombre",
                            usuNombre
                        },
                        {
                            "@usuNombreIngreso",
                            usuNombreIngreso
                        },
                        {
                            "@usuClave",
                            usuClave
                        },
                        {
                            "@usuClaveProvisoria",
                            usuClaveProvisoria
                        },
                        {
                            "@usuCambiarClave",
                            usuCambiarClave
                        },
                        {
                            "@usuEmail",
                            usuEmail
                        },
                        {
                            "@perId",
                            perId
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
                            "@usuFechaHoraCreacion",
                            usuFechaHoraCreacion
                        },
                        {
                            "@usuFechaHoraUltimaModificacion",
                            usuFechaHoraUltimaModificacion
                        },
                        {
                            "@usuActivo",
                            usuActivo
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Eliminar(int usuId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Usuario.Eliminar]", new object[,] { {
                        "@usuId",
                        usuId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Insertar(string usuApellido, string usuNombre, string usuNombreIngreso, string usuClave, string usuClaveProvisoria, bool usuCambiarClave, string usuEmail, int perId, int usuIdCreacion, int usuIdUltimaModificacion,
            System.DateTime usuFechaHoraCreacion, System.DateTime usuFechaHoraUltimaModificacion, bool usuActivo)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Usuario.Insertar]", new object[,] {
                        {
                            "@usuApellido",
                            usuApellido
                        },
                        {
                            "@usuNombre",
                            usuNombre
                        },
                        {
                            "@usuNombreIngreso",
                            usuNombreIngreso
                        },
                        {
                            "@usuClave",
                            usuClave
                        },
                        {
                            "@usuClaveProvisoria",
                            usuClaveProvisoria
                        },
                        {
                            "@usuCambiarClave",
                            usuCambiarClave
                        },
                        {
                            "@usuEmail",
                            usuEmail
                        },
                        {
                            "@perId",
                            perId
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
                            "@usuFechaHoraCreacion",
                            usuFechaHoraCreacion
                        },
                        {
                            "@usuFechaHoraUltimaModificacion",
                            usuFechaHoraUltimaModificacion
                        },
                        {
                            "@usuActivo",
                            usuActivo
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
                    if (this.usuId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Usuario.Actualizar]", new object[,] {
                            {
                                "@usuId",
                                usuId
                            },
                            {
                                "@usuApellido",
                                usuApellido
                            },
                            {
                                "@usuNombre",
                                usuNombre
                            },
                            {
                                "@usuNombreIngreso",
                                usuNombreIngreso
                            },
                            {
                                "@usuClave",
                                usuClave
                            },
                            {
                                "@usuClaveProvisoria",
                                usuClaveProvisoria
                            },
                            {
                                "@usuCambiarClave",
                                usuCambiarClave
                            },
                            {
                                "@usuEmail",
                                usuEmail
                            },
                            {
                                "@perId",
                                perId
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
                                "@usuFechaHoraCreacion",
                                usuFechaHoraCreacion
                            },
                            {
                                "@usuFechaHoraUltimaModificacion",
                                usuFechaHoraUltimaModificacion
                            },
                            {
                                "@usuActivo",
                                usuActivo
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
                    if (this.usuId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Usuario.Copiar]", new object[,] {
                            {
                                "@usuApellido",
                                usuApellido
                            },
                            {
                                "@usuNombre",
                                usuNombre
                            },
                            {
                                "@usuNombreIngreso",
                                usuNombreIngreso
                            },
                            {
                                "@usuClave",
                                usuClave
                            },
                            {
                                "@usuClaveProvisoria",
                                usuClaveProvisoria
                            },
                            {
                                "@usuCambiarClave",
                                usuCambiarClave
                            },
                            {
                                "@usuEmail",
                                usuEmail
                            },
                            {
                                "@perId",
                                perId
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
                                "@usuFechaHoraCreacion",
                                usuFechaHoraCreacion
                            },
                            {
                                "@usuFechaHoraUltimaModificacion",
                                usuFechaHoraUltimaModificacion
                            },
                            {
                                "@usuActivo",
                                usuActivo
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
                    if (this.usuId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Usuario.Eliminar]", new object[,] { {
                            "@usuId",
                            usuId
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Usuario.Insertar]", new object[,] {
                        {
                            "@usuApellido",
                            usuApellido
                        },
                        {
                            "@usuNombre",
                            usuNombre
                        },
                        {
                            "@usuNombreIngreso",
                            usuNombreIngreso
                        },
                        {
                            "@usuClave",
                            usuClave
                        },
                        {
                            "@usuClaveProvisoria",
                            usuClaveProvisoria
                        },
                        {
                            "@usuCambiarClave",
                            usuCambiarClave
                        },
                        {
                            "@usuEmail",
                            usuEmail
                        },
                        {
                            "@perId",
                            perId
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
                            "@usuFechaHoraCreacion",
                            usuFechaHoraCreacion
                        },
                        {
                            "@usuFechaHoraUltimaModificacion",
                            usuFechaHoraUltimaModificacion
                        },
                        {
                            "@usuActivo",
                            usuActivo
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







