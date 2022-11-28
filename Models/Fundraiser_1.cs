using System.ComponentModel.DataAnnotations;

namespace CommerceProject.Models
{
    public class Fundraiser_1
    {
        [Key]
        public int FundraiserId { get; set; }
        [Required]
        public string FundraiserName { get; set; }
        public string FundraiserDescription { get; set; }
        [Required]
        public double FundraiserGoal { get; set; }
        public double FundraiserCurrentAmount { get; set; }
        
    }
}
