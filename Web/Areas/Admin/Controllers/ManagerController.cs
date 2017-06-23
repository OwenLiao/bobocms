using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Admin.Model;
using Common;
using Microsoft.AspNetCore.Http;
using DAL;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManagerController : Controller
    {
        IManagerService bll;
        public ManagerController(IManagerService _bll)
        {
            bll = _bll;
        }
        public IActionResult Index()
        {
            return View();
        }


        #region ����Ա��¼

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel managerVM)
        {
            if (ModelState.IsValid)
            {
                var m = bll.GetModel(managerVM.user_name);
                if (m == null) ModelState.AddModelError("user_name", "�˺Ų�����");
                else if (DESEncrypt.Md5(managerVM.user_pwd) != m.UserPwd) ModelState.AddModelError("user_pwd", "���벻��ȷ");
                else
                {
                  HttpContext.Session.SetString(MyKeys.SESSION_ADMIN_INFO, managerVM.user_name);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(managerVM);
        }
        #endregion
    }
}