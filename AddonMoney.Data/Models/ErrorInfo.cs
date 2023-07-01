using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddonMoney.Data.Models
{
    [Table("ErrorInfo")]
    [Index(nameof(Host), AllDescending = false)]
    public class ErrorInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public string Host { get; set; } = null!;

        public string Message { get; set; } = null!;

        public DateTime Time { get; set; }
    }
}
