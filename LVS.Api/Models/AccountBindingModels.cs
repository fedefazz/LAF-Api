using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LVS.Api.Models
{
    // Models used as parameters to AccountController actions.

    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} caracteres como minimo.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} caracteres como minimo.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Los password no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class RemoveLoginBindingModel
    {
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} caracteres como minimo.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class UserRequestBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} caracteres como minimo.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Role")]
        public List<string> Roles { get; set; }

        [StringLength(100, ErrorMessage = "{0} must be a string with a maximum length of {1} characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessage = "{0} must be a string with a maximum length of {1} characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(100, ErrorMessage = "{0} must be a string with a maximum length of {1} characters.")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [StringLength(100, ErrorMessage = "{0} must be a string with a maximum length of {1} characters.")]
        [Display(Name = "State")]
        public string State { get; set; }

        [StringLength(100, ErrorMessage = "{0} must be a string with a maximum length of {1} characters.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(100, ErrorMessage = "{0} must be a string with a maximum length of {1} characters.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(100, ErrorMessage = "{0} must be a string with a maximum length of {1} characters.")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [StringLength(100, ErrorMessage = "{0} must be a string with a maximum length of {1} characters.")]
        [Display(Name = "Cellphone")]
        public string Cellphone { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Language")]
        public int LanguageId { get; set; }

        [Required]
        [Display(Name = "Time Zone")]
        public int TimeZoneId { get; set; }

        public Nullable<bool> PhoneNumberConfirmed { get; set; }

    }



    public class UserRequestConfirmationBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "{0} must be a string with a maximum length of {1} characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessage = "{0} must be a string with a maximum length of {1} characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(100, ErrorMessage = "{0} must be a string with a maximum length of {1} characters.")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [StringLength(100, ErrorMessage = "{0} must be a string with a maximum length of {1} characters.")]
        [Display(Name = "State")]
        public string State { get; set; }

        [StringLength(100, ErrorMessage = "{0} must be a string with a maximum length of {1} characters.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(100, ErrorMessage = "{0} must be a string with a maximum length of {1} characters.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(100, ErrorMessage = "{0} must be a string with a maximum length of {1} characters.")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [StringLength(100, ErrorMessage = "{0} must be a string with a maximum length of {1} characters.")]
        [Display(Name = "Cellphone")]
        public string Cellphone { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Language")]
        public int LanguageId { get; set; }

        [Required]
        [Display(Name = "Time Zone")]
        public int TimeZoneId { get; set; }

        [Required]
        [Display(Name = "Token")]
        public string Token { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} caracteres como minimo.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }





}
