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
            ViewBag.Message = "Welcome to ASP.NET MVC!";
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
            return View();
        }

        [HttpPost]
        public ActionResult Todos(TodoList model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Lists.Add(model);
                    _context.SaveChanges();
                } 
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                
            }

            return View();
        }
    }
}
