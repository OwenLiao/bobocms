using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Common;
using Microsoft.AspNetCore.Http;
using DAL;
using Model;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        IManagerService bllMan;
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Menu()
        {
            string user_name = HttpContext.Session.GetString(MyKeys.SESSION_ADMIN_INFO);
            //获取该管理员的菜单
            List<SysChannel> channels = bllMan.GetMenu(user_name);
            return PartialView(channels);
        }
    }
}   