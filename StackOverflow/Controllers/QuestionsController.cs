using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverflow.ServiceLayers;
using StackOverflow.ViewModels;
using StackOverflow.CustomFilters;

namespace StackOverflow.Controllers
{
    public class QuestionsController : Controller
    {
        IQuestionsService qs;
        ICategoriesService cs;
        IAnswersService ans;

        // GET: Questions
        public QuestionsController(IQuestionsService qs, ICategoriesService cs, IAnswersService ans)
        {
            this.qs = qs;
            this.cs = cs;
            this.ans = ans;
        }

        public ActionResult View(int id)
        {
            this.qs.UpdateQuestionViewsCount(id, 1);
            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            QuestionViewModel qvm = this.qs.GetQuestionByQuestionID(id, uid);
            return View(qvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilter]
        public ActionResult AddAnswer(NewAnswerViewModel navm)
        {
            navm.UserID = Convert.ToInt32(Session["CurrentUserID"]);
            navm.AnswerDateTime = DateTime.Now;
            navm.VotesCount = 0;
            if (ModelState.IsValid)
            {
                this.ans.InsertAnswer(navm);
                return RedirectToAction("View", "Questions", new { id = navm.QuestionID });
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                QuestionViewModel qvm = this.qs.GetQuestionByQuestionID(navm.QuestionID, navm.UserID);
                return View("View", qvm);
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [UserAuthorizationFilter]
        [ValidateInput(false)]
        public ActionResult EditAnswer(EditAnswerViewModel eavm)
        {
            if (ModelState.IsValid)
            {
                eavm.UserID = Convert.ToInt32(Session["CurrentUserID"]);
                this.ans.UpdateAnswerDetails(eavm);
                return RedirectToAction("View", new { id = eavm.QuestionID });
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return RedirectToAction("View", new { id = eavm.QuestionID });
            }
        }

        public ActionResult Create()
        {
            List<CategoryViewModel> categories = this.cs.GetCategories();
            ViewBag.categories = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilter]
        public ActionResult Create(NewQuestionViewModel qvm)
        {
            if (ModelState.IsValid)
            {
                qvm.AnswersCount = 0;
                qvm.ViewsCount = 0;
                qvm.VotesCount = 0;
                qvm.QuestionDateTime = DateTime.Now;
                qvm.UserID = Convert.ToInt32(Session["CurrentUserID"]);
                this.qs.InsertQuestion(qvm);
                return RedirectToAction("Questions", "Home");
            }
            else
            {
                List<CategoryViewModel> categories = this.cs.GetCategories();
                ViewBag.categories = categories;
                ModelState.AddModelError("x", "Invalid Data");
                return View();
            }
        }


    }
}