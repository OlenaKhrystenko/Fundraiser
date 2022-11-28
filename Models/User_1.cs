using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceProject.Models
{
    public class User_1
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Dob { get; set; }
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string SequrityQuestion1 { get; set; }
        [Required]
        public string SequrityQuestion2 { get; set; }
        [Required]
        public string SequrityQuestion3 { get; set; }
        
    }
}
