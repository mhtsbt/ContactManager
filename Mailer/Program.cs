using MailKit.Net.Smtp;
using MimeKit;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Mailer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "mail",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);

                    var mailMessage = new MimeMessage();
                    mailMessage.From.Add(new MailboxAddress("Joey Tribbiani", "joey@friends.com"));
                    mailMessage.To.Add(new MailboxAddress("ContactPerson", "test@localhost.tml"));
                    mailMessage.Subject = "How you doin'?";

                    mailMessage.Body = new TextPart("plain")
                    {
                        Text = @"Hey,

I just wanted to let you know that Monica and I were going to go play some paintball, you in?

-- Joey"
                    };

                    using (var client = new SmtpClient())
                    {
                        // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                        client.Connect("localhost", 587, false);

                        // Note: since we don't have an OAuth2 token, disable
                        // the XOAUTH2 authentication mechanism.
                        client.AuthenticationMechanisms.Remove("XOAUTH2");

                        // Note: only needed if the SMTP server requires authentication
                        client.Authenticate("tmlsender@localhost.tml", "tmlsender");

                        client.Send(mailMessage);
                        client.Disconnect(true);
                    }


                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "mail",
                                     noAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}