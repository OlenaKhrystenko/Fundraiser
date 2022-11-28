using MessagePack;
using Microsoft.Build.Framework;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace CommerceProject.Models
{
    public class Donor
    {
        [Key]
        public int DonorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double donatedAmount { get; set; }

        [Required]
        public string Fundraiser { get; set; }

        public DateTime DateOfDonation { get; set; }


    }
}
