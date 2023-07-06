namespace AddonMoney.Transfer.Models
{
    public class DriverProfile
    {
        public string Profile { get; set; } = null!;

        public string UserDataDir { get; set; } = null!;

        public DriverProfile(string profilePath) 
        {
            Profile = Path.GetFileName(profilePath);
            UserDataDir = Path.GetDirectoryName(profilePath) ?? string.Empty;
        }
    }
}
