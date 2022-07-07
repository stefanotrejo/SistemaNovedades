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
        public partial class Menu
        {
            private Datos.Gestor ocdGestor = new Datos.Gestor();
            private DataTable Fila;

            private DataTable Tabla = new DataTable();
            private int _menId;
            public int menId
            {
                get { return _menId; }
                set { _menId = value; }
            }

            private string _menNombre;
            public string menNombre
            {
                get { return _menNombre; }
                set { _menNombre = value; }
            }

            private int _menOrden;
            public int menOrden
            {
                get { return _menOrden; }
                set { _menOrden = value; }
            }

            private string _menUrl;
            public string menUrl
            {
                get { return _menUrl; }
                set { _menUrl = value; }
            }

            private string _menIcono;
            public string menIcono
            {
                get { return _menIcono; }
                set { _menIcono = value; }
            }

            private bool _menEsMenu;
            public bool menEsMenu
            {
                get { return _menEsMenu; }
                set { _menEsMenu = value; }
            }

            private bool _menActivo;
            public bool menActivo
            {
                get { return _menActivo; }
                set { _menActivo = value; }
            }

            private System.DateTime _menFechaHoraCreacion;
            public System.DateTime menFechaHoraCreacion
            {
                get { return _menFechaHoraCreacion; }
                set { _menFechaHoraCreacion = value; }
            }

            private System.DateTime _menFechaHoraUltimaModificacion;
            public System.DateTime menFechaHoraUltimaModificacion
            {
                get { return _menFechaHoraUltimaModificacion; }
                set { _menFechaHoraUltimaModificacion = value; }
            }

            private int _menIdPadre;
            public int menIdPadre
            {
                get { return _menIdPadre; }
                set { _menIdPadre = value; }
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

            public Menu()
            {
                try
                {
                    this.menId = 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public Menu(int menId)
            {
                try
                {
                    Fila = new DataTable();
                    Fila = ocdGestor.EjecutarReader("[Menu.ObtenerUno]", new object[,] { {
                        "@menId",
                        menId
                    } });

                    if (Fila.Rows.Count > 0)
                    {
                        if (Fila.Rows[0]["menId"].ToString().Trim().Length > 0)
                        {
                            this.menId = Convert.ToInt32(Fila.Rows[0]["menId"]);
                        }
                        else
                        {
                            this.menId = 0;
                        }

                        if (Fila.Rows[0]["menNombre"].ToString().Trim().Length > 0)
                        {
                            this.menNombre = Convert.ToString(Fila.Rows[0]["menNombre"]);
                        }
                        else
                        {
                            this.menNombre = "";
                        }

                        if (Fila.Rows[0]["menOrden"].ToString().Trim().Length > 0)
                        {
                            this.menOrden = Convert.ToInt32(Fila.Rows[0]["menOrden"]);
                        }
                        else
                        {
                            this.menOrden = 0;
                        }

                        if (Fila.Rows[0]["menUrl"].ToString().Trim().Length > 0)
                        {
                            this.menUrl = Convert.ToString(Fila.Rows[0]["menUrl"]);
                        }
                        else
                        {
                            this.menUrl = "";
                        }

                        if (Fila.Rows[0]["menIcono"].ToString().Trim().Length > 0)
                        {
                            this.menIcono = Convert.ToString(Fila.Rows[0]["menIcono"]);
                        }
                        else
                        {
                            this.menIcono = "";
                        }

                        if (Fila.Rows[0]["menFechaHoraCreacion"].ToString().Trim().Length > 0)
                        {
                            this.menFechaHoraCreacion = Convert.ToDateTime(Fila.Rows[0]["menFechaHoraCreacion"]);
                        }
                        else
                        {
                            this.menFechaHoraCreacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["menFechaHoraUltimaModificacion"].ToString().Trim().Length > 0)
                        {
                            this.menFechaHoraUltimaModificacion = Convert.ToDateTime(Fila.Rows[0]["menFechaHoraUltimaModificacion"]);
                        }
                        else
                        {
                            this.menFechaHoraUltimaModificacion = System.DateTime.Now;
                        }

                        if (Fila.Rows[0]["menEsMenu"].ToString().Trim().Length > 0)
                        {
                            this.menEsMenu = (Convert.ToInt32(Fila.Rows[0]["menEsMenu"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.menEsMenu = false;
                        }

                        if (Fila.Rows[0]["menActivo"].ToString().Trim().Length > 0)
                        {
                            this.menActivo = (Convert.ToInt32(Fila.Rows[0]["menActivo"]) == 1 ? true : false);
                        }
                        else
                        {
                            this.menActivo = false;
                        }

                        if (Fila.Rows[0]["menIdPadre"].ToString().Trim().Length > 0)
                        {
                            this.menIdPadre = Convert.ToInt32(Fila.Rows[0]["menIdPadre"]);
                        }
                        else
                        {
                            this.menIdPadre = 0;
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

            public Menu(int menId, string menNombre, int menOrden, string menUrl, string menIcono, bool menEsMenu, bool menActivo, System.DateTime menFechaHoraCreacion, System.DateTime menFechaHoraUltimaModificacion, int ImenIdPadre,
            int IusuIdCreacion, int IusuIdUltimaModificacion)
            {
                try
                {
                    this.menId = menId;
                    this.menNombre = menNombre;
                    this.menOrden = menOrden;
                    this.menUrl = menUrl;
                    this.menIcono = menIcono;
                    this.menEsMenu = menEsMenu;
                    this.menActivo = menActivo;
                    this.menFechaHoraCreacion = menFechaHoraCreacion;
                    this.menFechaHoraUltimaModificacion = menFechaHoraUltimaModificacion;
                    this.menIdPadre = menIdPadre;
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
                    Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerBuscador]", new object[,] { {
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
                    Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerLista]", new object[,] { {
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

            public DataTable ObtenerListaAsociarACustom(int perId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerListaAsociarACustom]", new object[,] { {
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

            public DataTable ObtenerListaRaiz(string PrimerItem)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerListaRaiz]", new object[,] { {
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

            public DataTable ObtenerMenuSecundario(int menIdPadre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerMenuSecundario]", new object[,] { {
                        "@menIdPadre",
                        menIdPadre
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
                    Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerTodo]", new object[,]{});
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
                    Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerTodoBuscarxNombre]", new object[,] { {
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

            public DataTable ObtenerUno(int menId)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerUno]", new object[,] { {
                        "@menId",
                        menId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public DataTable ObtenerValidarRepetido(int menId, string menNombre)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();

                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerValidarRepetido]", new object[,] {
                        {
                            "@menId",
                            menId
                        },
                        {
                            "@menNombre",
                            menNombre
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Tabla;
            }

            public void ActivarInactivar(int menId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Menu.ActivarInactivar]", new object[,] { {
                        "@menId",
                        menId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Actualizar(int menId, string menNombre, int menIdPadre, int menOrden, string menUrl, string menIcono, bool menEsMenu, bool menActivo, int usuIdCreacion, int usuIdUltimaModificacion,
            System.DateTime menFechaHoraCreacion, System.DateTime menFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Menu.Actualizar]", new object[,] {
                        {
                            "@menId",
                            menId
                        },
                        {
                            "@menNombre",
                            menNombre
                        },
                        {
                            "@menIdPadre",
                            menIdPadre
                        },
                        {
                            "@menOrden",
                            menOrden
                        },
                        {
                            "@menUrl",
                            menUrl
                        },
                        {
                            "@menIcono",
                            menIcono
                        },
                        {
                            "@menEsMenu",
                            menEsMenu
                        },
                        {
                            "@menActivo",
                            menActivo
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
                            "@menFechaHoraCreacion",
                            menFechaHoraCreacion
                        },
                        {
                            "@menFechaHoraUltimaModificacion",
                            menFechaHoraUltimaModificacion
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Copiar(string menNombre, int menIdPadre, int menOrden, string menUrl, string menIcono, bool menEsMenu, bool menActivo, int usuIdCreacion, int usuIdUltimaModificacion, System.DateTime menFechaHoraCreacion,
            System.DateTime menFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Menu.Copiar]", new object[,] {
                        {
                            "@menNombre",
                            menNombre
                        },
                        {
                            "@menIdPadre",
                            menIdPadre
                        },
                        {
                            "@menOrden",
                            menOrden
                        },
                        {
                            "@menUrl",
                            menUrl
                        },
                        {
                            "@menIcono",
                            menIcono
                        },
                        {
                            "@menEsMenu",
                            menEsMenu
                        },
                        {
                            "@menActivo",
                            menActivo
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
                            "@menFechaHoraCreacion",
                            menFechaHoraCreacion
                        },
                        {
                            "@menFechaHoraUltimaModificacion",
                            menFechaHoraUltimaModificacion
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Eliminar(int menId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Menu.Eliminar]", new object[,] { {
                        "@menId",
                        menId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void EliminarCustom(int menId)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Menu.EliminarCustom]", new object[,] { {
                        "@menId",
                        menId
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Insertar(string menNombre, int menIdPadre, int menOrden, string menUrl, string menIcono, bool menEsMenu, bool menActivo, int usuIdCreacion, int usuIdUltimaModificacion, System.DateTime menFechaHoraCreacion,
            System.DateTime menFechaHoraUltimaModificacion)
            {
                try
                {
                    ocdGestor.EjecutarNonQuery("[Menu.Insertar]", new object[,] {
                        {
                            "@menNombre",
                            menNombre
                        },
                        {
                            "@menIdPadre",
                            menIdPadre
                        },
                        {
                            "@menOrden",
                            menOrden
                        },
                        {
                            "@menUrl",
                            menUrl
                        },
                        {
                            "@menIcono",
                            menIcono
                        },
                        {
                            "@menEsMenu",
                            menEsMenu
                        },
                        {
                            "@menActivo",
                            menActivo
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
                            "@menFechaHoraCreacion",
                            menFechaHoraCreacion
                        },
                        {
                            "@menFechaHoraUltimaModificacion",
                            menFechaHoraUltimaModificacion
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
                    if (this.menId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Menu.Actualizar]", new object[,] {
                            {
                                "@menId",
                                menId
                            },
                            {
                                "@menNombre",
                                menNombre
                            },
                            {
                                "@menIdPadre",
                                menIdPadre
                            },
                            {
                                "@menOrden",
                                menOrden
                            },
                            {
                                "@menUrl",
                                menUrl
                            },
                            {
                                "@menIcono",
                                menIcono
                            },
                            {
                                "@menEsMenu",
                                menEsMenu
                            },
                            {
                                "@menActivo",
                                menActivo
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
                                "@menFechaHoraCreacion",
                                menFechaHoraCreacion
                            },
                            {
                                "@menFechaHoraUltimaModificacion",
                                menFechaHoraUltimaModificacion
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
                    if (this.menId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Menu.Copiar]", new object[,] {
                            {
                                "@menNombre",
                                menNombre
                            },
                            {
                                "@menIdPadre",
                                menIdPadre
                            },
                            {
                                "@menOrden",
                                menOrden
                            },
                            {
                                "@menUrl",
                                menUrl
                            },
                            {
                                "@menIcono",
                                menIcono
                            },
                            {
                                "@menEsMenu",
                                menEsMenu
                            },
                            {
                                "@menActivo",
                                menActivo
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
                                "@menFechaHoraCreacion",
                                menFechaHoraCreacion
                            },
                            {
                                "@menFechaHoraUltimaModificacion",
                                menFechaHoraUltimaModificacion
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
                    if (this.menId != 0)
                    {
                        ocdGestor.EjecutarNonQuery("[Menu.Eliminar]", new object[,] { {
                            "@menId",
                            menId
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
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Menu.Insertar]", new object[,] {
                        {
                            "@menNombre",
                            menNombre
                        },
                        {
                            "@menIdPadre",
                            menIdPadre
                        },
                        {
                            "@menOrden",
                            menOrden
                        },
                        {
                            "@menUrl",
                            menUrl
                        },
                        {
                            "@menIcono",
                            menIcono
                        },
                        {
                            "@menEsMenu",
                            menEsMenu
                        },
                        {
                            "@menActivo",
                            menActivo
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
                            "@menFechaHoraCreacion",
                            menFechaHoraCreacion
                        },
                        {
                            "@menFechaHoraUltimaModificacion",
                            menFechaHoraUltimaModificacion
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdMax;
            }
            
            public DataTable ObtenerListaFechas()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerListaFechas]", new object[,] { {
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Tabla;
            }

            public DataTable ObtenerListaTodasLasFechas()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerTodasFechas]", new object[,] { {
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Tabla;
            }

            public DataTable LiquidacionObtenerTodo()
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Liquidacion.ObtenerTodo]", new object[,] { {
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Tabla;
            }

            public DataTable LiquidacionObtenerPorAnio(int anio)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Liquidacion.ObtenerLiqPorAnio]", new object[,] { {
                            "@anio",
                                anio
                    } });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Tabla;
            }

            public DataTable LiquidacionObtenerUno(string periodo)
            {
                ocdGestor = new Datos.Gestor();
                Tabla = new DataTable();
                try
                {
                    Tabla = ocdGestor.EjecutarReader("[Liquidacion.ObtenerUno]", new object[,] 
                    {
                         {
                                "@periodo",
                                periodo
                            }
                    }
                    );
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Tabla;
            }
        }
    }
}







