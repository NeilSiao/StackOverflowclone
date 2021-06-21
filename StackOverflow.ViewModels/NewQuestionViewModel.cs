using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace StackOverflow.ViewModels
{
   public class NewQuestionViewModel
    {
        [Required]
        public string QuestionName { set; get; }

        public DateTime QuestionDateTime { get; set; }
   
        public int UserID { get; set; }
        [Required]
        public int CategoryID { get; set; }

        public int VotesCount { get; set; }
  
        public int AnswersCount { get; set; }
   
        public int ViewsCount { get; set; }
    }
}
