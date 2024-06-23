using System.Text.Encodings.Web;
using UniversitySystem.Services;

namespace UniversitySystem.Extensions;

public static class EmailSenderExtensions
{
    public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link) =>
        emailSender.SendEmailAsync(email, "Confirm your email at University",
            $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>" +
            $"You'll be able to login once administration registers you based on document you've provided to the University.");
}