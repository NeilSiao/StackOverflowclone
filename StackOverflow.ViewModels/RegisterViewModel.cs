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
        [Required(ErrorMessage ="Email 必填")]
        [RegularExpression(@"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z]+$", ErrorMessage = "Email 格式錯誤")]
        public string Email { get; set; }
        [Required]
        [Compare("Password")]
        public string Password { get; set; }
        //public String ConfirmPassword { get; set; }

        [Required(ErrorMessage="姓名必填")]
        public string Name { get; set; }
 
        [Required(ErrorMessage ="電話必填")]
        public string Mobile { get; set; }
        
    }
}
