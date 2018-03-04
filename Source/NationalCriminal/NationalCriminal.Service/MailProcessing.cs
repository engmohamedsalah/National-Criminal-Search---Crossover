using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using NationalCriminal.Helper;
using System.Net;
using NationalCriminal.Repository;
using NationalCriminal.DAL;

namespace NationalCriminal.Service
{
    public class MailProcessing
    {

        /// <summary>
        /// Sends the mail.
        /// </summary>
        /// <param name="toEmail">To email.</param>
        /// <param name="attachments">The attachments.</param>
        /// <returns></returns>
        public static bool sendMail(string toEmail, List<Attachment> attachments)
        {
            try
            {
                //get Configuration System from Configuration table in database

                var config = new ConfigurationRepository().GetConfiguration();

                int numOfGroup = (int)(Math.Ceiling((decimal)attachments.Count / (decimal)Constant.MAX_NUMBER_OF_ATTACH_PER_EMAIL));
                int attachmentPointer = 0;

                //mail configuration
                MailMessage message = new MailMessage();
                string fromEmail = config.FromEmail;
                string fromPassword = config.FromPassword;
                message.From = new MailAddress(fromEmail);
                message.To.Add(toEmail);
                message.Subject = Constant.EMAIL_SUBJECT;
                message.Body = Constant.EMAIL_BODY_IF_FOUND_RECORDS;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                using (SmtpClient smtpClient = new SmtpClient(config.EmailHost, config.EmailPort))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(fromEmail, fromPassword);
                    //in case of no record send message to user that system not found record
                    if (numOfGroup == 0)
                    {
                        message.Body = Constant.EMAIL_BODY_IF_NOT_FOUND_RECORDS;
                        smtpClient.Send(message);
                    }
                    //records were found 
                    //prepare attahcment and send
                    else
                        while (numOfGroup > 0)
                        {

                            for (int i = 0; i < Constant.MAX_NUMBER_OF_ATTACH_PER_EMAIL; i++)
                            {
                                if (attachmentPointer >= attachments.Count)
                                    break;
                                message.Attachments.Add(attachments[attachmentPointer++]);
                            }
                            numOfGroup--;
                            smtpClient.Send(message);
                        }

                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
