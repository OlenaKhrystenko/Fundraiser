using System.ComponentModel.DataAnnotations;
using MessagePack;
using Microsoft.Build.Framework;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace CommerceProject.Models
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Password { get; set; }
        public IEnumerable<Fundraiser> Fundraisers { get; set; }
        
    }
}
