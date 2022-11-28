using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceProject.Models
{
    public class Donor_1
    {
        [Key]
        public int DonorID { get; set; }
        [Required]
        public string DonorName { get; set; }
        [Required]
        public double DonorAmount { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DonorDate { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public string FundraiserTitle { get; set; }
    }
}
