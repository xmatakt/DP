using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using ExceptionHandler;

namespace Mailer
{
    public class SimpleMailer
    {
        /// <summary>
        /// Function to sending emails to provided recipients.
        /// </summary>
        /// <param name="emails">Addresses of email recipients</param>
        /// <returns>VAlue indicating whether the messages were send successfully</returns>
        public bool SendEmail(string emails)
        {
            bool result = true;
            try
            {
                MailMessage mail = new MailMessage();

                SmtpClient SmtpServer = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential("motii131@gmail.com", "5vcj1hqb1x"),
                };
                //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("motii131@gmail.com");
                mail.To.Add(emails);
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                //SmtpServer.Port = 587;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("motii131", "5vcj1hqb1x");
                //SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.LogException(ex);
                result = false;
            }

            return result;
        }
    }
}
