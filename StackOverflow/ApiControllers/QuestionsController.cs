using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using StackOverflow.ServiceLayers;

namespace StackOverflow.ApiControllers
{
    public class QuestionsController : ApiController
    {

        IAnswersService ans;
        // TODO:: DI is not working in api controller.
        public QuestionsController()
        {
            this.ans = new AnswersService();
        }

        public void Post(int AnswerID, int UserID, int Value)
        {
            this.ans.UpdateAnswerVotesCount(AnswerID, UserID, Value);

        }


    }
}