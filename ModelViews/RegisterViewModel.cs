using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TravelFinalProject.ModelViews
{
    public class RegisterViewModel
    {
        [Key]
        public int CustomerId { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please Enter Full Name")]
        public string FullName { get; set; }

        [MaxLength(150)]
        [Required(ErrorMessage = "Please Enter Your Email")]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "ValidateEmail", controller: "Accounts")]
        public string Email { get; set; }

        [MaxLength(11)]
        [Required(ErrorMessage = "Please Enter Your Phone Number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Remote(action: "ValidatePhone", controller: "Accounts")]
        public string Phone { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Your Password")]
        [MinLength(5, ErrorMessage = "You Need To Set A Password Of At Least 5 Characters")]
        public string Password { get; set; }

        [MinLength(5, ErrorMessage = "You Need To Set A Password Of At Least 5 Characters")]
        [Display(Name = "Enter Your Password")]
        [Compare("Password", ErrorMessage = "Password Incorrect, Please Try Again")]
        public string ConfirmPassword { get; set; }
    }
}
