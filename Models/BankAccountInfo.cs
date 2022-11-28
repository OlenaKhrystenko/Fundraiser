using System.ComponentModel.DataAnnotations;

namespace CommerceProject.Models
{
    public class BankAccountInfo
    {
        [Key]
        public int BankAccountID { get; set; }
        [Required]
        public string BankName { get; set; }
        [Required]
        public string RoutingNumber { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string AccountType { get; set; }
        [Required]
        public string AccountHolderName { get; set; }

    }
}
