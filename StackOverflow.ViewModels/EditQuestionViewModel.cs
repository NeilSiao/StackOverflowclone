using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace StackOverflow.ViewModels
{
   public class EditQuestionViewModel
    {
        public int QuestionID { get; set; }

        [Required]
        public string QuestionName { get; set; }

        [Required]
        public DateTime QuestionDateTime { get; set; }
        [Required]
        public int CategoryID { get; set; }
    }
}
