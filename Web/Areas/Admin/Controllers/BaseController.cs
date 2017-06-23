using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Common;
using Microsoft.AspNetCore.Http;


namespace Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           string username=  HttpContext.Session.GetString(MyKeys.SESSION_ADMIN_INFO);
            if (string.IsNullOrEmpty(username))
            {

                context.Result = RedirectToAction("Login","Manager");// new RedirectResult("/Login/Index",);
                return;
               // RedirectToAction("Login", "Home");
            }

            base.OnActionExecuting(context);

        }
    }
}