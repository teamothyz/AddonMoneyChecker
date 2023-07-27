using Newtonsoft.Json.Linq;

namespace AddonMoney.Client.Models
{
    public class ProfileInfo
    {
        public static readonly List<ProfileInfo> Profiles = new();

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string RecoveryMail { get; set; } = null!;

        public string Proxy { get; set; } = null!;

        public string Cookies { get; set; } = null!;

        public string Raw { get; set; } = null!;

        public ProfileInfo(string line)
        {
            Raw = line;
            var details = line.Split("|");
            Email = details[0].Trim();
            Password = details[1].Trim();
            RecoveryMail = details[2].Trim();
            Proxy = details[3].Trim();
            Cookies = details[4];
        }
    }
}
