using Microsoft.AspNet.Identity;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System;
using System.Net.Mime;
using Wamasys.Models.Database;

namespace Wamasys
{
    public class EmailProvider : IIdentityMessageService
    {

        private const string NoReply = "No-reply@Goldhill.nl";
        private const string Name = "Goldhill Publishing";

        private static SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
        private static readonly NetworkCredential Credits = new NetworkCredential("wmsemailprovider", "GetRekt@123");


        public static async Task SendEmailConfirmation(ApplicationUser user, string url)
        {

            var msg = new MailMessage();
            msg.To.Add(new MailAddress(user.Email, user.FirstName + " " + user.LastName));
            msg.From = new MailAddress(NoReply, Name);
            msg.Subject = "[WMS Logistics] Bevestig je account";
            string html = "Beste " + user.FirstName + ", <br><br> Bedankt voor je registratie op het Bijlesportaal. Op <a href=\"" + url + "\">deze link</a> kan je je account bevestigen en gebruik maken van het Bijlesportaal. Nog een fijne dag! <br><br> Met vriendelijke groet, <br> Het Bijlesportaal-team";
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            smtpClient.Credentials = Credits;
            await smtpClient.SendMailAsync(msg);
        }

        public async Task SendAsync(IdentityMessage message)
        {
            var msg = new MailMessage();
            msg.To.Add(message.Destination);
            msg.Subject = message.Subject;
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message.Body, null, MediaTypeNames.Text.Html));
            msg.From = new MailAddress(NoReply);

            smtpClient.Credentials = Credits;
            await smtpClient.SendMailAsync(msg);
        }
    }
}