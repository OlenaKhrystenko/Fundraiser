using System.ComponentModel.DataAnnotations;
using static CommerceProject.Models.Donor;

namespace CommerceProject.Models
{
    public class Fundraiser
    {
        [Key]
        public int FundraiserID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public double Goal { get; set; }

        public double CurrentAmount { get; set; }

        public IEnumerable<Donor> donors { get; set; }

    }
}
