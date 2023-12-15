using Microsoft.AspNetCore.Identity.UI.Services;

namespace App_Dev_1670.Utility
{
    public class EmailSender : IEmailSender
    {
<<<<<<< Updated upstream
        public Task SendEmailAsync(string email,string subject, string htmlMessage)
=======
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
>>>>>>> Stashed changes
        {
            return Task.CompletedTask;
        }
    }
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
