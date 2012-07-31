using System;
using System.Reflection;
using System.Web.Mvc;
using SimpleTodo.Models;

namespace SimpleTodo.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context = new Context();

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
        public ActionResult Todos()
        {
            ViewBag.TodoList = _context.TodoList;
            return View();
        }

        [HttpPost]
        public ActionResult CreateTodo(TodoItem model)
        {
            if(ModelState.IsValid && (model.Content != null))
            {
                try
                {
                    _context.TodoList.Add(model);
                    _context.SaveChanges();
                } 
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

            return RedirectToAction("Todos", "Home");
        }

        [HttpPost]
        [ActionName("TodoAction")]
        [AcceptParameter(Name = "button", Value = "Promote")]
        public ActionResult PromoteTodo(FormCollection formData)
        {
            foreach (var key in formData.AllKeys)
            {
                try
                {
                    //Retrieve entities by their primary key values.
                    var todoItem = _context.TodoList.Find(Int32.Parse(key));
                    //Update their boolean values to checked or unchecked.
                    if(formData[key] == "true,false")
                    {
                        todoItem.Promote();
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.StackTrace);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Todos", "Home");
        }

        [HttpPost]
        [ActionName("TodoAction")]
        [AcceptParameter(Name = "button", Value = "Delete")]
        public ActionResult DeleteTodo(FormCollection formData)
        {
            foreach (var key in formData.AllKeys)
            {
                try
                {
                    //Retrieve entities by their primary key values.
                    var todoItem = _context.TodoList.Find(Int32.Parse(key));
                    //Update their boolean values to checked or unchecked.
                    if (formData[key] == "true,false")
                    {
                        _context.TodoList.Remove(todoItem);
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.StackTrace);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Todos", "Home");
        }
    }



    public class AcceptParameterAttribute : ActionMethodSelectorAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            var request = controllerContext.RequestContext.HttpContext.Request;
            return request.Form[this.Name] == this.Value;
        }
    }
}
