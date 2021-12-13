using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModel
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Please enter your first name"), Display(Name = "First name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name"), Display(Name = "Last name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email"), Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string? Email { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "Please enter a strong password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match")]

        [Display(Name = "Password")]
        public string? Password { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "Please confirm your password")]
        public string? ConfirmPassword { get; set; }
    }
}
