using LiquidacionSueldos.Datos;
using System;
using System.Data;

namespace LiquidacionSueldos.Negocio
{
    public class LiquidacionNovedades
    {
        private Gestor ocdGestor = new Gestor();

        private DataTable Tabla = new DataTable();

        private int _liqId;

        private string _liqDescripcion;

        private string _liqMes;

        private string _liqAnio;

        private int _liqEtapa;

        private string _liqEstado;

        private string _mesAnioLiq;

        private DateTime _liqFechaInicio;

        private DateTime? _liqFechaCierre;

        private int _liqActivo;

        public int liqActivo
        {
            get
            {
                return this._liqActivo;
            }
            set
            {
                this._liqActivo = value;
            }
        }

        public string liqAnio
        {
            get
            {
                return this._liqAnio;
            }
            set
            {
                this._liqAnio = value;
            }
        }

        public string liqDescripcion
        {
            get
            {
                return this._liqDescripcion;
            }
            set
            {
                this._liqDescripcion = value;
            }
        }

        public string liqEstado
        {
            get
            {
                return this._liqEstado;
            }
            set
            {
                this._liqEstado = value;
            }
        }

        public int liqEtapa
        {
            get
            {
                return this._liqEtapa;
            }
            set
            {
                this._liqEtapa = value;
            }
        }

        public DateTime? liqFechaCierre
        {
            get
            {
                return this._liqFechaCierre;
            }
            set
            {
                this._liqFechaCierre = value;
            }
        }

        public DateTime liqFechaInicio
        {
            get
            {
                return this._liqFechaInicio;
            }
            set
            {
                this._liqFechaInicio = value;
            }
        }

        public int liqId
        {
            get
            {
                return this._liqId;
            }
            set
            {
                this._liqId = value;
            }
        }

        public string liqMes
        {
            get
            {
                return this._liqMes;
            }
            set
            {
                this._liqMes = value;
            }
        }

        public string mesAnioLiq
        {
            get
            {
                return this._mesAnioLiq;
            }
            set
            {
                this._mesAnioLiq = value;
            }
        }

        public LiquidacionNovedades()
        {
        }

