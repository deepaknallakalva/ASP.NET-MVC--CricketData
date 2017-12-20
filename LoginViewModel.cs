using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CricketData.Models.Entities;
namespace CricketData.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(@".+\@.+\..+",
            ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [RegularExpression(@"([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers of Last Name")]
        public string Password { get; set; }
    }
}