using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace StackOverflow.ViewModels
{
    public class QuestionViewModel
    {
        public int QuestionID { set; get; }
        public string QuestionName { get; set; }
        public DateTime QuestionDateTime { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }

        public int VotesCount { get; set; }
        public int AnswersCount { get; set; }

        public int ViewsCount { get; set; }
        public UserViewModel User { get; set; }
        public CategoryViewModel Category { get; set; }
        
        public virtual List<AnswerViewModel> Answers { get; set; }
    }
}
