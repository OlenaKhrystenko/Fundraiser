using System.ComponentModel.DataAnnotations;

namespace CommerceProject.Models
{
    public class CardInfo
    {
        [Key]
        public int CardId { get; set; }
        [Required]
        public string CardHolderName { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string ExpirationDate { get; set; }
        [Required]
        public int CVV { get; set; }

    }
}
