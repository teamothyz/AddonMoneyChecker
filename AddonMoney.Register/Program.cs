using AddonMoney.Register.Windows;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace AddonMoney.Register
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(new ConfigurationBuilder()
                .AddJsonFile("register.setting.json").Build())

                .Enrich.FromLogContext()
                .CreateLogger();
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmMain
            {
                TopMost = true
            });
        }
    }
}