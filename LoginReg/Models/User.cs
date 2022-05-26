using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginReg.Models{


    public class User
    {
        [Key]
        public int Id {get;set;}
        
        [Required (ErrorMessage="This is required! ")]
        [MinLength(2,ErrorMessage="Not the correct length! ")]
        [Display(Name="First Name:")]

        public string Firstname {get;set;}

        [Required (ErrorMessage="This is required! ")]
        [MinLength(2,ErrorMessage="Not the correct length! ")]
        [Display(Name="Last Name:")]

        public string Lastname {get;set;}

        [Required ]
        [EmailAddress]
        [Display(Name="Email:")]

        public string Email {get;set;}

        [Required ]
        [MinLength(8)]
        [DataType(DataType.Password)]

        public string Password {get;set;}
        [NotMapped]
        [Required ]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password:")]
       
        public string ConfirmPassword {get;set;}
    }
}