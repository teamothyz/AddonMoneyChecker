namespace CaptchaResolver
{
    public class KeyHandler
    {
        private static readonly object _lock = new();

        public static void SaveKey(string key)
        {
            lock (_lock)
            {
                try
                {
                    var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "captchakey");
                    if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                    var file = Path.Combine(folder, "_2captcha.dat");
                    using var writer = new StreamWriter(file, false);
                    writer.Write(key);
                    writer.Flush();
                    writer.Close();
                }
                catch { }
            }
        }

        public static string? GetKey()
        {
            lock (_lock)
            {
                try
                {
                    var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "captchakey");
                    var file = Path.Combine(folder, "_2captcha.dat");
                    
                    using var reader = new StreamReader(file, false);
                    var data = reader.ReadToEnd().Trim();
                    reader.Close();
                    return data;
                }
                catch 
                {
                    return null;
                }
            }
        }
    }
}
