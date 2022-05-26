using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models{
 
 public class LogUser
    {
        [Required]
        [EmailAddress]
        public string Email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
    }
}