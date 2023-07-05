using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TravelFinalProject.ModelViews
{
    public class LoginViewModel
    {
        [Key]
        [MaxLength(100)]
        [Required(ErrorMessage = ("Please Enter Your Email"))]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email Format Wrong")]
        public string UserName { get; set; }

        [Display(Name = "Passwork")]
        [Required(ErrorMessage = "Please Enter A Password")]
        [MinLength(5, ErrorMessage = "You Need To Set A Password Of At Least 5 Characters")]
        public string Password { get; set; }
    }
}
