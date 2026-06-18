using System.Net.Mail;
using GenericEmailService;
using GenericEmailService.Model;
using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Infrastructure.Services;

public sealed class MailService: IMailService
{
    public async Task SendMailAsync(List<string> emails, string body, string subject, List<Attachment> attachments)
    {
        EmailConfigurations configurations = new(            
            Smtp: "smtp.example.com",
            Password: "password",
            Port: 587,
            SSL: true,
            Html: true);
        
        EmailModel<Attachment> model = new(            
            Configurations: configurations,
            FromEmail: "mymail@gmail.com",
            ToEmails: ["sendmail1@gmail.com","sendmail2@gmail.com"],
            Subject: "Subjects",
            Body: "<b>Body</b>",
            Attachments: attachments);    
            
        await EmailService.SendEmailWithNetAsync(model);
    }
}
