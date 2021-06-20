using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace StackOverflow.DomainModels
{
   
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionID { get; set; }
        public string QuestionName{ get; set; }
        public DateTime QuestionDateTime { get; set; }

        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public int VotesCount { get; set; }
        public int AnswersCount { get; set; }
        public int ViewsCount { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        [ForeignKey("QuestionID")]
        public virtual List<Answer> Answers { get; set; }
    }
}
