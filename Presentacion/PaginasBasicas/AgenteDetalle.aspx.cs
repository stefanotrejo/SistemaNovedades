using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
public partial class UsuarioRegistracion : System.Web.UI.Page
{    
    LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente = new LiquidacionSueldos.Negocio.NuevoAge1();
    LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente2 = new LiquidacionSueldos.Negocio.NuevoAge1();

    #region  Variables Globales
    public class Globales
    {
        private static string _NroControl;
        public static string NroControl
        {
            get
            {
                // Reads are usually simple
                return _NroControl;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _NroControl = value;
            }
        }
        private static DataTable _dt;
        public static DataTable dt
        {
            get
            {
                // Reads are usually simple
                return _dt;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _dt = value;
            }
        }

        private static LiquidacionSueldos.Negocio.NuevoAge1 _oAgente;
        public static LiquidacionSueldos.Negocio.NuevoAge1 oAgente
        {
            get
            {
                // Reads are usually simple
                return _oAgente;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _oAgente = value;
            }
        }

        private static int _pagina;
        public static int pagina
        {
            get
            {
                // Reads are usually simple
                return _pagina;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _pagina = value;
            }
        }

        private static string _periodoseleccionado;
        public static string periodoseleccionado
        {
            get
            {
                // Reads are usually simple
                return _periodoseleccionado;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _periodoseleccionado = value;
            }
        }

        private static string _cuilGlobal;
        public static string cuilGlobal
        {
            get
            {
                // Reads are usually simple
                return _cuilGlobal;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _cuilGlobal = value;
            }
        }

        private static int _idGlobal;
        public static int idGlobal
        {
            get
            {
                // Reads are usually simple
                return _idGlobal;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _idGlobal = value;
            }
        }

        private static int _nroPagina;
        public static int nroPagina
        {
            get
            {
                // Reads are usually simple
                return _nroPagina;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _nroPagina = value;
            }
        }

        private static DateTime _periodoDesde;
        public static DateTime periodoDesde
        {
            get
            {
                // Reads are usually simple
                return _periodoDesde;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _periodoDesde = value;
            }
        }

        private static DateTime _periodoHasta;
        public static DateTime periodoHasta
        {
            get
            {
                // Reads are usually simple
                return _periodoHasta;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _periodoHasta = value;
            }
        }

        private static string _periodo;
        public static string periodo
        {
            get
            {
                // Reads are usually simple
                return _periodo;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _periodo = value;
            }
        }

        private static string _textBox;
        public static string textBox
        {
            get
            {
                // Reads are usually simple
                return _textBox;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _textBox = value;
            }
        }
        private static int _tipoOp;
        public static int tipoOp
        {
            get
            {
                // Reads are usually simple
                return _tipoOp;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _tipoOp = value;
            }
        }

        private static string _index;
        public static string index
        {
            get
            {
                // Reads are usually simple
                return _index;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _index = value;
            }
        }



        // Perhaps extend this to have Read-Modify-Write static methods
        // for data integrity during concurrency? Situational.
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // Utilizo la variable de Session "Session["CadenaAgenteDetalle"]" para determinar si estoy llamando la pagina 
            // por llamada de la pagina "AgenteDetalle" y tengo que recargar los datos como estaban antes de irme a la otra pagina.
            // Si es distinto de vacio es porque vuelve de la pagina "agenteDetalle"

