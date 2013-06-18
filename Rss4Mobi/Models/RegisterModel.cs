using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resources;
using Rss4Mobi.NavigationRoutes;

namespace Rss4Mobi.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "UserNameRequired")]
        [LocalizedDisplayName("UserName")]
        [Remote("CheckNameExists", "Member",ErrorMessageResourceName = "NameExist",ErrorMessageResourceType = typeof(ErrorMessages))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress, ErrorMessage = "EmailError")]
        [Remote("CheckEmailExists", "Member" ,ErrorMessageResourceName = "EmailExist",ErrorMessageResourceType = typeof(ErrorMessages))]
        [LocalizedDisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "PasswordRequired")]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "PasswordLengthError")]
        [DataType(DataType.Password)]
        [LocalizedDisplayName("Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [LocalizedDisplayName("ConfirmPassword")]
        [Compare("Password", ErrorMessageResourceName = "ConfirmPasswordError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string ConfirmPassword { get; set; }
    }
}