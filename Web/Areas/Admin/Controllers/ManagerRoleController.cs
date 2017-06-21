using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Admin.Model;
using Common;
using Model;

namespace Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ManagerRoleController : Controller
    {
        #region define

        IManagerRoleService bll;

        ISysChannelService bllSysChannel;

        IManagerRoleValueService bllManagerRoleValue;

        public ManagerRoleController(IManagerRoleService _bll, ISysChannelService _bllSysChannel, IManagerRoleValueService _bllManagerRoleValue)
        {
            bll = _bll;
            bllSysChannel = _bllSysChannel;
            bllManagerRoleValue = _bllManagerRoleValue;
        }

        #endregion


        public ActionResult List()
        {
            return View();
        }
        public ActionResult Right()
        {
            return PartialView();
        }
        /// <summary>
        /// 权限列表
        /// </summary>
        /// <returns></returns>
        public ActionResult JsonRight(int? id)
        {

            var _data = bllSysChannel.GetList(q => q.Id > 0);
            List<EasyuiTreeModel> listM = new List<EasyuiTreeModel>();
            foreach (var item in _data.Where(q => q.parentId == 0))
            {
                EasyuiTreeModel m = new EasyuiTreeModel();
                m.id = item.Id;
                m.text = item.Title;
                m.state = "close";
                m.children = new List<EasyuiTreeModel>();
                foreach (var item1 in _data.Where(q => q.parentId == item.Id))
                {
                    EasyuiTreeModel m1 = new EasyuiTreeModel();
                    m1.id = item1.Id;
                    m1.text = item1.Title;
                    bool b = false;
                    if (id != null)
                    {
                        if (bll.Exists(Convert.ToInt32(id), item1.Id))
                        {
                            b = true;
                        }
                    }
                    m1.Checked = b;
                    m.children.Add(m1);
                }
                listM.Add(m);
            }
            return Content(JsonHelper.ObjectToJSON(listM).Replace("Checked", "checked"));
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.TitleMessage = id == null ? "添加角色" : "修改角色";
            return id == null ? View() : View(bll.GetModel(Convert.ToInt32(id)));
        }


        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult JsonList(int page,int rows)   //QueryModel model
        {
            int pageIndex = page;// int.Parse(Request["page"]);
            int pageSize = rows; //int.Parse(Request["rows"]);
            int _total;
            //  var _rows = bll.GetList(pageSize, pageIndex, model, "id", false, out _total);
            var _rows = bll.GetList(pageSize, pageIndex,q=>q.Id>0, "Id", false, out _total);
            var returnJson = new { total = _total, rows = _rows.ToList() };
            return Content(JsonHelper.ObjectToJSON(returnJson));

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ManagerRole model)
        {
            if (ModelState.IsValid)
            {
                if (bll.Exist(q => q.RoleName == model.RoleName)) ModelState.AddModelError("RoleName", "角色已存在");
                else
                {
                    model = bll.Add(model);
                    if (model.Id > 0)
                    {
                        foreach (var str in HttpContext.Items.Where(q=>q.Key.ToString()== "txtVals"))//权限//MyRequest.GetString("txtVals").Split(',')
                        {
                            ManagerRoleValue m = new ManagerRoleValue();
                            m.channelId = Convert.ToInt32(str);
                            m.roleId = model.Id;
                            bllManagerRoleValue.Add(m);
                        }
                        return View("AddSucess", new MessageModel(model.RoleName, "ManagerRole", "添加角色"));
                    }
                    else
                    { ModelState.AddModelError("", "添加角色失败！"); }
                }
            }
            return View("Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ManagerRole model)
        {
           // int _id = int.Parse(ControllerContext.RouteData.GetRequiredString("id"));
        //    var model = bll.GetModel(_id);
//TryUpdateModel(model, collection.AllKeys);

            if (ModelState.IsValid)
            {

                var oldRight = bllManagerRoleValue.GetList(q => q.roleId == model.Id);//之前有的权限
                //添加新增的权限
                string strVals = HttpContext.Items.Where(q => q.Key.ToString() == "txtVals").FirstOrDefault().ToString();
                foreach (var str in strVals.Split(','))
                {

                    ManagerRoleValue m = new ManagerRoleValue();
                    m.channelId = Convert.ToInt32(str);
                    m.roleId = model.Id;
                    if (oldRight.Where(q => q.roleId == m.roleId).Where(q => q.channelId == m.channelId).Count() <= 0)
                    {
                        bllManagerRoleValue.Add(m);
                    }
                }
                //删除去掉的权限
                foreach (var item in oldRight)
                {
                    string strAll = "," + strVals + ",";
                    if (!strAll.Contains("," + item.channelId.ToString() + ","))
                    {
                        bllManagerRoleValue.Delete(item.Id);
                    }
                }
                if (bll.Update(model))
                {
                    return View("EditSucess", new MessageModel(model.RoleName, "ManagerRole", "修改角色"));
                }
            }
            return View(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public JsonResult Delete(int id)
        {

            //删除
            if (bll.Delete(id))
            {

                return Json(true);
            }
            else return Json(false);
        }
    }
}