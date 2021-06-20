using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflow.DomainModels;
namespace StackOverflow.Repositories
{
    public interface IQuestionsRepository
    {
        void InsertQuestion(Question u);
        void UpdateQuestionDetails(Question u);
        void UpdateQuestionVotesCount(int qid, int value);
        void UpdateQuestionAnswersCount(int qid, int value);
        void UpdateQuestionViewsCount(int qid, int value);
        void DeleteQuestion(int cid);
        Question GetQuestionByQuestionID(int cid);

        List<Question> GetQuestions();
    }
    public class QuestionsRepository : IQuestionsRepository
    {
        readonly StackOverflowDatabaseDbContext db;

        public QuestionsRepository()
        {
            db = new StackOverflowDatabaseDbContext();
        }



        public void DeleteQuestion(int cid)
        {
            Question qt = db.Questions.Where(temp => temp.QuestionID == cid).FirstOrDefault();
            if(qt != null)
            {
                db.Questions.Remove(qt);
                db.SaveChanges();
            }
        }

        public Question GetQuestionByQuestionID(int cid)
        {
            Question qt = db.Questions.Where(temp => temp.QuestionID == cid)
                .FirstOrDefault();
   
                return qt;
            
        }

        public void InsertQuestion(Question qt)
        {
            
                db.Questions.Add(qt);
                db.SaveChanges();
            
        }

        public void UpdateQuestionDetails(Question q)
        {
            Question qt = db.Questions.Where(temp => temp.QuestionID == q.QuestionID).FirstOrDefault();
            if (qt != null)
            {
                qt.QuestionName = q.QuestionName;
                qt.QuestionDateTime = q.QuestionDateTime;
                qt.CategoryID = q.CategoryID;
                db.SaveChanges();
            }
        }
        public List<Question> GetQuestions()
        {
            List<Question> qt = db.Questions.ToList();
            return qt;
        }
        public void UpdateQuestionVotesCount(int qid, int value)
        {
            Question qt = db.Questions.Where(temp => temp.QuestionID == qid).FirstOrDefault();
            if(qt!= null)
            {
                qt.VotesCount += value;
                db.SaveChanges();
            }
        }

        public void UpdateQuestionViewsCount(int qid, int value)
        {
            Question qt = db.Questions.Where(temp => temp.QuestionID == qid).FirstOrDefault();
            if (qt != null)
            {
                qt.VotesCount += value;
                db.SaveChanges();
            };
        }

        public void UpdateQuestionAnswersCount(int qid, int value)
        {
            Question qt = db.Questions.Where(temp => temp.QuestionID == qid).FirstOrDefault();
            if (qt != null)
            {
                qt.AnswersCount += value;
                db.SaveChanges();
            };
        }

    }
}
