using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflow.DomainModels;
namespace StackOverflow.Repositories
{
    public interface IAnswersRepository
    {
        void InsertAnswer(Answer a);
        void UpdateAnswer(Answer a);
        void UpdateAnswerVotesCount(int aid, int uid, int value);
        void DeleteAnswer(int aid);
        List<Answer> GetAnswersByAnswerID(int AnswerID);
        
        List<Answer> GetAnswersByQuestionID(int qid);
    }
    public class AnswersRepository : IAnswersRepository
    {
        readonly StackOverflowDatabaseDbContext db;
        readonly IQuestionsRepository qr;
        readonly IVotesRepository vr;

        public AnswersRepository()
        {
            db = new StackOverflowDatabaseDbContext();
            qr = new QuestionsRepository();
            vr = new VotesRepository();
        }



        public void DeleteAnswer(int aid)
        {
            Answer a = db.Answers.Where(temp => temp.AnswerID == aid).FirstOrDefault();
            if(a != null)
            {
                db.Answers.Remove(a);
                db.SaveChanges();
                qr.UpdateQuestionAnswersCount(a.QuestionID, -1);
            }
        }

        public List<Answer> GetAnswersByAnswerID(int aid)
        {
            List<Answer> a = db.Answers.Where(temp => temp.AnswerID == aid)
                .ToList();
   
                return a;
            
        }
        public List<Answer> GetAnswersByQuestionID(int qid)
        {
            List<Answer> a = db.Answers.Where(temp => temp.QuestionID == qid)
                .ToList();

            return a;

        }
        public void InsertAnswer(Answer a)
        {
            
                db.Answers.Add(a);
                db.SaveChanges();
            qr.UpdateQuestionAnswersCount(a.QuestionID, 1);
        }

        public void UpdateAnswer(Answer a)
        {
            Answer aw = db.Answers.Where(temp => temp.AnswerID == a.AnswerID).FirstOrDefault();
            if (aw != null)
            {
                aw.AnswerText = a.AnswerText;
                db.SaveChanges();
            }
        }
        public List<Answer> GetAnswers(int qid)
        {
            List<Answer> aw = db.Answers.Where(temp => temp.QuestionID == qid)
                .OrderByDescending(temp=>temp.AnswerDateTime)
                .ToList();
            return aw;
        }
        public void UpdateAnswerVotesCount(int aid, int uid, int value)
        {
            Answer a = db.Answers.Where(temp => temp.AnswerID == aid).FirstOrDefault();
            if(a!= null)
            {
                a.VotesCount += value;
                db.SaveChanges();
                qr.UpdateQuestionVotesCount(a.QuestionID, value);
                vr.UpdateVote(aid, uid, value);
            }
        }

        public void UpdateAnswerViewsCount(int qid, int value)
        {
            Answer qt = db.Answers.Where(temp => temp.AnswerID == qid).FirstOrDefault();
            if (qt != null)
            {
                qt.VotesCount += value;
                db.SaveChanges();
            };
        }

   

    }
}
