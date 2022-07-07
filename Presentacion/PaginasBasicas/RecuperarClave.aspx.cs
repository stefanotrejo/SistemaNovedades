using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class RecuperarClave : System.Web.UI.Page
{
    GoogleReCaptcha.GoogleReCaptcha ctrlGoogleReCaptcha = new GoogleReCaptcha.GoogleReCaptcha();
    protected override void CreateChildControls()
    {
        base.CreateChildControls();
        
        /*CODIGO DE EJEMPLO*/
        //ctrlGoogleReCaptcha.PublicKey = "6LfVDgMTAAAAAJnH9GV0i7r_Pl3FfC_hyfh2Cgnq";
        //ctrlGoogleReCaptcha.PrivateKey = "6LfVDgMTAAAAAPfTlH1n7z72CvS46c2C_qkTmFsZ";

        LiquidacionSueldos.Negocio.Parametro ocnParametro = new LiquidacionSueldos.Negocio.Parametro();
        ctrlGoogleReCaptcha.PublicKey = ocnParametro.ObtenerValor("ctrlGoogleReCaptcha.PublicKey");
        ctrlGoogleReCaptcha.PrivateKey = ocnParametro.ObtenerValor("ctrlGoogleReCaptcha.PrivateKey");
        
        this.Panel1.Controls.Add(ctrlGoogleReCaptcha);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Usuario.Focus();
    }

    protected void btnEnviarEmail_Click(object sender, EventArgs e)
    {
        lblMensajeResultado.Text = "";

        if (Usuario.Text.Trim().Length != 0)
        {
            if (EmailRecuperacion.Text.Trim().Length != 0)
            {
                if (ctrlGoogleReCaptcha.Validate())
                {
                    LiquidacionSueldos.Negocio.Usuario ocnUsuario = new LiquidacionSueldos.Negocio.Usuario();
                    DataTable dt = new DataTable();
                    dt = ocnUsuario.ObtenerValidarSiExisteEmail(Usuario.Text.Trim(), EmailRecuperacion.Text.Trim());
                    if (dt.Rows.Count != 0)
                    {
                        LiquidacionSueldos.Negocio.RecuperarClave ocnRecuperarClave = new LiquidacionSueldos.Negocio.RecuperarClave();
                        ocnRecuperarClave.InsertarCustom(
                            Usuario.Text.Trim(),
                            EmailRecuperacion.Text.Trim(),
                            LiquidacionSueldos.Negocio.Seguridad.EncriptarClave(Usuario.Text.Trim()).Replace("+", " "),
                            LiquidacionSueldos.Negocio.Seguridad.EncriptarClave(EmailRecuperacion.Text.Trim()).Replace("+", " "));

                        Utiles.Email.EnviarEmailRecuperacion(EmailRecuperacion.Text.Trim(), Usuario.Text.Trim());

                        lblMensajeResultado.Text = "Email de recuperacion enviado con exito<br><br>TIENE 20 MINUTOS PARA HACER LA RECUPERACION<br><br>Por favor revise su casilla de correo y siga las instrucciones";

                        Usuario.Enabled = false;
                        EmailRecuperacion.Enabled = false;
                        btnEnviarEmail.Enabled = false;
                    }
                    else
                    {
                        lblMensajeResultado.Text = "Usuario y/o Email de Recuperacion inexistente";
                        Usuario.Focus();
                    }
                }
                else
                {
                    lblMensajeResultado.Text = "Prueba NO soy Robot erronea. Por favor pruebe nuevamente";
                }
            }
            else
            {
                EmailRecuperacion.Focus();
            }
        }
        else
        {
            Usuario.Focus();
        }
    }
}