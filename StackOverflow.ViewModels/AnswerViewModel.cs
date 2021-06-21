using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace StackOverflow.ViewModels
{
    public class AnswerViewModel
    {
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }

        public DateTime AnswerDateTime { get; set; }

        public int UserID { get; set; }
        public int QuestionID { get; set; }

        public int VotesCount { set; get; }
        public virtual UserViewModel User { get; set; }

        public virtual List<VoteViewModel> Votes {get;set;}
    
        public int CurrentUserVoteType { get; set; }
    }
}
