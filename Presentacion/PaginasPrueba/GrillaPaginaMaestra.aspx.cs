using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;


public partial class PaginasPrueba_GrillaPaginaMaestra : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.TituloDelFormulario = "Consulta - Pagos Eventuales";
      
        DateTime FechaSeleccionada = DateTime.Now;
        DataTable Dt = new DataTable();

        LiquidacionSueldos.Negocio.Agente ocnAgente = new LiquidacionSueldos.Negocio.Agente();
        Dt = ocnAgente.ObtenerAgentesxFechaDeCarga(FechaSeleccionada);

        this.Grilla.DataSource = Dt;
        this.Grilla.PageIndex = 0;
        this.Grilla.DataBind();

        this.Grilla1.DataSource = Dt;
        this.Grilla1.PageIndex = 0;
        this.Grilla1.DataBind();

        this.Grilla2.DataSource = Dt;
        this.Grilla2.PageIndex = 0;
        this.Grilla2.DataBind();
    }
}