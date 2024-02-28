// See https://aka.ms/new-console-template for more information

using nsoftware.IPWorks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

var ipWorksConfiguration = configuration.GetSection("ipWorks");

Console.WriteLine("Hello, World!");
Filemailer fileMailer = new Filemailer();

fileMailer.MailServer = ipWorksConfiguration["MailServer"];
fileMailer.MailPort = Convert.ToInt32(ipWorksConfiguration["MailPort"]);
fileMailer.From = ipWorksConfiguration["From"];
fileMailer.SendTo = ipWorksConfiguration["SendTo"];
fileMailer.Subject = ipWorksConfiguration["Subject"];
fileMailer.MessageText = ipWorksConfiguration["MessageText"];
fileMailer.User= ipWorksConfiguration["User"];
fileMailer.Password= ipWorksConfiguration["Password"];
fileMailer.SSLEnabled = Convert.ToBoolean(ipWorksConfiguration["SSLEnabled"]);

fileMailer.RuntimeLicense = ipWorksConfiguration["RuntimeLicense"];

fileMailer.AddAttachment(ipWorksConfiguration["AttachmentPath"]);

// Send email
try
{
    fileMailer.Send();
    Console.WriteLine("Email sent successfully!");
}
catch (Exception ex)
{
    Console.WriteLine("Failed to send email. Error: " + ex.Message);
}
