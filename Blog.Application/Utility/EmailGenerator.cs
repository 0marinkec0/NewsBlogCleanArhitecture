using Blog.Application.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Utility
{
    public class EmailGenerator
    {
        public static EmailMessage GeneratePasswordResetMessage(string link, string userEmail)
        {
            EmailMessage message = new EmailMessage()
            {
                From = "noreply@Blog.com.hr",
                To = userEmail,
                Subject = "Blog.com.hr Promjena lozinke",
                Body = $"<h4>Kliknite na <a href=\"{link}\">link</a> za promjenu lozinke</h4>"
            };

            return message;
        }
    }
}
