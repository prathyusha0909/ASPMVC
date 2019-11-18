using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Category Name is required.")]
        [StringLength(5, ErrorMessage = "User Name should be min 5letters.")]
        

        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Name is required.")]
        [DataType(DataType.Password)]
        [Display(Name ="Password:")]
        public string Password { get; set; }
        [Display(Name ="Keep me signied in")]
        public bool RememberMe { get; set; }
    }
}