using ChromeDriverLibrary;
using PayeerTransfer.Services;

namespace PayeerTransfer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            PayeerService.Login("P1100737635", "Tuan552001", CancellationToken.None).Wait();
            ChromeDriverInstance.KillAllChromes();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}