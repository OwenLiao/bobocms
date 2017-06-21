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
        public HomeController( DAL.ICategoryService _bllCate) //, BLL.BaseService<Category> _bllCat
        {
            bllCate = _bllCate;
        }
        public   IActionResult Index()
        {
            int _total = 0;
            var list = bllCate.GetList(20, 1, q => q.Id >= 0, "Id", false, out _total).ToList();
            ViewBag.total = _total;
            return View( list); 
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
