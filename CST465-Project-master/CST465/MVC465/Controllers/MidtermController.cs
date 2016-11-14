using MVC465;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace MVC465.Controllers
{
    public class MidtermController : Controller
    {

        // GET: Midterm
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TakeTest([FromBody]List<TestQuestion> answers)
        {
            List<TestQuestion> finalanswers;

            finalanswers = GetList();

            foreach (TestQuestion q in finalanswers)
            {
                q.Answer = answers[(q.ID - 1)].Answer;
            }
            if (ModelState.IsValid && answers != null) //If validation succeeds
            {
                TempData["TestData"] = finalanswers;
                return RedirectToAction("DisplayResults");
            }
            else
            {
                return View(finalanswers);
            }
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult TakeTest()
        {
            return View(GetList());
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult DisplayResults()
        {
            List<TestQuestion> results = null;
            results = (List<TestQuestion>)TempData["TestData"];
            return View(results);
        }

        public List<TestQuestion> GetList()
        {
            var path = "~/JSON/midterm.json";

            List<TestQuestion> questions = new List<TestQuestion>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var data = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(path));
            var str = data.ReadToEnd();


            List<jsonData> tests = null;
            tests = js.Deserialize<List<jsonData>>(str);


            foreach (jsonData temp in tests)
            {
                TestQuestion question = null;
                if (temp.Type == "TrueFalseQuestion")
                {
                    question = new TrueFalseQuestion();
                }
                else if (temp.Type == "ShortAnswerQuestion")
                {
                    question = new ShortAnswerQuestion();
                }
                else if (temp.Type == "LongAnswerQuestion")
                {
                    question = new LongAnswerQuestion();
                }
                else
                {
                    question = new MultipleChoiceQuestion();
                    ((MultipleChoiceQuestion)question).Choices = temp.Choices;
                }
                question.ID = temp.ID;
                question.Question = temp.Question;
                questions.Add(question);
            }

            data.Close();
            return (questions == null ? new List<TestQuestion>() : questions);
        }
    }
    public class jsonData
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Question { get; set; }
        public List<string> Choices { get; set; }
    }
}