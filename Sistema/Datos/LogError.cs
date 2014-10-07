using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Security;

namespace Datos
{
    public  static partial class Excepciones
    {
        public static bool boolLogError=true;

        public static string strLogFile = @"C:\SisElectro\ErrorLog.txt";

     
        public static string emailTo = @"liberatux@gmail.com";
       

      
       
        public static void LogExceptions(Exception ex)
        {
            if (boolLogError)
            {
                //HandlingException(ex);

                string msg = "";

                msg = "---------------------------" +
                    "\n" + DateTime.Now +
                    "\nOrigen: " + ex.Source +
                    "\n\nMensjae: " + ex.Message +
                    "\n\nTarget: " + ex.TargetSite +
                    "\nStack: " + ex.StackTrace +
                  
                    "\n" + "------------------------";


                    
                    
                WriteToLog(msg);
            }
           
        }
        private static void LogExceptions(SqlException ex)
        {
            if (boolLogError)
            {
                string msg = "";

                msg = "---------------------------" +
                    "\n" + DateTime.Now +
                    "\nNumero :"+ex.Number+ 
                    "\nLinea :"+ex.LineNumber+
                    "\nOrigen :" + ex.Source +
                    "\n\nMensaje: " + ex.Message +
                    "\n\nTarget: " + ex.TargetSite +
                    "\nStack: " + ex.StackTrace +
                    "\nLink: " + ex.HelpLink +
                    "\n" + "------------------------------"+"/n/n";
                WriteToLog(msg);
            }

        }

        //public static void LogExceptions(string message)
        //{
        //    if (boolLogError)
        //    {
        //        WriteToLog(message);
        //    }

        //}

        private static void WriteToLog(string msg)
        {
            if (File.Exists(strLogFile))
            {
                FileInfo fi = new FileInfo(strLogFile);
                var size = fi.Length;
                if (size > 50000)
                {
                    File.WriteAllText(strLogFile, String.Empty);
                }
            }
            
            StreamWriter writer = File.AppendText(strLogFile);
            writer.WriteLine(DateTime.Now.ToString() + " - " + msg);
            writer.Close();
        }



        public static void WriteToEmail(string correo,string clave,string msg)
        {
            string smtpAddress = "";
            int portNumber = 0;

            if (correo.Contains("gmail"))
            {
                smtpAddress = "smtp.gmail.com";
                portNumber = 587;
            }

            if (correo.Contains("hotmail") || correo.Contains("live"))
            {
                smtpAddress = "smtp.live.com";
                portNumber = 587;
            }

            if (correo.Contains("yahoo"))
            {
                smtpAddress = "smtp.mail.yahoo.com";
                portNumber = 587;
            }

            //using (MailMessage email = new MailMessage())
            //{


            //    email.To.Add(new MailAddress(emailTo));
            //    email.From = new MailAddress(correo);
            //    email.Subject = "*MSistema Log Ordeeno ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
            //    email.Body = "-----------------------------\n" + msg + "---------------------------------\n\n";

            //    email.IsBodyHtml = true;
            //    email.Priority = MailPriority.High;







            //    if (File.Exists(strLogFile))
            //        email.Attachments.Add(new Attachment(strLogFile));


            //    using (SmtpClient smtp = new SmtpClient(smtpAddress))
            //    {
            //        smtp.Credentials = new NetworkCredential(correo, clave);
            //        smtp.Port = portNumber;
            //        smtp.EnableSsl = true;
            //        smtp.UseDefaultCredentials = false;

            //        //smtp.UseDefaultCredentials = false;
            //        smtp.Send(email);
            //        //smtp.UseDefaultCredentials = false;



            //    }
            //}

          
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(correo);
                    mail.To.Add(emailTo);
                    mail.To.Add(new MailAddress(emailTo));

                    mail.Subject = "*MSistema Log Ordeeno ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                    mail.Body = "---------------------------- --------------\n" + msg + "\n---------------------------------\n\n";
                    if (File.Exists(strLogFile))
                        mail.Attachments.Add(new Attachment(strLogFile));

                    mail.IsBodyHtml = false;
                    mail.Priority = MailPriority.High;
                    using (SmtpClient SmtpServer = new SmtpClient(smtpAddress))
                    {

                    SmtpServer.Port = portNumber;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(correo, clave);
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }
            }
           
           
        }

        //private static void HandlingException(Exception ex)
        //{

        //    ExceptionPolicy.HandleException(ex, "Policy");
         
        
        //}
        public static SecureString ToSecureString(this string Source)
        {
            if (string.IsNullOrWhiteSpace(Source))
                return null;
            else
            {
                SecureString Result = new SecureString();
                foreach (char c in Source.ToCharArray())
                    Result.AppendChar(c);
                return Result;
            }
        }
    
    }

 
}
