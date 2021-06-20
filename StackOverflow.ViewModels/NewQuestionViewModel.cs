using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace StackOverflow.ViewModels
{
   public class NewQuestionViewModel
    {
        [Required]
        public int QuestionName { set; get; }
        [Required]
        public string QuestionDateTime { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public int VotesCount { get; set; }
        [Required]
        public int AnswersCount { get; set; }
        [Required]
        public int ViewsCount { get; set; }
    }
}
