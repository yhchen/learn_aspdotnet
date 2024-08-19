// See https://aka.ms/new-console-template for more information

using ConfigService;
using LogServices;
using MailServices;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection serviceCollection = new();
serviceCollection.RegisterMailService();

var serviceProvider = serviceCollection.BuildServiceProvider();

var mailService = serviceProvider.GetRequiredService<IMailService>();

mailService.Send(" mail_title", "ethan chan", "mail context.............................");