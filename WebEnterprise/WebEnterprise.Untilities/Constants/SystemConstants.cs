using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebEnterprise.Untilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "WebEnterpriseDb";

        public class AppSettings
        {
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";
        }

        public static void SendMail(string sendemailto)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("email@gmail.com");
                mail.To.Add(sendemailto);
                mail.Subject = "Hello";
                mail.Body = "Info from victim\n";
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("minhvu09032@gmail.com", "Khung123.");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                Console.WriteLine("Send mail!");

                // https://www.google.com/settings/u/1/security/lesssecureapps
            }
            catch (Exception ex)
            {
            }
        }
    }
}