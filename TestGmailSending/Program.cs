using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace TestGmailSending
{
    class Program
    {
        static void Main(string[] args)
        {
            MailAddress from = new MailAddress("Eulutest@gmail.com", "Eulu-Interchange");
            MailAddress to = new MailAddress("Lev01b27@gmail.com");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Testing1";
            m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("Eulutest@gmail.com", "Strongpassword");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
