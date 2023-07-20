using System.ComponentModel.DataAnnotations;

namespace AddonMoney.Data.API
{
    public class UpdateProxyStatusRequest
    {
        [Required]
        public bool ProxyDie { get; set; }

        [Required]
        public string Email { get; set; } = null!;
    }
}
