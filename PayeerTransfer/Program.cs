using ChromeDriverLibrary;
using PayeerTransfer.Services;

namespace PayeerTransfer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ChromeDriverInstance.KillAllChromes();
            ChromeServiceClient.StartSending(60, CancellationToken.None).Wait();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}