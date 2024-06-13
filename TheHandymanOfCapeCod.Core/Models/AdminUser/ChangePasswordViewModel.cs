using System.ComponentModel.DataAnnotations;

namespace TheHandymanOfCapeCod.Core.Models.AdminUser
{
    public class ChangePasswordViewModel
    {
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your password.")]
        public string OldPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter ypur new password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm your new password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
