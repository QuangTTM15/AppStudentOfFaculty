using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppStudentOfFaculty.Common
{
    public static class MailHelper
    {
        public async static Task SendGmailAsync(string to, string subject, string body)
        {
            try
            {
                string smtpAddress = "smtp.gmail.com";
                int portNumber = 587;
                bool enableSSL = true;
                string emailFrom = "studysendmail993@gmail.com";
                string password = "mmot nqxi emkm ikau";
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(to);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.UseDefaultCredentials = false;
                        await smtp.SendMailAsync(mail);
                    }
                }
            }
            catch (Exception ex) { }
        }
    }
}
