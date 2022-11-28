using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceProject.Models
{
    public class FundraiserModel
    {
        [Key]
        public int FundraiserId { get; set; }
        [Required]
        public string FundraiserName { get; set; }
        public string FundraiserDescription { get; set; }
        [Required]
        public double FundraiserGoal { get; set; }
        public double FundraiserCurrentAmount { get; set; }

        [Display(Name = "DonorModel")]
        public virtual int DonorID { get; set; }
        [ForeignKey("DonorID")]
        public virtual DonorModel Donors { get; set; }
    }
}
