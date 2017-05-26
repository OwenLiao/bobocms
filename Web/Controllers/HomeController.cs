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
        public HomeController( MyDbContext _context)
        {
            context = _context;
        }
        public async Task< IActionResult> Index()
        {
            
            return View(await context.Category.Where(q=>q.Id>1).ToListAsync());
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
