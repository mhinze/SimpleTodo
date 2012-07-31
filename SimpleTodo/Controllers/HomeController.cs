using System;
using System.Linq;
using System.Web.Mvc;
using SimpleTodo.Models;

namespace SimpleTodo.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to SimpleTodo!";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        //
        // GET: /Todo/
        [HttpGet]
        public ActionResult CreateTodo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTodo(TodoItem model)
        {
            var context = new Context();
            if(ModelState.IsValid && (model.Content != null))
            {
                try
                {
                    context.List.Add(model);
                    context.SaveChanges();
                } 
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

            return RedirectToAction("Todos", "Home");
        }

        [HttpGet]
        public ActionResult Todos()
        {
            var context = new Context();
            return View(context);
        }

        [HttpPost]
        public ActionResult PromoteTodo(Context context)
        {
            var doing = context.GetDoing();
            var selected = context.GetSelected();
            if (doing == selected)
            {
                context.List.Remove(selected);
            }else if (doing == null)
            {
                selected.Promote();
                selected.Updated = DateTime.Now;
            }

            context.SaveChanges();
            return RedirectToAction("Todos", "Home");
        }
    }
}
