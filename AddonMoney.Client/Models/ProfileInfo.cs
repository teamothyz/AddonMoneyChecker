namespace AddonMoney.Client.Models
{
    public class ProfileInfo
    {
        public string ProfilePath { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Proxy { get; set; } = null!;

        public ProfileInfo(string line, string proxyPrefix)
        {
            try
            {
                var details = line.Split("|");
                ProfilePath = details[0].Trim();
                Email = details[1].Trim();
                Password = details[2].Trim();
                Proxy = proxyPrefix + details[3].Trim();
            }
            catch
            {
                throw new Exception("Data sai format");
            }
        }
    }
}
