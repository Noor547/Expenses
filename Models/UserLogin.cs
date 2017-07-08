using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExpMngr.Models
{
    public class UserLogin
    {
        [Display(Name = "Id")]
        public int id { get; set; }
        [Required(ErrorMessage = "ProfileName is required field")]
        public string ProfileName { get; set; }
        [Required(ErrorMessage = "UserName is required field")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required field")]
        public string Password { get; set; }
        public bool isAdmin { get; set; }
        public bool isFirstLogin { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}