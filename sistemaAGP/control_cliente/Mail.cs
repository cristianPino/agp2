//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Net.Mail;
//using System.Text;
//using System.Diagnostics;

//namespace Mail
//{
    

//    /// <summary>
//    /// clase que enumera la accion a realizar
//    /// </summary>
//    public enum Actions
//    {
//        New = 0,
//        Update = 1,
//        Delete = 2
//    }

//    /// <summary>
//    /// clase que arma un mensaje con el error y enviarlo a log de registro.
//    /// </summary>
//    /// <param name="sMessage"></param>
//    /// <param name="type"></param>
//    public class Events
//    {
//        public static void LogEvent(string sMessage, EventLogEntryType type)
//        {
//            StringBuilder pasos = new StringBuilder();
//            string sSource = "Control de Agenda AGP para Crediautos";
//            string sLog = "Control de Agenda AGP para Crediautos";

//            if (!EventLog.SourceExists(sSource))
//            {
//                EventLog.CreateEventSource(sSource, sLog);
//            }
//            EventLog.WriteEntry(sSource, sMessage, type, 100);
//        }
//    }

//    /// <summary>
//    /// Clase para el envio de mails en las distintas instancias.
//    /// </summary>
//    public class Mail
//    {
//        /// <summary>
//        /// Enviar mail de acción a cuenta de correo definida
//        /// </summary>
//        /// <param name="_to">para quien va el mail.</param>
//        /// <param name="_cc">a quien va en copia.</param>
//        /// <param name="_subject">titulo del mail.</param>
//        /// <param name="_body">cuerpo del mail.</param>
//        public  void SendMail(string _to, string _cc, string _subject, string _body)
//        {
//            try
//            {
//                var mail = new MailMessage("noreply@agpsa.cl", _to)
//                {
//                    Subject = _subject,
//                    Body = _body
//                };
//                MailAddressCollection _colCC = new MailAddressCollection();
//                string[] sepmail = { ";" };

//                string[] arrmail = _cc.Split(sepmail, StringSplitOptions.RemoveEmptyEntries);
//                if (arrmail.Length > 0)
//                {
//                    for (int i = 0; i < arrmail.Length; i++)
//                    {
//                        mail.CC.Add(new MailAddress(arrmail[i].ToString()));
//                    }
//                }

//                mail.IsBodyHtml = true;
                
//                SmtpClient smtpClient = new SmtpClient("mail.agpsa.cl");
//                smtpClient.Send(mail);
//            }
//            catch (Exception ex)
//            {
//                Events.LogEvent(ex.Message + " / Data: to=" + _to + ", body=" + _body, EventLogEntryType.Error);
//            }
//        }

//        /// <summary>
//        /// recibe el error en el envio del mensaje y lo devuelve como texto.
//        /// </summary>
//        /// <param name="_error"></param>
//        public  void SendMail(string _error)
//        {
//            try
//            {
//                //SmtpClient smtpClient = new SmtpClient(ConfigurationSettings.AppSettings["smtpServer"]);
//                SmtpClient smtpClient = new SmtpClient("mail.agpsa.cl");
//                var mail = new MailMessage("noreply@agpsa.cl", "pbecerra@agpsa.cl")
//                {
//                    Subject = "Detected: Error en proceso de alarma!",
//                    Body = _error
//                };

//                smtpClient.Send(mail);
//            }
//            catch (Exception ex)
//            {
//                Events.LogEvent(ex.Message, EventLogEntryType.Error);
//                Events.LogEvent("Error SendMail" + ex.Message + " - Error Generado: " + _error, EventLogEntryType.Error);

//            }
//        }

       
//        //<add key="smtpServer" value="mail.agpsa.cl"/>
//        //<add key="smtpFrom" value="noreply@agpsa.cl"/>
//        //<add key="smtpTo" value="pbecerra@agpsa.cl"/>
//        //<add key="smtpDomain" value="@agpsa.cl"/>
//        //<add key="MailPara" value="pbecerra@agpsa.cl"/>


//    }
//}