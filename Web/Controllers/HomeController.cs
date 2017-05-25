using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext context;
        public IActionResult Index()
        {
            context.Article.AsNoTracking();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
