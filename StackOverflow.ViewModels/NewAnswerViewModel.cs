using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace StackOverflow.ViewModels
{
    public class NewAnswerViewModel
    {
        public string AnswerText { get; set; }

        [Required]
        public DateTime AnswerDateTime{ get; set; }

        [Required]
        public int UserID { get; set; }
        [Required]
        public int QuestionID { get; set; }
        [Required]
        public int VotesCount { get; set; }
    }
}
