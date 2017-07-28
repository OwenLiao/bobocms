
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using DAL;
using Microsoft.EntityFrameworkCore;


namespace Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        MyDbContext context;
        public CategoryController(MyDbContext _context)
        {
            context = _context;
        }

        public ActionResult Edit(int? id)
        {

            string callindex = Request.Query["callindex"];
            ViewBag.CategoryType = new SelectList(bllType.GetList(q => true), "id", "title");
            if (id == null)
            {
                ViewBag.TitleMessage = "添加分类";
                ViewBag.ParentCategory = new SelectList(bll.GetList(q => (q.parentId == 0 || q.parentId == null)), "id", "title");
                return View();
            }
            else
            {
                ViewBag.TitleMessage = "修改分类";
                var model = context.Category.SingleAsync(q => q.Id == id);
                //string defaltVal = model.parent_id.ToString();
                //ViewBag.ParentCategory = new SelectList(bll.GetList(q => q.call_index == "video"), "id", "title", defaltVal);
                ViewBag.ParentCategory = new SelectList(bll.GetList(q => q.parentId == 0), "id", "title");
                return id == null ? View() : View(model);
            }

        }



        //public ActionResult JsonList(QueryModel model)
        //{
        //    string callindex = MyRequest.GetQueryString("callindex");
        //    int pageIndex = int.Parse(Request["page"]);
        //    int pageSize = int.Parse(Request["rows"]);
        //    int _total;
        //    var _rows = bll.GetList(pageSize, pageIndex, q =>q.Id> 0, "SortId", true, out _total);
        //    var returnJson = new { total = _total, rows = _rows.ToList() };
        //    return Content(JsonHelper.ObjectToJSON(returnJson));

        //    // return Json(new { total = _total, rows = _rows.ToList() });
        //}

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {
                //  model.CallIndex = "shili";
                //  model.parent_id = model.parent_id ?? 0;
                model = bll.Add(model);
                if (model.Id > 0)
                {
                    return View("AddSucess", new MessageModel(model.Title, "Category", "添加分类"));
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            int _id = int.Parse(ControllerContext.RouteData.GetRequiredString("id"));
            var model = bll.GetModel(_id);
            TryUpdateModel(model, collection.AllKeys);

            if (ModelState.IsValid)
            {
                if (bll.Update(model))
                {
                    return View("EditSucess", new MessageModel(model.Title, "Category", "修改分类"));
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