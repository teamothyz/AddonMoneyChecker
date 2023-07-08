using AddonMoney.Transfer.Models;
using AddonMoney.Transfer.Services;
using AddonMoney.Transfer.Windows;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
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

            ApplicationConfiguration.Initialize();
            var main = new FrmMain
            {
                TopMost = true
            };
            Application.Run(main);
        }
    }
}