using System.ComponentModel.DataAnnotations;
using static TheHandymanOfCapeCod.Infrastructure.Constants.DataConstants;
using static TheHandymanOfCapeCod.Core.Constants.MessageConstants;

namespace TheHandymanOfCapeCod.Core.Models.Message
{

    public class IndexFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TownNameMaxLength,
            MinimumLength = TownNameMinLength,
            ErrorMessage = LengthMessage)]
        public string Town { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(EmailMaxLength,
            MinimumLength = EmailMinLength,
            ErrorMessage = LengthMessage)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [StringLength(PhoneNumberMaxLength,
            MinimumLength = PhoneNumberMinLength,
            ErrorMessage = LengthMessage)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MessageMaxLength,
            MinimumLength = MessageMinLength,
            ErrorMessage = LengthMessage)]
        public string Message { get; set; } = string.Empty;
    }
}
