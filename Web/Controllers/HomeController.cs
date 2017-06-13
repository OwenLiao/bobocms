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
 
         ICategoryService bllCate;
        public HomeController( MyDbContext _context, DAL.ICategoryService _bllCate) //, BLL.BaseService<Category> _bllCat
        {
            bllCate = _bllCate;
        }
        public   IActionResult Index()
        {
            
            return View( bllCate.GetList(q=>q.Id>0));
        }



        public IActionResult About()
        {
            bllCate.GetModel(q=>q.Id>0);
            ViewData["Message"] = "Your application description page.";

            return View(bllCate.GetModel(q => q.Id > 0));
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
