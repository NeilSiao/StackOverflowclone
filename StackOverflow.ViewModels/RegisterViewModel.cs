using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StackOverflow.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [RegularExpression(@"^\\w{1,63}@[a-zA-Z0-9]{2,63}\\.[a-zA-Z]{2,63}(\\.[a-zA-Z]{2,63})?$")]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public String ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-z]*$")]
        public string Name { get; set; }
 
        [Required]
        public string Mobile { get; set; }
        
    }
}
