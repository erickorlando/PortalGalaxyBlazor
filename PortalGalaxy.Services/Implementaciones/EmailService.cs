using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Shared.Configuracion;

namespace PortalGalaxy.Services.Implementaciones;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;
    private readonly SmtpConfiguration _smtpConfiguration;

    public EmailService(ILogger<EmailService> logger, IOptions<AppSettings> options)
    {
        _logger = logger;
        _smtpConfiguration = options.Value.SmtpConfiguration;
    }
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        try
        {
            var mailMessage = new MailMessage(new MailAddress(_smtpConfiguration.UserName, _smtpConfiguration.FromName),
                new MailAddress(email));

            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;

            using var smtpClient = new SmtpClient(_smtpConfiguration.Server, _smtpConfiguration.Port);
            smtpClient.Credentials = new NetworkCredential(_smtpConfiguration.UserName, _smtpConfiguration.Password);
            smtpClient.EnableSsl = _smtpConfiguration.EnableSsl;

            await smtpClient.SendMailAsync(mailMessage);
        }
        catch (SmtpException ex)
        {
            _logger.LogWarning(ex, "No se puede enviar el correo a {email}", email);
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Error al enviar correo a {email} {message}", email, ex.Message);
        }
    }
}