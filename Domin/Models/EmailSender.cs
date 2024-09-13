using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace Hotel.Domin.Models
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            Console.WriteLine($"Sending email to {email}: Subject: {subject}, Message: {htmlMessage}");
            return Task.CompletedTask;
        }
    }
}
