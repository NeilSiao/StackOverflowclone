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
    public interface IAnswersService
    {
        void InsertAnswer(NewAnswerViewModel avm);
        void UpdateAnswerDetails(EditAnswerViewModel avm);
        void UpdateAnswerVotesCount(int aid, int uid, int value);
        void DeleteAnswer(int aid);
        List<AnswerViewModel> GetAnswersByQuestionID(int qid);

        AnswerViewModel GetAnswerByAnswerID(int AnswerID);
    }

   public  class AnswersService: IAnswersService

    {
        readonly IAnswersRepository answerRepo;

        public AnswersService()
        {
            answerRepo = new AnswersRepository();
        }

        public AnswerViewModel GetAnswerByAnswerID(int aid)
        {
            Answer a = answerRepo.GetAnswersByAnswerID(aid)
                .FirstOrDefault();
            AnswerViewModel avm = null;
            if(a != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Answer, AnswerViewModel >();
                    cfg.IgnoreUnmapped();
                });
                IMapper mapper = config.CreateMapper();
                avm = mapper.Map<Answer, AnswerViewModel>(a);
            }
       
            return avm;
        }
        public void InsertAnswer(NewAnswerViewModel avm)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NewAnswerViewModel, Answer>(); cfg.IgnoreUnmapped();
                });
            IMapper mapper = config.CreateMapper();
            Answer a = mapper.Map<NewAnswerViewModel, Answer>(avm);
            answerRepo.InsertAnswer(a);
        }

        public void DeleteAnswer(int aid)
        {
            answerRepo.DeleteAnswer(aid);
        }

        public void UpdateAnswerDetails(EditAnswerViewModel avm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditAnswerViewModel, Answer>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Answer a = mapper.Map<EditAnswerViewModel, Answer>(avm);
           
            answerRepo.UpdateAnswer(a);
        }
    
        public void UpdateAnswerVotesCount(int aid, int uid, int value)
        {
            answerRepo.UpdateAnswerVotesCount(aid, uid, value);
            
        }

     

        public List<AnswerViewModel> GetAnswersByQuestionID(int qid)
        {
            List<Answer> ans = answerRepo.GetAnswersByQuestionID(qid);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Answer, AnswerViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<AnswerViewModel> uvm = mapper.Map<List<Answer> ,List<AnswerViewModel>>(ans);
            return uvm;
        }
   
    }
}
