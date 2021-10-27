
using System;
using System.IO;
using Core.Entities;
using Core.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace API.Mails
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _mailSettings;
        private readonly EmailToData _dataTo;
        public EmailService(IOptions<EmailSettings> options, IOptions<EmailToData> data)
        {
            _mailSettings = options.Value;
            _dataTo = data.Value;
        }

        public string EmailFromUsers(EmailUserData userData)
        {
            try
            {
                MimeMessage emailMessage = new MimeMessage();
                MailboxAddress emailFrom = new MailboxAddress(_mailSettings.Name, _mailSettings.EmailId);
                emailMessage.From.Add(emailFrom);

                MailboxAddress emailTo = new MailboxAddress(_dataTo.Name, _dataTo.EmailId);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = userData.Subject;

                string filePath = Directory.GetCurrentDirectory() + "\\Mails\\Templates\\EmailResponse.html";
                string emailTemplateText = File.ReadAllText(filePath);

                emailTemplateText = string.Format(emailTemplateText, userData.Name, userData.Phone, userData.Email, userData.Subject, userData.Body);

                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.HtmlBody = emailTemplateText;

                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                SmtpClient emailClient = new SmtpClient();
                emailClient.Connect(_mailSettings.Host, _mailSettings.Port, _mailSettings.UseSSl);
                emailClient.Authenticate(_mailSettings.EmailId, _mailSettings.Password);
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();

                return "Success";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string SendEmail(EmailData data)
        {
            try
            {
                MimeMessage emailMessage = new MimeMessage();
                MailboxAddress emailFrom = new MailboxAddress(_mailSettings.Name, _mailSettings.EmailId);
                emailMessage.From.Add(emailFrom);

                MailboxAddress emailTo = new MailboxAddress(data.EmailToName, data.EmailToId);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = data.EmailSubject;

                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.TextBody = data.EmailBody;

                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                SmtpClient emailClient = new SmtpClient();
                emailClient.Connect(_mailSettings.Host, _mailSettings.Port, _mailSettings.UseSSl);
                emailClient.Authenticate(_mailSettings.EmailId, _mailSettings.Password);
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();

                return "Success";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}