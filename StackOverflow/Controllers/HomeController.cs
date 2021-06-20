using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverflow.ServiceLayers;
using StackOverflow.ViewModels;
namespace StackOverflow.Controllers
{
    public class HomeController : Controller
    {
        IQuestionsService qs;
        public HomeController(IQuestionsService qs)
        {
            this.qs = qs;
        }
        public ActionResult Index()
        {
            List<QuestionViewModel> questions = this.qs.GetQuestions()
                .Take(10).ToList();
            return View(questions);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}