using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using TylerMart.Domain.Models;

namespace TylerMart.Client.Models {
	public class RegisterViewModel : IValidatableObject {
		[Required(ErrorMessage = "First name is required!")]
		[StringLength(30, MinimumLength = 2, ErrorMessage = "First name must be between two and thirty characters in length!")]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must use only letters!")]
		[DataType(DataType.Text)]
		[Display(Name = "First name")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "Last name is required!")]
		[StringLength(30, MinimumLength = 2, ErrorMessage = "Last name must be between two and thirty characters in length!")]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must use only letters!")]
		[DataType(DataType.Text)]
		[Display(Name = "Last name")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "Email is required!")]
		[StringLength(100, MinimumLength = 5, ErrorMessage = "Email must be between five and one-hundred characters in length!")]
		[EmailAddress(ErrorMessage = "Email must be in a proper format!")]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Password is required!")]
		[StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be between eight and fifty characters in length!")]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Please confirm your password!")]
		[StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be between eight and fifty characters in length!")]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		public string PasswordConfirmation { get; set; }
		[Required(ErrorMessage = "Address is required!")]
		[StringLength(100, MinimumLength = 5, ErrorMessage = "Address must be between five and one-hundred characters in length!")]
		[DataType(DataType.Text)]
		[Display(Name = "Address")]
		public string Address { get; set; }
		public Customer Create() {
			return new Customer() {
				FirstName = this.FirstName,
				LastName = this.LastName,
				Email = this.Email,
				Password = this.Password,
				Address = this.Address
			};
		}
		public IEnumerable<ValidationResult> Validate(ValidationContext context) {
			if (Password != PasswordConfirmation) {
				yield return new ValidationResult(
					"Password has been entered inconsistently!",
					new[] {
						nameof(PasswordConfirmation),
						nameof(Password),
						nameof(RegisterViewModel)
					}
				);
			}
		}
		public override string ToString() {
			string result = "Register = {";
			if (!string.IsNullOrEmpty(FirstName)) {
				result += $"\n\tFirstName = {FirstName}";
			}
			if (!string.IsNullOrEmpty(LastName)) {
				result += $"\n\tLastName = {LastName}";
			}
			if (!string.IsNullOrEmpty(Email)) {
				result += $"\n\tEmail = {Email}";
			}
			if (!string.IsNullOrEmpty(Password)) {
				result += $"\n\tPassword = {Password}";
			}
			if (!string.IsNullOrEmpty(PasswordConfirmation)) {
				result += $"\n\tPasswordConfirmation = {PasswordConfirmation}";
			}
			if (!string.IsNullOrEmpty(Address)) {
				result += $"\n\tAddress = {Address}";
			}
			result += "\n}";
			return result;
		}
	}
}
