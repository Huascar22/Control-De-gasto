using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Reflection.Metadata.Ecma335;

namespace Controlador
{
    public class Token
    {
        static string code;
        public static void EnviarCorreo(string destinatario){
            SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com");
            clienteSmtp.Port = 587;
            clienteSmtp.EnableSsl = true;
            clienteSmtp.UseDefaultCredentials = false;
            string correoGmail = "podcastdehoy@gmail.com";
            string contraseñaGmail = "sleofmlhjldtsyho";
            clienteSmtp.Credentials = new NetworkCredential(correoGmail, contraseñaGmail);

            string asunto = "Confirmacion de Correo";
            Guid guid = Guid.NewGuid();
            string codigo = guid.ToString().Substring(0,6);
            string envioMensaje = $"Su Codigo de validacion es {codigo}";
            MailMessage mensaje = new MailMessage(correoGmail, destinatario, asunto, envioMensaje);
            clienteSmtp.Send(mensaje);
            code = codigo;
        }

        public static void EnviarCorreoLimiteGasto(string destinatario)
        {
            SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com");
            clienteSmtp.Port = 587;
            clienteSmtp.EnableSsl = true;
            clienteSmtp.UseDefaultCredentials = false;
            string correoGmail = "podcastdehoy@gmail.com";
            string contraseñaGmail = "sleofmlhjldtsyho";
            clienteSmtp.Credentials = new NetworkCredential(correoGmail, contraseñaGmail);

            string asunto = "Confirmacion de Correo";
            string envioMensaje = "Limite Superado, ajuste su presupuesto al limite por favor...";
            MailMessage mensaje = new MailMessage(correoGmail, destinatario, asunto, envioMensaje);
            clienteSmtp.Send(mensaje);
;
        }
        public static string EnviarCodigo(){ 
            return code; 
        }
    }
}
