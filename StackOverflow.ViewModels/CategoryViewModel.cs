using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
namespace StackOverflow.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        public int CategoryID { set; get; }
        [Required]
        public string CategoryName { get; set; }
    }
}
