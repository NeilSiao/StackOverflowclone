using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace StackOverflow.ViewModels
{
    public class EditAnswerViewModel
    {
        [Required]
        public int AnswerID { get; set; }
        [Required]
        public string AnswerText { get; set; }
        [Required]
        public DateTime AnswerDateTime { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int QuestionID { get; set; }
        [Required]
        public int VotesCount{get;set;}

        public virtual QuestionViewModel Question { get; set; }
    }
}
