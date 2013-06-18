using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Rss4Mobi.NavigationRoutes;

namespace Rss4Mobi.Models
{
    public class LogOnModel
    {
        [Required(ErrorMessageResourceName = "UserNameRequired", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [LocalizedDisplayName("UserNameOrEmail")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [DataType(DataType.Password)]
        [LocalizedDisplayName("Password")]
        public string Password { get; set; }

        [LocalizedDisplayName("RememberMe")]
        public bool RememberMe { get; set; }

        [ScaffoldColumn(false)]
        public string ReturnUrl { get; set; }
    }

}