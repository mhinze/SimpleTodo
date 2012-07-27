using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            ViewData["TodoList"] = _context.TodoList;
            return View();
        }

        [HttpPost]
        public ActionResult Todos(TodoItem model)
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
    }
}
