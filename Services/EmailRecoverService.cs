using System;
using System.Linq;
using System.Threading.Tasks;
using Library.Helper;
using Library.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Splat;

namespace Library.Services;

public class EmailRecoverService : IEmailRecoverService
{
    private ApplicationContext db;
    private EmailConfig config;

    public EmailRecoverService()
    {
        // var configRoot = Locator.Current.GetService<IConfigurationRoot>();
        // var section = configRoot.GetSection("EmailSettings");
        // config = section.Get<EmailConfig>();
        config = Locator.Current.GetService<IConfigurationRoot>()
            ?.GetSection("EmailSettings")
            .Get<EmailConfig>()
        ?? throw new Exception("can't locate email config via locator");

        db = Locator.Current.GetService<ApplicationContext>() ??
             throw new Exception("can't locate ApplicationContext");
    }

    public async Task<bool> Recover(string email)
    {
        var password = "111";

        if (!await ResetPassword<Staff>(email, password) &&
            !await ResetPassword<Client>(email, password))
            return false;

        var message = new MimeMessage();
        message.From.Add( new MailboxAddress(config.Name, config.Email));
        message.To.Add(new MailboxAddress(email, email));
        message.Subject = "Password reset";

        message.Body = new TextPart("plain"){Text = $"New password: {password}"};

        using var client = new SmtpClient();
        await client.ConnectAsync(config.Host, config.Port);
        await client.AuthenticateAsync(config.Email, config.Password);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);

        return true;
    }

    private async Task<bool> ResetPassword<T>(string email, string password) 
        where T : class, IUser
    {
        var user = db.Set<T>().FirstOrDefault(e => e.Email == email);
        if (user != null)
            user.Password = password;
        else
            return false;
        await db.SaveChangesAsync();
        return true;
    }
}