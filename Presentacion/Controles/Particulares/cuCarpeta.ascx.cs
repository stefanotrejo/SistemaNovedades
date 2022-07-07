using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cuCarpeta : System.Web.UI.UserControl
{
    public string Nombre
    {
        get
        {
            return dcaNombre.Text.Trim();
        }
        set
        {
            dcaNombre.Text = value.Trim();
        }
    }

    public int Id
    {
        get
        {
            return Convert.ToInt32(lblId.Text.Trim());
        }
        set
        {
            lblId.Text = value.ToString();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnNuevoDocumento_Click(object sender, EventArgs e)
    {
        btnNuevoDocumento.Visible = false;
        btEliminarCarpeta.Visible = false;
        btnAceptar.Visible = true;
        btnCancelar.Visible = true;
    }

    protected void btEliminarCarpeta_Click(object sender, EventArgs e)
    {
        btnNuevoDocumento.Visible = false;
        btEliminarCarpeta.Visible = false;
        btnAceptar.Visible = true;
        btnCancelar.Visible = true;
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        btnNuevoDocumento.Visible = true;
        btEliminarCarpeta.Visible = true;
        btnAceptar.Visible = false;
        btnCancelar.Visible = false;
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        btnNuevoDocumento.Visible = true;
        btEliminarCarpeta.Visible = true;
        btnAceptar.Visible = false;
        btnCancelar.Visible = false;
    }
}