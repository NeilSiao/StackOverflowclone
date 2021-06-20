using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace StackOverflow.DomainModels
{
   
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerID { get; set; }
        public DateTime AnswerDateTime { get; set; }
        public int VotesCount { set; get; }
        public int UserID { get; set; }
        public int QuestionID { get; set; }
        
        public string AnswerText { get; set; }

        [ForeignKey("QuestionID")]
        public virtual Question Question { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
       
        public virtual List<Vote> Votes { get; set; }
    }
}
