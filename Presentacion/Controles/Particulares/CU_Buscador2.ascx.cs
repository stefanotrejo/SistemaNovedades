using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controles_Particulares_CU_Buscador2 : System.Web.UI.UserControl
{
    System.Data.DataTable dt = new System.Data.DataTable();
    private LiquidacionSueldos.Datos.Gestor ocdGestor = new LiquidacionSueldos.Datos.Gestor();

    #region Propiedades
    public string SelectedValue
    {
        get
        {
            return lblSelectedValue.Text;
        }

        set
        {
            if (value.Trim().Length != 0)
            {
                lblSelectedValue.Text = value;

                /*CARGAR*/
                if (value.Trim().Length != 0)
                {
                    dt = new System.Data.DataTable();
                    dt = ocdGestor.EjecutarReaderSql(Sql.Replace("[cValor]", "[" + SelectedValue + "]"));
                    if (dt.Rows.Count != 0)
                    {
                        txt.Text = dt.Rows[0]["Resultado"].ToString();
                    }
                }
            }
            else
            {
                lblSelectedText.Text = "";
                lblSelectedValue.Text = "";
                txt.Text = "";
            }
        }
    }

    public string SelectedText
    {
        get
        {
            return lblSelectedText.Text;
        }

        set
        {
            lblSelectedText.Text = value;
        }
    }

    public string placeholder
    {
        get
        {
            return txt.Attributes["placeholder"].ToString();
        }

        set
        {
            txt.Attributes["placeholder"] = value;
        }
    }

    public Unit Width
    {
        get
        {
            return txt.Width;
        }

        set
        {
            txt.Width = value;
        }
    }

    public int MaxLength
    {
        get
        {
            return Convert.ToInt32(txt.Attributes["MaxLength"]);
        }

        set
        {
            txt.Attributes["MaxLength"] = value.ToString();
        }
    }

    public bool Enabled
    {
        get
        {
            return (txt.Attributes["Emabled"].ToString() == "false" ? false : true);
        }

        set
        {
            txt.Attributes["Enabled"] = (value ? "true" : "false");
        }
    }

    public string usuId
    {
        get
        {
            return lblusuId.Text.Trim();
        }

        set
        {
            lblusuId.Text = value;
        }
    }

    public string Text
    {
        get
        {
            return txt.Text.Trim();
        }

        set
        {
            lblSelectedText.Text = "";
            lblSelectedValue.Text = "";

            txt.Text = value;

            this.txt.BorderColor = System.Drawing.Color.LightGray;

            txt_TextChanged(null, null);
        }
    }

    public string Sql
    {
        get
        {
            return lblSql.Text.Trim();
        }

        set
        {
            this.lblSql.Text = value;
        }
    }

    public string MensajeNoEncontrado
    {
        get
        {
            return lblMensajeNoEncontrado.Text.Trim();
        }

        set
        {
            this.lblMensajeNoEncontrado.Text = value;
        }
    }
    #endregion

    #region Eventos
    public event EventHandler CU_Buscador2_TextChanged;
    protected virtual void CU_Buscador2_ontextchanged(object sender)
    {
        if (this.CU_Buscador2_TextChanged != null) this.CU_Buscador2_TextChanged(sender, new EventArgs());
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (usuId == "")
        {
            this.ace.ContextKey = this.lblSql.Text.Trim();
        }
        else
        {
            this.ace.ContextKey = this.lblSql.Text.Trim() + "|" + usuId;
        }
    }

    protected void txt_TextChanged(object sender, EventArgs e)
    {
        this.lblSelectedValue.Text = "0";

        string Cadena = this.txt.Text.Trim();
        int Largo = Cadena.Length;

        if (Largo != 0)
        {
            if (Cadena.IndexOf("[") != -1 && Cadena.IndexOf("]") != -1)
            {
                if (Cadena.Substring(Largo - 1, 1) == "]")
                {
                    string ValorId = Cadena.Substring(Cadena.IndexOf("["), Cadena.Length - Cadena.IndexOf("["));
                    this.lblSelectedValue.Text = ValorId.Replace("[", "").Replace("]", "");
                    this.txt.Text = this.txt.Text.Replace(ValorId, "").Trim();

                    this.txt.BorderColor = System.Drawing.Color.Green;
                }
                else
                {
                    if (lblMensajeNoEncontrado.Text.Trim().Length != 0)
                    {
                        txt.Text = lblMensajeNoEncontrado.Text.Trim();
                        this.txt.BorderColor = System.Drawing.Color.Red;
                    }
                }
            }
            else
            {
                if (lblMensajeNoEncontrado.Text.Trim().Length != 0)
                {
                    txt.Text = lblMensajeNoEncontrado.Text.Trim();
                    this.txt.BorderColor = System.Drawing.Color.Red;
                }
            }
        }

        CU_Buscador2_ontextchanged(sender);
    }

    public override void Focus()
    {
        this.txt.Focus();
    }
}