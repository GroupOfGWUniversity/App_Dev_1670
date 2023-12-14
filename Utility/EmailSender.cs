using Microsoft.AspNetCore.Identity.UI.Services;

namespace App_Dev_1670.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email,string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
