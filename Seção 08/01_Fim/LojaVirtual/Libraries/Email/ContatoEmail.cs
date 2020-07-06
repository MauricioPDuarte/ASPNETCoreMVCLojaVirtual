using LojaVirtual.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {

        public static void EnviarContatoPorEmail(Contato contato) 
        {
            /*
             * SMTP -> Servidor que vai enviar a mensagem.
             */
            SmtpClient smtp = new SmtpClient("email-smtp.sa-east-1.amazonaws.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("AKIA2UCGJPEFBZPI54P2", "BC991mxnFeauuYBSh3OCh53TrsowAwGnx+ifynQJgOv7");
            smtp.EnableSsl = true;

            string corpoMsg = string.Format("<h2>Contato - Loja Virtual</h2> <br />" + 
                "<b>Nome: </b> {0} <br />" +
                "<b>Email: </b> {1} <br />" +
                "<b>Texto: </b> {2} <br />" +
                "<br /> E-mail enviado automaticamente do site LojaVirtual.",
                contato.Nome,
                contato.Email,
                contato.Texto
                );

            /*
             * MailMessage -> Construir a mensagem
             */

            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("mauricio@mpduarte.com");
            mensagem.To.Add("mauricio@mpduarte.com");
            mensagem.Subject = "Contato - LojaVirtual - E-mail: " + contato.Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            // Enviar mensagem via SMTP
            smtp.Send(mensagem);
        }
    }
}
