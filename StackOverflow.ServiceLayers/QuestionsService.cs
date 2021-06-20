using System;
using System.Collections.Generic;
using StackOverflow.DomainModels;
using StackOverflow.ViewModels;
using StackOverflow.Repositories;
using AutoMapper;
using AutoMapper.Configuration;
using System.Linq;
namespace StackOverflow.ServiceLayers
{
    public interface IQuestionsService
    {
        void InsertQuestion(NewQuestionViewModel cvm);
        void UpdateQuestionDetails(EditQuestionViewModel cvm);
        void DeleteQuestion(int qid);
        List<QuestionViewModel> GetQuestions();
        QuestionViewModel GetQuestionByQuestionID(int QuestionID, int UserID);

        void UpdateQuestionVotesCount(int qid, int value);
        void UpdateQuestionAnswersCount(int qid, int value);
        void UpdateQuestionViewsCount(int qid, int value);
    }

    public class QuestionsService:IQuestionsService
    {
        readonly IQuestionsRepository qr;

        public QuestionsService()
        {
            qr = new QuestionsRepository();
        }
        public void UpdateQuestionVotesCount(int qid, int value)
        {
            qr.UpdateQuestionVotesCount(qid, value);
        }

        public void UpdateQuestionViewsCount(int qid,int value)
        {
            qr.UpdateQuestionViewsCount(qid, value);
        }
        public void UpdateQuestionAnswersCount(int qid, int value)
        {
            qr.UpdateQuestionAnswersCount(qid, value);
        }
        public void InsertQuestion(NewQuestionViewModel qvm)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewQuestionViewModel, Question>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Question c = mapper.Map<Question>(qvm);
            qr.InsertQuestion(c);
        }
        public void UpdateQuestionDetails(EditQuestionViewModel qvm)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EditQuestionViewModel, Question>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Question c = mapper.Map<Question>(qvm);
            qr.UpdateQuestionDetails(c);
        }

        public void DeleteQuestion(int qid)
        {
            qr.DeleteQuestion(qid);
        }

        public List<QuestionViewModel> GetQuestions()
        {
            List<Question> q = qr.GetQuestions();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Question, QuestionViewModel>();
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<Answer, AnswerViewModel>();
                cfg.CreateMap<Vote, VoteViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<QuestionViewModel> qvm = mapper.Map<List<Question>, List<QuestionViewModel>>(q);
            return qvm;
        }
        public QuestionViewModel GetQuestionByQuestionID(int QuestionID, int UserID)
        {
            Question c = qr.GetQuestionByQuestionID(QuestionID);
            QuestionViewModel cvm = null;
            if(c!= null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Question, QuestionViewModel>();
                    cfg.CreateMap<User, UserViewModel>();
                    cfg.CreateMap<Category, CategoryViewModel>();
                    cfg.CreateMap<Answer, AnswerViewModel>();
                    cfg.CreateMap<Vote, VoteViewModel>();
                    cfg.IgnoreUnmapped();
                });
                IMapper mapper = config.CreateMapper();
                 cvm = mapper.Map<Question, QuestionViewModel>(c);
                foreach(var item in cvm.Answers)
                {
                    item.CurrentUserVoteType = 0;
                    VoteViewModel vote = item.Votes.Where(temp => temp.UserID == UserID)
                        .FirstOrDefault();
                        if(vote != null)
                    {
                        item.CurrentUserVoteType = vote.VoteValue;
                    }
                }
            }
         
            return cvm;
        }
    }
}
