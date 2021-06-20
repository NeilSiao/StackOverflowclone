using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
namespace StackOverflow.ViewModels
{
   public class EditUserPasswordViewModel
    {
           [Required]
           public int UserID { set; get; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


    }
}
