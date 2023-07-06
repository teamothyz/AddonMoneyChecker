using AddonMoney.Transfer.Models;
using AddonMoney.Transfer.Services;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace AddonMoney.Transfer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var config = new ConfigurationBuilder().AddJsonFile("app.config.json").Build();
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .Enrich.FromLogContext()
                .CreateLogger();
            AppConfig.BotUsername = config["Bot"] ?? throw new Exception("Bot username not configured");

            var profile = new DriverProfile("C:\\Users\\Tuan\\AppData\\Local\\Google\\Chrome\\User Data\\Profile 21");
            Account.Accounts.Add(new Account
            {
                AccountId = 516771,
                ApiHash = "070d4246a0b59018b0f41fee8d0b1729",
                ApiId = 26440387,
                PayeerId = "P1024432949329543",
                Phone = "+84357090609",
                TeleSession = "0357090609.session"
            });

            TransferService.Transfer(profile, CancellationToken.None).Wait();
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
        }
    }
}