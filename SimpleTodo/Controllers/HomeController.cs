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
            if(ModelState.IsValid)
            {
                using (var context = new Context())
                {
                    context.List.Add(model);
                    context.SaveChanges();
                    return RedirectToAction("Todos", "Home");
                }
            }
            return View();
        }

        

        [HttpGet]
        public ActionResult Todos()
        {
            using (var context = new Context())
            {
                var todoListViewModel = new TodoListViewModel
                    {
                        InProgress = context.List.SingleOrDefault(x => x.Status == TodoStatus.InProgress), 
                        NotStarted = context.List.AsNoTracking().Where(x => x.Status == TodoStatus.Todo).ToArray()
                    };
                
                return View(todoListViewModel);
            }
        }

        public class TodoListViewModel
        {
            public TodoItem[] NotStarted { get; set; }
            public TodoItem InProgress { get; set; }
        }
        
        
        [HttpPost]
        public ActionResult PromoteTodo(int SelectedTodo)
        {
            using (var context = new Context())
            {
                // this will return null if it doesn't exist
                var selected = context.List.Find(SelectedTodo);
                var doing = context.GetDoing();

                if (doing == selected)
                {
                    context.List.Remove(selected);
                }
                else if (doing == null)
                {
                    selected.Promote();
                    selected.Updated = DateTime.Now;
                }

                context.SaveChanges();    
            }
            
            return RedirectToAction("Todos", "Home");
        }
    }
}
