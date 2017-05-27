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
        BLL.BaseService<Category> bllCate;
        public HomeController( MyDbContext _context, BLL.BaseService<Category> _bllCate)
        {
            context = _context;
            bllCate = _bllCate;
        }
        public async Task< IActionResult> Index()
        {
            
            return View(await context.Category.Where(q=>q.Id>1).ToListAsync());
        }



        public IActionResult About()
        {
            bllCate.GetList(q=>q.Id>0);
            ViewData["Message"] = "Your application description page.";

            return View(bllCate.GetList(q => q.Id > 0));
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
