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
        public partial class PerfilMenu
        {
            #region Propiedades
            private Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila;

            private DataTable Tabla = new DataTable();
            private int _pmeId;
            public int pmeId
            {
                get { return _pmeId; }
                set { _pmeId = value; }
            }

            private bool _pmeActivo;
            public bool pmeActivo
            {
                get { return _pmeActivo; }
                set { _pmeActivo = value; }
            }

            private System.DateTime _pmeFechaHoraCreacion;
            public System.DateTime pmeFechaHoraCreacion
            {
                get { return _pmeFechaHoraCreacion; }
                set { _pmeFechaHoraCreacion = value; }
            }

            private System.DateTime _pmeFechaHoraUltimaModificacion;
            public System.DateTime pmeFechaHoraUltimaModificacion
            {
                get { return _pmeFechaHoraUltimaModificacion; }
                set { _pmeFechaHoraUltimaModificacion = value; }
            }

            private int _perId;
            public int perId
            {
                get { return _perId; }
                set { _perId = value; }
            }

            private int _menId;
            public int menId
            {
                get { return _menId; }
                set { _menId = value; }
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
            #endregion 

            public PerfilMenu()
            {
                try
                {
                    this.pmeId = 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public PerfilMenu(int pmeId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[PerfilMenu.ObtenerUno]", new object[,] { {
                        "@pmeId",
                        pmeId
                    } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["pmeId"].ToString().Trim().Length > 0)
                        {
                            this.pmeId = Convert.ToInt32(Fila.Rows[0]["pmeId"]);
                        }
                        else
                        {
                            this.pmeId = 0;
                        }

                        if (Fila.Rows[0]["pmeFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.pmeFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["pmeFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.pmeFechaHoraCreacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["pmeFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.pmeFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["pmeFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.pmeFechaHoraUltimaModificacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["pmeActivo"].ToString().Trim().Length > 0)
                        {
                            this.pmeActivo = (Convert.ToInt32(Fila.Rows[0]["pmeActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.pmeActivo = false;
                        }

                        if (Fila.Rows[0]["perId"].ToString().Trim().Length > 0)
                        {
                            this.perId = Convert.ToInt32(Fila.Rows[0]["perId"]);
                        }
                        else
                        {
                            this.perId = 0;
                        }

                        if (Fila.Rows[0]["menId"].ToString().Trim().Length > 0)
                        {
                            this.menId = Convert.ToInt32(Fila.Rows[0]["menId"]);
                        }
                        else
                        {
                            this.menId = 0;
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

            public PerfilMenu(int pmeId, bool pmeActivo, System.DateTime pmeFechaHoraCreacion, System.DateTime pmeFechaHoraUltimaModificacion, int IperId, int ImenId, int IusuIdCreacion, int IusuIdUltimaModificacion)
            {
                try
                {
                    this.pmeId = pmeId;
                    this.pmeActivo = pmeActivo;
                    this.pmeFechaHoraCreacion = pmeFechaHoraCreacion;
                    this.pmeFechaHoraUltimaModificacion = pmeFechaHoraUltimaModificacion;
                    this.perId = perId;
                    this.menId = menId;
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
                    Tabla = ocdGestor.EjecutarReader("[PerfilMenu.ObtenerTodo]", new object[,]{});
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerUno(int pmeId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[PerfilMenu.ObtenerUno]", new object[,] { {
                        "@pmeId",
                        pmeId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerxperIdCustom(int perId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[PerfilMenu.ObtenerxperIdCustom]", new object[,] { {
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

            public void Actualizar(int pmeId, int perId, int menId, bool pmeActivo, int usuIdCreacion, int usuIdUltimaModificacion, System.DateTime pmeFechaHoraCreacion, System.DateTime pmeFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PerfilMenu.Actualizar]", new object[,] {
                        {
                            "@pmeId",
                            pmeId
                        },
                        {
                            "@perId",
                            perId
                        },
                        {
                            "@menId",
                            menId
                        },
                        {
                            "@pmeActivo",
                            pmeActivo
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
                            "@pmeFechaHoraCreacion",
                            pmeFechaHoraCreacion
                        },
                        {
                            "@pmeFechaHoraUltimaModificacion",
                            pmeFechaHoraUltimaModificacion
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Eliminar(int pmeId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PerfilMenu.Eliminar]", new object[,] { {
                        "@pmeId",
                        pmeId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void EliminarPadresSinHijos(int perId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PerfilMenu.EliminarPadresSinHijos]", new object[,] { {
                        "@perId",
                        perId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Insertar(int perId, int menId, bool pmeActivo, int usuIdCreacion, int usuIdUltimaModificacion, System.DateTime pmeFechaHoraCreacion, System.DateTime pmeFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[PerfilMenu.Insertar]", new object[,] {
                        {
                            "@perId",
                            perId
                        },
                        {
                            "@menId",
                            menId
                        },
                        {
                            "@pmeActivo",
                            pmeActivo
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
                            "@pmeFechaHoraCreacion",
                            pmeFechaHoraCreacion
                        },
                        {
                            "@pmeFechaHoraUltimaModificacion",
                            pmeFechaHoraUltimaModificacion
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
                    if (this.pmeId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[PerfilMenu.Actualizar]", new object[,] {
                            {
                                "@pmeId",
                                pmeId
                            },
                            {
                                "@perId",
                                perId
                            },
                            {
                                "@menId",
                                menId
                            },
                            {
                                "@pmeActivo",
                                pmeActivo
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
                                "@pmeFechaHoraCreacion",
                                pmeFechaHoraCreacion
                            },
                            {
                                "@pmeFechaHoraUltimaModificacion",
                                pmeFechaHoraUltimaModificacion
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
                    if (this.pmeId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[PerfilMenu.Eliminar]", new object[,] { {
                            "@pmeId",
                            pmeId
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[PerfilMenu.Insertar]", new object[,] {
                        {
                            "@perId",
                            perId
                        },
                        {
                            "@menId",
                            menId
                        },
                        {
                            "@pmeActivo",
                            pmeActivo
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
                            "@pmeFechaHoraCreacion",
                            pmeFechaHoraCreacion
                        },
                        {
                            "@pmeFechaHoraUltimaModificacion",
                            pmeFechaHoraUltimaModificacion
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