            if (Convert.ToString(Session["CadenaAgenteDetalle"]) == "")
            {
                if (!Page.IsPostBack)
                {
                    // Session["CadenaAgenteDetalle"] La utilizo para guardar la cadena que recibo por parametro desde la pantalla de Agente Consulta
                    Session["CadenaAgenteDetalle"] = ""; 
                    this.Master.TituloDelFormulario = "Consulta de Agentes";
                    if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                    int Id = 0;
                    if ((Request.QueryString["Id"] != null) && (Request.QueryString["Id"] != ""))
                    {
                        btnSiguiente.Enabled = true;
                        btnAnterior.Enabled = false;
                        String Cadena = Request.QueryString["Id"];
                        string[] parametros = Cadena.Split(',');
                        Id = Convert.ToInt32(parametros[0]);
                        Globales.idGlobal = Id;
                        Globales.periodo = parametros[1];
                        Globales.textBox = parametros[2];
                        Globales.tipoOp = Convert.ToInt32(parametros[3]);
                        Session["Tipo"] = Globales.tipoOp;
                        Globales.index = parametros[4];
                        //PRUEBA
                        Globales.periodoDesde = Convert.ToDateTime(parametros[5]);
                        Globales.periodoHasta = Convert.ToDateTime(parametros[6]);
                        Globales.pagina = 0;
                        Globales.nroPagina = -1;
                        Globales.cuilGlobal = "";

                        //FALLAN ALGUNAS VECES
                        //Globales.periodoDesde = Convert.ToDateTime(Session["Periodo1"]);
                        //Globales.periodoHasta = Convert.ToDateTime(Session["Periodo2"]);

                        Session["Resultado"] = 0;
                        Session["Tipo"] = Globales.tipoOp;
                        Session["index"] = Globales.index;
                        Session["Textbox"] = Globales.textBox;
                        if (Id != 0)
                        {
                            ocnAgente = new LiquidacionSueldos.Negocio.NuevoAge1();
                            CargarDatos(Id);                            
                        }
                    }
                    else
                    {
                        Session["Resultado"] = "";
                        Response.Redirect("AgenteConsulta.aspx", true);
                    }
                }
            }
            else //cuando vuelvo de otra pagina
            {
                int Id = 0;
                btnSiguiente.Enabled = true;
                btnAnterior.Enabled = false;
                String Cadena = Convert.ToString(Session["CadenaAgenteDetalle"]);
                Session["CadenaAgenteDetalle"] = "";
                string[] parametros = Cadena.Split(',');
                Id = Convert.ToInt32(parametros[0]);
                Globales.idGlobal = Id;
                Globales.periodo = parametros[1];
                Globales.textBox = parametros[2];
                Globales.tipoOp = Convert.ToInt32(parametros[3]);
                Session["Tipo"] = Globales.tipoOp;
                Globales.index = parametros[4];
                //PRUEBA
                Globales.periodoDesde = Convert.ToDateTime(parametros[5]);
                Globales.periodoHasta = Convert.ToDateTime(parametros[6]);
                Globales.pagina = 0;
                Globales.nroPagina = -1;
                Globales.cuilGlobal = "";
                
                Session["Resultado"] = 0;
                Session["Tipo"] = Globales.tipoOp;
                Session["index"] = Globales.index;
                Session["Textbox"] = Globales.textBox;
                if (Id != 0)
                {
                    ocnAgente = new LiquidacionSueldos.Negocio.NuevoAge1();
                    CargarDatos(Id);                                        
                }
            }
        }
        catch (Exception oError)
        {
            Session["Resultado"] = "";
            Response.Redirect("AgenteConsulta.aspx", true);
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Resultado"] = 0;

            //PRUEBA
            Session["Periodo1"] = Globales.periodoDesde;
            Session["Periodo2"] = Globales.periodoHasta;

            //PRUEBA 2
            Session["Tipo"] = Globales.tipoOp;
            Session["index"] = Globales.index;
            Session["Textbox"] = Globales.textBox;


            Response.Redirect("AgenteConsulta.aspx", true);

        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
            <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
            <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
            Se ha producido el siguiente error:<br/>
            MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
            "</div>";
        }
    }

    protected void btnSiguiente_Click(object sender, EventArgs e)
    {
        try
        {
            //if (Globales.pagina < (Convert.ToInt32(Globales.dt.Rows.Count.ToString())))
            if (Globales.nroPagina != (Convert.ToInt32(Globales.dt.Rows.Count.ToString())) - 1)
            {
                //llamar al procedimiento que trae todo por id
                //Globales.pagina++;
                //int indice2 = Convert.ToInt32(Globales.dt.Rows[Globales.pagina+1]["Id"]);
                Globales.nroPagina++;
                int indice2 = Convert.ToInt32(Globales.dt.Rows[Globales.nroPagina]["Id"]);
                string periodo2 = Globales.dt.Rows[Globales.nroPagina]["Fecha Liquidacion"].ToString();
                //periodo2 = periodo2.Substring(3, 7);
                /*periodo2 =  periodo2.Substring()*/
                ;
                //CargarDatos(indice2, Globales.periodoseleccionado); - FUNCIONA
                //CargarDatos(indice2, periodo2);
                CargarDatos(indice2);
                Globales.idGlobal = indice2;
                btnAnterior.Enabled = true;

                //Globales.nroPagina++;

                //if (Globales.pagina < Convert.ToInt32(Globales.dt.Rows.Count.ToString()))
                //if (Globales.nroPagina < Convert.ToInt32(Globales.dt.Rows.Count.ToString()))
                //{
                //    //Globales.pagina++;
                //    //Label2.Text = Globales.pagina.ToString();
                //}
                //else
                //{
                //if (Globales.pagina == Convert.ToInt32(Globales.dt.Rows.Count.ToString()))
                //{
                //    btnSiguiente.Enabled = false;
                //    //Label2.Text = Convert.ToString(Globales.pagina + 1);
                //    lblPaginaActual.Text = Convert.ToString(Globales.nroPagina);
                //    Globales.pagina--;
                //}
                //}
                //lblPaginaActual.Text = Convert.ToString(Globales.pagina + 1);

                //Globales.pagina--;
                //if (Globales.nroPagina == (Convert.ToInt32(Globales.dt.Rows.Count.ToString()))+1)
                //{
                //    btnSiguiente.Enabled = false;
                //    //Globales.pagina--;
                //}
                lblPaginaActual.Text = Convert.ToString(Globales.nroPagina + 2);
                if (Globales.nroPagina == (Convert.ToInt32(Globales.dt.Rows.Count.ToString())) - 1)
                    btnSiguiente.Enabled = false;
            }
            else
            {
                //Globales.pagina--;
                //    int indice2 = Convert.ToInt32(Globales.dt.Rows[Globales.pagina]["Id"]);
                //    //string periodo2 = Session["Periodo"].ToString();
                //    CargarDatos(indice2, Globales.periodoseleccionado);
                btnSiguiente.Enabled = false;
                //    //Globales.pagina++;
                //    Globales.nroPagina++;
                //    lblPaginaActual.Text = Convert.ToString(Globales.nroPagina);
            }
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
            <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
            <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
            Se ha producido el siguiente error:<br/>
            MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
            "</div>";
        }
    }

    protected void btnAnterior_Click(object sender, EventArgs e)
    {
        try
        {
            //if (Globales.pagina <= (Convert.ToInt32(Globales.dt.Rows.Count.ToString())))

            //if (Globales.pagina != 0)
            if (Globales.nroPagina != 0)
            {
                //Globales.pagina--;
                Globales.nroPagina--;
                int indice2 = Convert.ToInt32(Globales.dt.Rows[Globales.nroPagina]["Id"]);
                string periodo2 = Globales.dt.Rows[Globales.nroPagina]["Fecha Liquidacion"].ToString();
                //CargarDatos(indice2, Globales.periodoseleccionado);
                //CargarDatos(indice2, periodo2);
                CargarDatos(indice2);
                Globales.idGlobal = indice2;
                btnSiguiente.Enabled = true;                
                lblPaginaActual.Text = Convert.ToString(Globales.nroPagina + 2);                
            }
            else
            {
                Globales.nroPagina--;
                //CargarDatos(Globales.idGlobal, Globales.periodoseleccionado);
                //CargarDatos(Globales.idGlobal, Globales.periodo);
                CargarDatos(Globales.idGlobal);
                btnSiguiente.Enabled = true;
                btnAnterior.Enabled = false;
                //Globales.nroPagina--;
                //Globales.pagina = 0;
                lblPaginaActual.Text = Convert.ToString(Globales.nroPagina + 2);
            }
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
"</div>";
        }
    }

    protected void CargarDatos(int Id)
    {
        ocnAgente = new LiquidacionSueldos.Negocio.NuevoAge1();        
        ocnAgente = ocnAgente.ObtenerAgentePorId(Id);        
        if (Globales.cuilGlobal == "") //LO HAGO UNA SOLA VEZ AL INICIAR 
        {
            Globales.cuilGlobal = ocnAgente.Cuil;          
            Globales.dt = ocnAgente2.ObtenerCargosPorCuilyLiquidacionConFiltro(ocnAgente.Cuil.Substring(2, 8), Globales.periodoDesde, Globales.periodoHasta, Id);
            Label1.Text = "Cantidad de registros: " + Convert.ToString(Globales.dt.Rows.Count + 1);
            //Label2.Text = Convert.ToString(Globales.pagina + 1);
            lblPaginaActual.Text = Convert.ToString(Globales.nroPagina + 2);
            lblPaginaFin.Text = " de: " + Convert.ToString(Globales.dt.Rows.Count + 1);
            Globales.oAgente = ocnAgente;
            if (Globales.dt.Rows.Count == 0)
                btnSiguiente.Enabled = false;
        }
       
        this.txtAgeApellidoNombre.Text = ocnAgente.Nombre;
        this.txtAgeCuit.Text = ocnAgente.Cuil;

        // Cambio el substring del año porque ahora en lugar de 1992 solo manda el 92. 
        String FechaNac = "";
        if (ocnAgente.FechaNac != null)  
        FechaNac = ocnAgente.FechaNac.Substring(0, 2) + "/" + ocnAgente.FechaNac.Substring(2, 2) + "/" + ocnAgente.FechaNac.Substring(4, 2);
              
        this.txtFehaNac.Text = FechaNac;
        this.txtJurisdiccion.Text = ocnAgente.Juris;
        this.txtAgeLugarPago.Text = ocnAgente.LugarPago;
        this.txtAgeEscuela.Text = ocnAgente.Escuela;
        this.txtAgePlanta.Text = ocnAgente.PlantaTipo;
        this.txtAgeNroControl.Text = ocnAgente.NroCOntrol;

        //SI ES DOCENTE
        if ((ocnAgente.Agru == "06") && (ocnAgente.tramo == "0"))
        {
            if ((ocnAgente.Apertura == "132") || (ocnAgente.Apertura == "133") || (ocnAgente.Apertura == "660") || (ocnAgente.Apertura == "661"))
            {
                this.txtAgeCargo.Text = ocnAgente.Cargo + " - " + ocnAgente.HsCat;
            }
            else
            {
                this.txtAgeCargo.Text = ocnAgente.Cargo;
            }
        }
        else
        {
            this.txtAgeCargo.Text = ocnAgente.Cargo;
        }
                
        if (ocnAgente.Anios != "")
        {
            if (ocnAgente.Anios == "*N")
            {
                txtAntiguedadReconocida.Text = ocnAgente.Anios + ocnAgente.Meses;
            }   
            else
            {
                this.txtAntiguedadReconocida.Text = ocnAgente.Anios + " Años" + " - " + ocnAgente.Meses + " Meses";
            }
        }
        else
        {
            txtAntiguedadReconocida.Text = ocnAgente.Anios;
        }
        String FechaDeIngreso = "";
        FechaDeIngreso = ocnAgente.FechaIngreso.Substring(0, 2) + "/" + ocnAgente.FechaIngreso.Substring(2, 2) + "/" + ocnAgente.FechaIngreso.Substring(4, 2);
        this.txtAgeFechaIngreso.Text = FechaDeIngreso;
        if (ocnAgente.AniosAntig == "*N")
        {
            txtAgeAntiguedad.Text = ocnAgente.AniosAntig;
        }
        else
        {
            this.txtAgeAntiguedad.Text = ocnAgente.AniosAntig + " años";
        }

        this.txtAgePeriodo.Text = ocnAgente.MesAnioLiq.Substring(0, 2) + " del " + "20" + ocnAgente.MesAnioLiq.Substring(3, 2);
        this.txtAgeDiasTrabajados.Text = ocnAgente.DiasTrabajados;
        this.txtAgeSituacionRevista.Text = ocnAgente.SituRev;     

        #region DESACTIVO TODOS LOS CAMPOS 
        //CAMPOS DIRECTOR
        this.txtAgeHaber.Visible = false;
        this.lblHaber.Visible = false;
        this.txtAgeSalarioFamiliar.Visible = false;
        this.lblSalarioFamiliar.Visible = false;
        this.txtAgeLiquido.Visible = false;
        this.lblLiquido.Visible = false;

        //CAMPOS D.G. PERSONAL
        this.txtAsistenciaPerfecta.Visible = false;
        this.lblAsistenciaPerfecta.Visible = false;
        this.txtRiesgoVida.Visible = false;
        this.lblRiesgoVida.Visible = false;
        this.txtJubRetActivo.Visible = false;
        this.lblJurRetActivo.Visible = false;
        this.txtDiasNoTrabajados.Visible = false;
        this.lblDiasNoTrabajados.Visible = false;

        //CAMPOS UERT
        this.txtAgeDescuentos.Visible = false;
        this.lblDescuentos.Visible = false;
        this.txtTotalSinCargo.Visible = false;
        this.lblTotalSinCargosAlHaber.Visible = false;
        this.txtRemuneracionOIT.Visible = false;
        this.lblRemuneracionOit.Visible = false;

        //CAMPOS PERSONAL EXTENDIDO        
        this.btnConceptos.Visible = false;
        #endregion 

        #region ACTIVO CAMPOS SEGUN PERFIL

        int perfil = Convert.ToInt32(Session["_esAdministrador"]);
        switch (perfil)
        {
            // Administrador
            case 1:
                btnConceptos.Visible = true;
                break;

            // Direccion General de Personal
            case 2:
                #region
                //this.txtAsistenciaPerfecta.Visible = true;
                //this.lblAsistenciaPerfecta.Visible = true;
                //this.txtRiesgoVida.Visible = true;
                //this.lblRiesgoVida.Visible = true;
                //this.txtJubRetActivo.Visible = true;
                //this.lblJurRetActivo.Visible = true;
                //if (Convert.ToInt32(ocnAgente.AsistenciaPerfecta) == 1)
                //    this.txtAsistenciaPerfecta.Text = "Si";
                //else
                //    this.txtAsistenciaPerfecta.Text = "No";

                //if (Convert.ToInt32(ocnAgente.RiesgoDeVida) == 1)
                //    this.txtRiesgoVida.Text = "Si";
                //else
                //    this.txtRiesgoVida.Text = "No";

                //if (Convert.ToInt32(ocnAgente.JubRetActivo) == 1)
                //    this.txtJubRetActivo.Text = "Si";
                //else
                //    this.txtJubRetActivo.Text = "No";
                #endregion
                habilitarCamposPersonal();
                break;

            // Uert
            case 3:
                this.txtAgeDescuentos.Visible = true;
                this.lblDescuentos.Visible = true;
                this.txtTotalSinCargo.Visible = true;
                this.lblTotalSinCargosAlHaber.Visible = true;
                this.txtRemuneracionOIT.Visible = true;
                this.lblRemuneracionOit.Visible = true;
                this.txtDiasNoTrabajados.Visible = true;
                this.lblDiasNoTrabajados.Visible = true;

                this.txtAgeDescuentos.Text = "$" + ocnAgente.TotalDescuentos;
                this.txtTotalSinCargo.Text = "$" + ocnAgente.TotalSinCargosAlHaber;
                this.txtRemuneracionOIT.Text = "$" + ocnAgente.RemuneracionOit;
                if (ocnAgente.DiasNoTrabajados != null)
                    this.txtDiasNoTrabajados.Text = ocnAgente.DiasNoTrabajados;
                else this.txtDiasNoTrabajados.Text = "0";
                break;

            // Director
            case 4:
                this.txtAgeHaber.Visible = true;
                this.lblHaber.Visible = true;
                this.txtAgeSalarioFamiliar.Visible = true;
                this.lblSalarioFamiliar.Visible = true;
                this.txtAgeLiquido.Visible = true;
                this.lblLiquido.Visible = true;
                this.txtDiasNoTrabajados.Visible = true;
                this.lblDiasNoTrabajados.Visible = true;
                this.txtAgeHaber.Text = "$" + ocnAgente.TotalHaberes;
                this.txtAgeSalarioFamiliar.Text = "$" + ocnAgente.HaberC_aporte;
                this.txtAgeLiquido.Text = "$" + ocnAgente.Liquido;
                this.txtDiasNoTrabajados.Text = ocnAgente.DiasNoTrabajados;
                break;

            // Personal extendido
            case 5:
                //CASO 2 MAS BOTON CONCEPTOS
                habilitarCamposPersonal();
                btnConceptos.Visible = true;
                btnListar.Visible = false;
                break;

            // Previsional
            case 6:
                btnConceptos.Visible = true;
                btnListar.Visible = false;
                habilitarCamposPersonal();                                
                break;
        }
        #endregion      
    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        try
        {
            String NomRep = "InformeAgentes.rpt";
            DateTime periodoDesde = Globales.periodoDesde;
            DateTime periodoHasta = Globales.periodoHasta;
            String nombre = "";
            String nrocontrol = "";
            String dni = "";

            //    FUNCIONA A VECES
            //    Session["Periodo1"] = Convert.ToDateTime(MenuRaizLista.SelectedValue);
            //    Session["Periodo2"] = Convert.ToDateTime(MenuRaizLista2.SelectedValue);
            //   int tipo = 0;
            //if (Globales.tipoOp == 1) // BUSQUEDA POR CUIL
            //{
            dni = Globales.cuilGlobal;
            dni = Globales.cuilGlobal.Substring(2, 8);
            FuncionesUtiles.AbreVentana("Reporte.aspx?nombre=" + nombre
                    + "&periodoDesde=" + periodoDesde + "&periodoHasta=" + periodoHasta
                    + "&nrocontrol=" + nrocontrol + "&dni=" + dni + "&NomRep=" + NomRep);
            //}
            //else
            //{
            //    if (Globales.tipoOp == 2) //BUSQUEDA POR NOMBRE
            //    {
            //        nombre = Globales.textBox;
            //        FuncionesUtiles.AbreVentana("Reporte.aspx?nombre=" + nombre
            //            + "&periodoDesde=" + periodoDesde + "&periodoHasta=" + periodoHasta
            //            + "&nrocontrol=" + nrocontrol + "&dni=" + dni + "&NomRep=" + NomRep);

            //    }
            //    else // BUSQUEDA POR NRO DE CONTROL
            //    {
            //        nrocontrol = Globales.textBox;
            //        FuncionesUtiles.AbreVentana("Reporte.aspx?nombre=" + nombre
            //            + "&periodoDesde=" + periodoDesde + "&periodoHasta=" + periodoHasta
            //            + "&nrocontrol=" + nrocontrol + "&dni=" + dni + "&NomRep=" + NomRep);
            //    }

            //}
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
        Se ha producido el siguiente error:<br/>
        MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
"</div>";
        }
    }

    protected void btnConceptos_Click(object sender, EventArgs e)
    {
        //FuncionesUtiles.AbreVentana("AgenteConceptos.aspx");
        try
        {
            //int id = Convert.ToInt32(Globales.dt.Rows[Globales.nroPagina]["Id"]);

            //GUARDAR VALORES ACTUALES DE AGENTE DETALLE PARA ACTUALIZAR EN EL LOAD AL VOLVER
            Session["CadenaAgenteDetalle"] = Request.QueryString["Id"];
            String Cadena = Request.QueryString["Id"];
            string[] parametros = Cadena.Split(',');
            // int ageId = Convert.ToInt32(parametros[0]);
            int ageId = Globales.idGlobal;
            if (Globales.nroPagina == -1)
            {
                if (Globales.dt.Rows.Count == 0)
                    Response.Redirect("AgenteConceptos.aspx?Id=" + ageId, false);
                else
                    //Response.Redirect("AgenteConceptos.aspx?Id=" + Convert.ToInt32(Globales.dt.Rows[Globales.nroPagina + 1]["Id"]), false);
                    Response.Redirect("AgenteConceptos.aspx?Id=" + ageId, false);
            }
            else
                //Response.Redirect("AgenteConceptos.aspx?Id=" + Convert.ToInt32(Globales.dt.Rows[Globales.nroPagina]["Id"]), false);
                Response.Redirect("AgenteConceptos.aspx?Id=" + ageId, false);
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
"</div>";
        }
    }

    private void habilitarCamposPersonal()
    {
        btnListar.Visible = false;
        this.txtAsistenciaPerfecta.Visible = true;
        this.lblAsistenciaPerfecta.Visible = true;
        this.txtRiesgoVida.Visible = true;
        this.lblRiesgoVida.Visible = true;
        this.txtJubRetActivo.Visible = true;
        this.lblJurRetActivo.Visible = true;
        if (Convert.ToInt32(ocnAgente.AsistenciaPerfecta) == 1)
            this.txtAsistenciaPerfecta.Text = "Si";
        else
            this.txtAsistenciaPerfecta.Text = "No";

        if (Convert.ToInt32(ocnAgente.RiesgoDeVida) == 1)
            this.txtRiesgoVida.Text = "Si";
        else
            this.txtRiesgoVida.Text = "No";

        if (Convert.ToInt32(ocnAgente.JubRetActivo) == 1)
            this.txtJubRetActivo.Text = "Si";
        else
            this.txtJubRetActivo.Text = "No";
    }

}
