
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Core.Providers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Mail;
    using System.IO;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using log4net;
    using Core.Schedules;

    public class MailProvider
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static MailMessage mail;
        private static SmtpClient client;

        private static Scheduler scheduler = new Scheduler();
        private static Exception exception;
        private static string Assunto;
        private static List<string> Para;
        private static List<string[]> UrlArquivos;
        private static string Corpo;

        private const string CONST_DATETIMEFORMATERROR = "dd/MM/yyyy hh:mm:ss.fff";
        private const string CONST_STRINGDATEFORMAT = "yyyyMMddhhmmssfff";
        private const string CONST_STRINGMAILIDFORMAT = "MAIL{0}";

        //-------------------------------------------------------------------------

        public static bool EnviarEmail(List<string> emailPara, string emailAssunto, string emailCorpo)
        {
            bool ret = false;
            try
            {
                Para = emailPara;
                Assunto = emailAssunto;
                Corpo = emailCorpo;
                Job job = new Job(string.Format(CONST_STRINGMAILIDFORMAT, DateTime.Now.ToString(CONST_STRINGDATEFORMAT)));
                job.Run.Once();
                scheduler.SubmitJob(job, Enviar);
                ret = true;
            }
            catch
            {
                ret = false;
            }

            return ret;
        }

        private static void Enviar(Job job)
        {
            try
            {
                client = new SmtpClient(Properties.Settings.Default.MAIL_HOST, Properties.Settings.Default.MAIL_PORT);
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(Properties.Settings.Default.MAIL_FROM, Properties.Settings.Default.MAIL_PASSWORD);
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                mail = new MailMessage();
                mail.Subject = Assunto;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.From = new MailAddress(Properties.Settings.Default.MAIL_FROM);

                foreach (string para in Para)
                    mail.To.Add(para);

                mail.IsBodyHtml = true;
                mail.Body = Corpo;

                client.Send(mail);
            }
            catch
            {
            }
        }

        public static bool EnviarEmailSimples(List<string> Para, string Assunto, string Corpo)
        {
            bool ret = false;
            try
            {
                client = new SmtpClient(Properties.Settings.Default.MAIL_HOST, Properties.Settings.Default.MAIL_PORT);
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(Properties.Settings.Default.MAIL_FROM, Properties.Settings.Default.MAIL_PASSWORD);
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                mail = new MailMessage();
                mail.Subject = Assunto;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.From = new MailAddress(Properties.Settings.Default.MAIL_FROM);

                foreach (string para in Para)
                    mail.To.Add(para);

                mail.IsBodyHtml = true;
                mail.Body = Corpo;
                client.Send(mail);
                
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        //-------------------------------------------------------------------------

        public static bool EnviarErros(Exception Ex)
        {
            bool ret = false;
            try
            {
                exception = Ex;
                Job job = new Job(string.Format(CONST_STRINGMAILIDFORMAT, DateTime.Now.ToString(CONST_STRINGDATEFORMAT)));
                job.Run.Once();
                scheduler.SubmitJob(job, SubmitErrorMail);
                ret = true;
            }
            catch
            {
                ret = false;
            }

            return ret;
        }

        private static void SubmitErrorMail(Job job)
        {
            try
            {
                client = new SmtpClient(Properties.Settings.Default.MAIL_HOST, Properties.Settings.Default.MAIL_PORT);
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential(Properties.Settings.Default.MAIL_FROM, Properties.Settings.Default.MAIL_PASSWORD);
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                mail = new MailMessage();
                mail.Subject = Properties.Settings.Default.ASSUNTO_DE_ERROS;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.From = new MailAddress(Properties.Settings.Default.MAIL_FROM);
                mail.To.Add(Properties.Settings.Default.MAIL_FROM);
                mail.IsBodyHtml = true;
                mail.Body = string.Format(Properties.Settings.Default.MAIL_PASSWORD, DateTime.Now.ToString(CONST_DATETIMEFORMATERROR), exception.Message, exception.StackTrace);

                client.Send(mail);
            }
            catch
            {
            }
        }

        //-------------------------------------------------------------------------

        public class CookieAwareWebClient : WebClient
        {
            public CookieAwareWebClient()
            {
                CookieContainer = new CookieContainer();
            }
            public CookieContainer CookieContainer { get; private set; }

            protected override WebRequest GetWebRequest(Uri address)
            {
                var request = (HttpWebRequest)base.GetWebRequest(address);
                request.CookieContainer = CookieContainer;
                return request;
            }
        }

        public class TimeoutWebClient : WebClient
        {
            public int Timeout { get; set; }

            public TimeoutWebClient()
            {
                Timeout = 60000;
            }

            public TimeoutWebClient(int timeout)
            {
                Timeout = timeout;
            }

            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest request = base.GetWebRequest(address);
                request.Timeout = Timeout;
                return request;
            }
        }

    }
}