        public void AbrirEtapa(int liqId)
        {
            try
            {
                Gestor gestor = this.ocdGestor;
                object[,] objArray = new object[1, 2];
                objArray[0, 0] = "@liqIdDestino";
                objArray[0, 1] = liqId;
                gestor.EjecutarNonQuery("[LiquidacionNovedades.AbrirEtapa]", objArray);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Actualizar(int liqId, string liqDescripcion, string liqMes, string liqAnio, int liqEtapa, string liqEstado, DateTime liqFechaInicio, DateTime? liqFechaCierre, int liqActivo)
        {
            try
            {
                Gestor gestor = this.ocdGestor;
                object[,] objArray = new object[9, 2];
                objArray[0, 0] = "@liqId";
                objArray[0, 1] = liqId;
                objArray[1, 0] = "@liqDescripcion";
                objArray[1, 1] = liqDescripcion;
                objArray[2, 0] = "@liqMes";
                objArray[2, 1] = liqMes;
                objArray[3, 0] = "@liqAnio";
                objArray[3, 1] = liqAnio;
                objArray[4, 0] = "@liqEtapa";
                objArray[4, 1] = liqEtapa;
                objArray[5, 0] = "@liqEstado";
                objArray[5, 1] = liqEstado;
                objArray[6, 0] = "@liqFechaInicio";
                objArray[6, 1] = liqFechaInicio;
                objArray[7, 0] = "@liqFechaCierre";
                objArray[7, 1] = liqFechaCierre;
                objArray[8, 0] = "@liqActivo";
                objArray[8, 1] = liqActivo;
                gestor.EjecutarNonQuery("[LiquidacionNovedades.Actualizar]", objArray);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void ActualizarEstado(int liqId, string liqEstado)
        {
            try
            {
                Gestor gestor = this.ocdGestor;
                object[,] objArray = new object[2, 2];
                objArray[0, 0] = "@liqId";
                objArray[0, 1] = liqId;
                objArray[1, 0] = "@liqEstado";
                objArray[1, 1] = liqEstado;
                gestor.EjecutarNonQuery("[LiquidacionNovedades.ActualizarEstado]", objArray);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public int Insertar()
        {
            int num;
            try
            {
                Gestor gestor = this.ocdGestor;
                object[,] objArray = new object[6, 2];
                objArray[0, 0] = "@liqDescripcion";
                objArray[0, 1] = this.liqDescripcion;
                objArray[1, 0] = "@liqMes";
                objArray[1, 1] = this.liqMes;
                objArray[2, 0] = "@liqAnio";
                objArray[2, 1] = this.liqAnio;
                objArray[3, 0] = "@liqEtapa";
                objArray[3, 1] = this.liqEtapa;
                objArray[4, 0] = "@liqEstado";
                objArray[4, 1] = this.liqEstado;
                objArray[5, 0] = "@liqFechaInicio";
                objArray[5, 1] = this.liqFechaInicio;
                num = gestor.EjecutarNonQueryRetornaId("[LiquidacionNovedades.Insertar]", objArray);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }

        public LiquidacionNovedades ObtenerLiquidacionAbierta()
        {
            this.ocdGestor = new Gestor();
            this.Tabla = new DataTable();
            LiquidacionNovedades liquidacionNovedades = new LiquidacionNovedades();
            try
            {
                this.Tabla = this.ocdGestor.EjecutarReader("[LiquidacionNovedades.ObtenerLiquidacionAbierta]", new object[0, 0]);
                if (this.Tabla.Rows.Count <= 0)
                {
                    liquidacionNovedades = null;
                }
                else
                {
                    if (this.Tabla.Rows[0]["liqId"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqId = 0;
                    }
                    else
                    {
                        liquidacionNovedades.liqId = Convert.ToInt32(this.Tabla.Rows[0]["liqId"]);
                    }
                    if (this.Tabla.Rows[0]["liqDescripcion"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqDescripcion = "";
                    }
                    else
                    {
                        liquidacionNovedades.liqDescripcion = this.Tabla.Rows[0]["liqDescripcion"].ToString();
                    }
                    if (this.Tabla.Rows[0]["liqMes"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqMes = "";
                    }
                    else
                    {
                        liquidacionNovedades.liqMes = this.Tabla.Rows[0]["liqMes"].ToString();
                    }
                    if (this.Tabla.Rows[0]["liqAnio"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqAnio = "";
                    }
                    else
                    {
                        liquidacionNovedades.liqAnio = this.Tabla.Rows[0]["liqAnio"].ToString();
                    }
                    if ((liquidacionNovedades.liqMes != "") & (liquidacionNovedades.liqAnio != ""))
                    {
                        liquidacionNovedades.mesAnioLiq = string.Concat(liquidacionNovedades.liqMes, "/", liquidacionNovedades.liqAnio);
                    }
                    if (this.Tabla.Rows[0]["liqEtapa"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqEtapa = 0;
                    }
                    else
                    {
                        liquidacionNovedades.liqEtapa = Convert.ToInt32(this.Tabla.Rows[0]["liqEtapa"]);
                    }
                    if (this.Tabla.Rows[0]["liqEstado"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqEstado = "";
                    }
                    else
                    {
                        liquidacionNovedades.liqEstado = this.Tabla.Rows[0]["liqEstado"].ToString();
                    }
                    if (this.Tabla.Rows[0]["liqFechaInicio"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqFechaInicio = Convert.ToDateTime("01/01/2001");
                    }
                    else
                    {
                        liquidacionNovedades.liqFechaInicio = Convert.ToDateTime(this.Tabla.Rows[0]["liqFechaInicio"].ToString());
                    }
                    if (this.Tabla.Rows[0]["liqFechaCierre"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqFechaCierre = new DateTime?(Convert.ToDateTime("01/01/2001"));
                    }
                    else
                    {
                        liquidacionNovedades.liqFechaCierre = new DateTime?(Convert.ToDateTime(this.Tabla.Rows[0]["liqFechaCierre"].ToString()));
                    }
                    if (this.Tabla.Rows[0]["liqActivo"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqActivo = 0;
                    }
                    else
                    {
                        liquidacionNovedades.liqActivo = Convert.ToInt32(this.Tabla.Rows[0]["liqActivo"]);
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return liquidacionNovedades;
        }

        public LiquidacionNovedades ObtenerLiquidacionAbiertaPersonal()
        {
            this.ocdGestor = new Gestor();
            this.Tabla = new DataTable();
            LiquidacionNovedades liquidacionNovedades = new LiquidacionNovedades();
            try
            {
                this.Tabla = this.ocdGestor.EjecutarReader("[LiquidacionNovedades.ObtenerLiquidacionAbiertaPersonal]", new object[0, 0]);
                if (this.Tabla.Rows.Count <= 0)
                {
                    liquidacionNovedades = null;
                }
                else
                {
                    if (this.Tabla.Rows[0]["liqId"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqId = 0;
                    }
                    else
                    {
                        liquidacionNovedades.liqId = Convert.ToInt32(this.Tabla.Rows[0]["liqId"]);
                    }
                    if (this.Tabla.Rows[0]["liqDescripcion"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqDescripcion = "";
                    }
                    else
                    {
                        liquidacionNovedades.liqDescripcion = this.Tabla.Rows[0]["liqDescripcion"].ToString();
                    }
                    if (this.Tabla.Rows[0]["liqMes"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqMes = "";
                    }
                    else
                    {
                        liquidacionNovedades.liqMes = this.Tabla.Rows[0]["liqMes"].ToString();
                    }
                    if (this.Tabla.Rows[0]["liqAnio"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqAnio = "";
                    }
                    else
                    {
                        liquidacionNovedades.liqAnio = this.Tabla.Rows[0]["liqAnio"].ToString();
                    }
                    if ((liquidacionNovedades.liqMes != "") & (liquidacionNovedades.liqAnio != ""))
                    {
                        liquidacionNovedades.mesAnioLiq = string.Concat(liquidacionNovedades.liqMes, "/", liquidacionNovedades.liqAnio);
                    }
                    if (this.Tabla.Rows[0]["liqEtapa"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqEtapa = 0;
                    }
                    else
                    {
                        liquidacionNovedades.liqEtapa = Convert.ToInt32(this.Tabla.Rows[0]["liqEtapa"]);
                    }
                    if (this.Tabla.Rows[0]["liqEstado"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqEstado = "";
                    }
                    else
                    {
                        liquidacionNovedades.liqEstado = this.Tabla.Rows[0]["liqEstado"].ToString();
                    }
                    if (this.Tabla.Rows[0]["liqFechaInicio"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqFechaInicio = Convert.ToDateTime("01/01/2001");
                    }
                    else
                    {
                        liquidacionNovedades.liqFechaInicio = Convert.ToDateTime(this.Tabla.Rows[0]["liqFechaInicio"].ToString());
                    }
                    if (this.Tabla.Rows[0]["liqFechaCierre"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqFechaCierre = new DateTime?(Convert.ToDateTime("01/01/2001"));
                    }
                    else
                    {
                        liquidacionNovedades.liqFechaCierre = new DateTime?(Convert.ToDateTime(this.Tabla.Rows[0]["liqFechaCierre"].ToString()));
                    }
                    if (this.Tabla.Rows[0]["liqActivo"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqActivo = 0;
                    }
                    else
                    {
                        liquidacionNovedades.liqActivo = Convert.ToInt32(this.Tabla.Rows[0]["liqActivo"]);
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return liquidacionNovedades;
        }

        public DataTable ObtenerTodos(string liqMes, string liqAnio, int liqEtapa)
        {
            try
            {
                this.Tabla = new DataTable();
                Gestor gestor = this.ocdGestor;
                object[,] objArray = new object[3, 2];
                objArray[0, 0] = "@liqMes";
                objArray[0, 1] = liqMes;
                objArray[1, 0] = "@liqAnio";
                objArray[1, 1] = liqAnio;
                objArray[2, 0] = "@liqEtapa";
                objArray[2, 1] = liqEtapa;
                this.Tabla = gestor.EjecutarReader("[LiquidacionNovedades.ObtenerTodoPorMesAnio]", objArray);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return this.Tabla;
        }

        public DataTable ObtenerTodosSelect()
        {
            this.ocdGestor = new Gestor();
            this.Tabla = new DataTable();
            try
            {
                this.Tabla = this.ocdGestor.EjecutarReader("[LiquidacionNovedades.ObtenerTodosSelect]", new object[0, 0]);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return this.Tabla;
        }

        public DataTable ObtenerUno(string liqMes, string liqAnio, string liqEtapa)
        {
            try
            {
                this.Tabla = new DataTable();
                Gestor gestor = this.ocdGestor;
                object[,] objArray = new object[3, 2];
                objArray[0, 0] = "@liqMes";
                objArray[0, 1] = liqMes;
                objArray[1, 0] = "@liqAnio";
                objArray[1, 1] = liqAnio;
                objArray[2, 0] = "@liqEtapa";
                objArray[2, 1] = liqEtapa;
                this.Tabla = gestor.EjecutarReader("[LiquidacionNovedades.ObtenerUno]", objArray);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return this.Tabla;
        }

        public LiquidacionNovedades ObtenerUno(int liqId)
        {
            LiquidacionNovedades liquidacionNovedades = new LiquidacionNovedades();
            try
            {
                this.Tabla = new DataTable();
                Gestor gestor = this.ocdGestor;
                object[,] objArray = new object[1, 2];
                objArray[0, 0] = "@liqId";
                objArray[0, 1] = liqId;
                this.Tabla = gestor.EjecutarReader("[LiquidacionNovedades.ObtenerUnoPorLiqId]", objArray);
                if (this.Tabla.Rows.Count > 0)
                {
                    if (this.Tabla.Rows[0]["liqId"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqId = 0;
                    }
                    else
                    {
                        liquidacionNovedades.liqId = Convert.ToInt32(this.Tabla.Rows[0]["liqId"]);
                    }
                    if (this.Tabla.Rows[0]["liqDescripcion"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqDescripcion = "";
                    }
                    else
                    {
                        liquidacionNovedades.liqDescripcion = this.Tabla.Rows[0]["liqDescripcion"].ToString();
                    }
                    if (this.Tabla.Rows[0]["liqMes"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqMes = "";
                    }
                    else
                    {
                        liquidacionNovedades.liqMes = this.Tabla.Rows[0]["liqMes"].ToString();
                    }
                    if (this.Tabla.Rows[0]["liqAnio"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqAnio = "";
                    }
                    else
                    {
                        liquidacionNovedades.liqAnio = this.Tabla.Rows[0]["liqAnio"].ToString();
                    }
                    if (this.Tabla.Rows[0]["liqEtapa"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqEtapa = 0;
                    }
                    else
                    {
                        liquidacionNovedades.liqEtapa = Convert.ToInt32(this.Tabla.Rows[0]["liqEtapa"]);
                    }
                    if (this.Tabla.Rows[0]["liqEstado"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqEstado = "";
                    }
                    else
                    {
                        liquidacionNovedades.liqEstado = this.Tabla.Rows[0]["liqEstado"].ToString();
                    }
                    if (this.Tabla.Rows[0]["liqFechaInicio"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqFechaInicio = Convert.ToDateTime("01/01/2001");
                    }
                    else
                    {
                        liquidacionNovedades.liqFechaInicio = Convert.ToDateTime(this.Tabla.Rows[0]["liqFechaInicio"].ToString());
                    }
                    if (this.Tabla.Rows[0]["liqFechaCierre"].ToString().Trim().Length <= 0)
                    {
                        liquidacionNovedades.liqFechaCierre = new DateTime?(Convert.ToDateTime("01/01/2001"));
                    }
                    else
                    {
                        liquidacionNovedades.liqFechaCierre = new DateTime?(Convert.ToDateTime(this.Tabla.Rows[0]["liqFechaCierre"].ToString()));
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return liquidacionNovedades;
        }

        public int ValidarRepetido(string liqMes, string liqAnio, int liqEtapa)
        {
            this.ocdGestor = new Gestor();
            this.Tabla = new DataTable();
            int num = 0;
            try
            {
                Gestor gestor = this.ocdGestor;
                object[,] objArray = new object[3, 2];
                objArray[0, 0] = "@liqMes";
                objArray[0, 1] = liqMes;
                objArray[1, 0] = "@liqAnio";
                objArray[1, 1] = liqAnio;
                objArray[2, 0] = "@liqEtapa";
                objArray[2, 1] = liqEtapa;
                this.Tabla = gestor.EjecutarReader("[LiquidacionNovedades.ValidarDuplicado]", objArray);
                if (this.Tabla.Rows.Count > 0)
                {
                    num = Convert.ToInt32(this.Tabla.Rows[0]["Existe"].ToString());
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }
    }
}