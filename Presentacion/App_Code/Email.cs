using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Utiles
{
    public class Email
    {
        static LiquidacionSueldos.Negocio.EmailSalida ocnEmailSalida = new LiquidacionSueldos.Negocio.EmailSalida();
        static LiquidacionSueldos.Negocio.Parametro ocnParametro = new LiquidacionSueldos.Negocio.Parametro();
        static DataTable dt = new DataTable();

        public static bool Enviar(int esrId)
        {
            bool Resultado = true;

            try
            {
                ocnEmailSalida = new LiquidacionSueldos.Negocio.EmailSalida(esrId);

                #region Datos de Cuenta y Servidor
                dt = new DataTable();
                dt = ocnEmailSalida.ObtenerParametros();
                string DeEmail = dt.Rows[0]["ServidorEmail_De"].ToString();
                string DeClave = dt.Rows[0]["ServidorEmail_Clave"].ToString();
                string DeServidor = dt.Rows[0]["ServidorEmail_Servidor"].ToString();
                #endregion

                MailMessage Msg = new MailMessage();

                Msg.From = new MailAddress(DeEmail, "IDES");
                Msg.To.Add(new MailAddress(ocnEmailSalida.esaPara));
                Msg.IsBodyHtml = true;
                Msg.Body = ocnEmailSalida.esaCuerpo;
                Msg.Subject = ocnEmailSalida.esaTitulo;
                Msg.Priority = MailPriority.High;

                SmtpClient c = new SmtpClient(DeServidor);
                c.Credentials = new System.Net.NetworkCredential(DeEmail, DeClave);
                c.Send(Msg);

                Resultado = true;
            }
            catch (Exception oError)
            {
                Resultado = false;
            }

            return Resultado;
        }

        public static bool EnviarEmailRecuperacion(string EmailRecuperacion, string Usuario)
        {
            bool Resultado = true;

            try
            {
                string DeEmail = ocnParametro.ObtenerValor("ServidorEmail_De");
                string DeClave = ocnParametro.ObtenerValor("ServidorEmail_Clave");
                string DeServidor = ocnParametro.ObtenerValor("ServidorEmail_Servidor");
                string Cliente_Nombre = ocnParametro.ObtenerValor("Cliente_Nombre");
                string UrlBlanquearClave = ocnParametro.ObtenerValor("UrlBlanquearClave");

                MailMessage Msg = new MailMessage();

                #region Cuerpo
                string Cuerpo = @"Estimado/a,<br><br>
Usted ha solicitado recuperar su clave.<br><br>
Por favor haga clic en el siguiente enlace para blanquear la misma:<br><br>
<a href=""" + UrlBlanquearClave + @"?EmailRecuperacion=" +
            LiquidacionSueldos.Negocio.Seguridad.EncriptarClave(EmailRecuperacion) + "&Usuario=" +
            LiquidacionSueldos.Negocio.Seguridad.EncriptarClave(Usuario) + @""" target=""_blank"">Blanquear clave</a><br><br>
Luego, ingrese al sistema con su usuario y nueva clave.<br><br>
Saludos,<br>
" + Cliente_Nombre;
                #endregion

                Msg.From = new MailAddress(DeEmail, Cliente_Nombre);
                Msg.To.Add(new MailAddress(EmailRecuperacion));
                Msg.IsBodyHtml = true;
                Msg.Body = Cuerpo;
                Msg.Subject = "Recuperacion de Clave";
                Msg.Priority = MailPriority.High;

                SmtpClient c = new SmtpClient(DeServidor);
                c.Credentials = new System.Net.NetworkCredential(DeEmail, DeClave);
                c.Send(Msg);

                Resultado = true;
            }
            catch (Exception oError)
            {
                Resultado = false;
            }

            return Resultado;
        }
    }
}