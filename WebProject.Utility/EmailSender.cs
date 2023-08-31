using Microsoft.AspNetCore.Identity.UI.Services;

namespace WebBookProject.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            //Logic to send email
            return Task.CompletedTask;
        }
    }
}