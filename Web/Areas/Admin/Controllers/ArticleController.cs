﻿
using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Model;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using Admin.Model;

namespace Web.Areas.Admin.Controllers
{
    public class ArticleController : BaseController
    {

        IArticleService bll;

        ICategoryService bllCategory;
        public ArticleController(IArticleService _bll, ICategoryService _bllCategory)
        {
            bll = _bll;
            bllCategory = _bllCategory;
        }
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.TitleMessage = id == null ? "添加文章" : "修改文章";
            ViewBag.Category = new SelectList(bllCategory.GetList(q => q.Id > 0), "id", "title");

            Article m = bll.GetModel(Convert.ToInt32(id));
            string strVal = string.Empty;
            string strText = string.Empty;
            if (m != null)
            {
                foreach (var item in m.ArticleCategories)
                {
                    strVal += string.IsNullOrEmpty(strVal) ? "" : ",";
                    strText += string.IsNullOrEmpty(strText) ? "" : ",";
                    strVal += item.CategoryId;
                    strText += item.Category.Title;
                }
            }


            ViewBag.TagValue = strVal;
            ViewBag.TagText = strText;
            return id == null ? View() : View(m);
        }
        /// <summary>
        /// 获取标签数据
        /// </summary>
        /// <param name = "id" > 文章id </ param >
        /// < returns ></ returns >
        //public ActionResult JsonCategory(int? id)
        //{

        //    var _data = bllCategory.GetList(q => q.CallIndex == "shili");
        //    List<EasyuiTreeModel> listM = new List<EasyuiTreeModel>();
        //    foreach (var item in _data)
        //    {
        //        EasyuiTreeModel m = new EasyuiTreeModel();
        //        m.id = item.Id;
        //        m.text = item.Title;
        //        m.state = "close";
        //        bool b1 = false;
        //        if (id != null)
        //        {
        //            Category m1 = bll.GetModel(Convert.ToInt32(id)).Categorys.FirstOrDefault(q => q.Id == item.Id);
        //            if (m1 != null)
        //            {
        //                b1 = true;
        //            }
        //        }
        //        m.Checked = b1;
        //        m.children = new List<EasyuiTreeModel>();
        //        foreach (var item1 in _data.Where(q => q.parentId == item.Id))
        //        {
        //            EasyuiTreeModel m1 = new EasyuiTreeModel();
        //            m1.id = item1.Id;
        //            m1.text = item1.Title;
        //            bool b = false;
        //            if (id != null)
        //            {
        //                Category m2 = bll.GetModel(Convert.ToInt32(id)).Categorys.FirstOrDefault(q => q.Id == item1.Id);
        //                if (m2 != null)
        //                {
        //                    b = true;
        //                }
        //            }
        //            m1.Checked = b;
        //            m.children.Add(m1);
        //        }
        //        listM.Add(m);
        //    }
        //    return Content(JsonHelper.ObjectToJSON((listM)).Replace("Checked", "checked"));
        //}

        public ActionResult SelectTag()
        {
            return PartialView();

        }


        public ActionResult DialogAttach()
        {
            return PartialView();

        }


        //public ActionResult JsonList(QueryModel model)
        //{
        //    Response.AppendHeader("Access-Control-Allow-Origin", "http://localhost:23696");
        //    int pageIndex = int.Parse(Request["page"]);
        //    int pageSize = int.Parse(Request["rows"]);
        //    int _total;
        //    var _rows = bll.GetList(pageSize, pageIndex, model, "id", false, out _total)
        //        .Select("new (" + MyRequest.GetFormString("fieldSelect") + ")");
        //    var returnJson = new { total = _total, rows = _rows };
        //    return Content(JsonHelper.ObjectToJSON(returnJson));
        //    return Json(new { total = _total, rows = _rows.ToList() });
        //}

        //[ValidateInput(false)]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Add(Article model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        视频附件
        //        if (!string.IsNullOrEmpty(MyRequest.GetFormString("hid_attach_id").Trim()))
        //        {
        //            附件
        //            for (int i = 0; i < MyRequest.GetFormString("hid_attach_id").Split(',').Length; i++)
        //            {
        //                DownloadAttach vaM = new DownloadAttach();
        //                vaM.Title = MyRequest.GetFormString("hid_attach_filename").Split(',')[i];
        //                vaM.FileExt = Utils.GetFileExt(vaM.Title);
        //                vaM.FilePath = MyRequest.GetFormString("hid_attach_filepath").Split(',')[i];
        //                vaM.FileSize = Convert.ToInt32(MyRequest.GetFormString("hid_attach_filesize").Split(',')[i]);
        //                model.DownloadAttachs.Add(vaM);

        //                解压压缩包
        //                if (vaM.FileExt.ToLower() == "rar" || vaM.FileExt.ToLower() == "zip")
        //                {
        //                    string oFilePath = Utils.GetMapPath(vaM.FilePath.Remove(vaM.FilePath.LastIndexOf('/')));
        //                    string oRARFileName = vaM.FilePath.Substring(vaM.FilePath.LastIndexOf('/'));
        //                    string oToFilePath = Utils.GetMapPath("../../demo/" + DateTime.Now.ToString("yyyyMM"));
        //                    检查有该路径是否就创建
        //                    if (!Directory.Exists(oToFilePath))
        //                    {
        //                        Directory.CreateDirectory(oToFilePath);
        //                    }

        //                    Utils.UnRAR(oFilePath, oRARFileName, oToFilePath);
        //                    model.LinkUrl = DateTime.Now.ToString("yyyyMM") + "/" + vaM.Title.Remove(vaM.Title.Length - 4) + "/index.html";
        //                }
        //            }
        //        }

        //        model.parent_id = model.parent_id ?? 0;
        //        foreach (var str in MyRequest.GetString("txtVals").Trim().Split(','))//权限
        //        {
        //            if (!string.IsNullOrEmpty(str.Trim()))
        //            {
        //                Category mmm = bllCategory.GetModel(Convert.ToInt32(str.Trim()));
        //                model.Categorys.Add(bllCategory.GetModel(Convert.ToInt32(str.Trim())));
        //            }

        //        }
        //        自动提取摘要
        //        if (!string.IsNullOrEmpty(model.ZhaiYao))
        //        {
        //            model.ZhaiYao = Utils.DropHTML(model.ZhaiYao, 250);
        //        }
        //        else
        //        {
        //            model.ZhaiYao = Utils.DropHTML(model.Content, 250);
        //        }
        //        model.channelId = 8;
        //        model.Content = bll.ContentAddPicurl(model.Content);
        //        model.ImgUrl = bll.GenerateImg(model.ImgUrl, true);
        //        model = bll.Add(model);
        //        if (model.Id > 0)
        //        {
        //            RemoveArticleCache(model.VisitUrl, model.Id);
        //            AddSolr(model);
        //            if (model.IsRed != null && (bool)model.IsRed)
        //            {
        //                string url = "http://www.w2bc.com/article/" + model.Id;
        //                推到百度收录
        //                string result = Utils.HttpPost("http://data.zz.baidu.com/urls?site=www.w2bc.com&token=vvK6lc2oTGa2PJRl", "text/plain", url);
        //            }

        //            添加扩展阅读
        //            AddExtend(ref model);
        //            bll.Update(model);

        //            return View("AddSucess", new MessageModel(model.Title, "Article", "添加文章"));
        //        }
        //    }
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateInput(false)]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(FormCollection collection)
        //{
        //    int _id = int.Parse(ControllerContext.RouteData.GetRequiredString("id"));
        //    var model = bll.GetModel(_id);
        //    TryUpdateModel(model, collection.AllKeys);

        //    if (ModelState.IsValid)
        //    {
        //        删除移除的附件
        //        for (int i = 0; i < model.DownloadAttachs.Count; i++)
        //        {
        //            string strId = "," + MyRequest.GetFormString("hid_attach_id") + ",";
        //            if (!strId.Contains("," + model.DownloadAttachs.ElementAt(i).Id + ","))
        //            {
        //                UpYunHelper.DelFile(model.DownloadAttachs.ElementAt(i).FilePath);//上传到upyun
        //                model.DownloadAttachs.Remove(model.DownloadAttachs.ElementAt(i));

        //            }
        //        }

        //        视频附件
        //        if (!string.IsNullOrEmpty(MyRequest.GetFormString("hid_attach_id").Trim()))
        //        {
        //            for (int i = 0; i < MyRequest.GetFormString("hid_attach_id").Split(',').Length; i++)
        //            {
        //                int id = Convert.ToInt32(MyRequest.GetFormString("hid_attach_id").Split(',')[i]);
        //                DownloadAttach vaM;
        //                string path = MyRequest.GetFormString("hid_attach_filepath").Split(',')[i];
        //                if (id == 0)//添加的附件
        //                {
        //                    vaM = new DownloadAttach();

        //                    UpYunHelper.Upload(Utils.GetMapPath(path), path);//上传到upyun
        //                }
        //                else //之前添加的附件
        //                {
        //                    vaM = model.DownloadAttachs.Single(q => q.Id == id);
        //                    if (path != vaM.FilePath)
        //                    {
        //                        UpYunHelper.Upload(Utils.GetMapPath(path), path);//上传到upyun
        //                    }
        //                }
        //                vaM.Title = MyRequest.GetFormString("hid_attach_filename").Split(',')[i];
        //                vaM.FileExt = Utils.GetFileExt(vaM.Title);
        //                vaM.FilePath = path;
        //                vaM.FileSize = Convert.ToInt32(MyRequest.GetFormString("hid_attach_filesize").Split(',')[i]);

        //                model.DownloadAttachs.Add(vaM);
        //            }
        //        }


        //        分类
        //        string category_ids = MyRequest.GetFormString("txtVals");
        //        移除标签
        //        for (int i = 0; i < model.Categorys.Count; i++)
        //        {
        //            if (!("," + category_ids + ",").Contains("," + model.Categorys.ElementAt(i).Id + ","))
        //            {
        //                model.Categorys.Remove(model.Categorys.ElementAt(i));
        //            }
        //        }

        //        添加新增的标签
        //        foreach (string item in category_ids.Trim().Split(','))
        //        {
        //            if (!string.IsNullOrEmpty(item))
        //            {
        //                model.Categorys.Add(bllCategory.GetModel(Convert.ToInt32(item)));
        //            }
        //        }

        //        model.Content = bll.ContentAddPicurl(model.Content);
        //        model.ImgUrl = bll.GenerateImg(model.ImgUrl, true);

        //        添加扩展阅读


        //        AddExtend(ref model);

        //        if (bll.Update(model))
        //        {
        //            RemoveArticleCache(model.VisitUrl, model.Id);
        //            UpdateSolr(model);
        //            if (model.IsRed != null && (bool)model.IsRed)
        //            {
        //                string url = "http://www.w2bc.com/article/" + model.Id;
        //                推到百度收录
        //                string result = Utils.HttpPost("http://data.zz.baidu.com/urls?site=www.w2bc.com&token=vvK6lc2oTGa2PJRl", "text/plain", url);
        //            }
        //            return View("EditSucess", new MessageModel(model.Title, "article", "修改文章"));
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "验证失败");
        //    }
        //    return View(model);
        //}


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name = "id" > id </ param >
        /// < returns ></ returns >
        //public JsonResult Delete(int id)
        //{

        //    删除
        //    if (bll.Delete(id))
        //    {

        //        return Json(true);
        //    }
        //    else return Json(false);
        //}

        #region 添加扩展阅读

        //private void AddExtend(ref Article model)
        //{
        //    if (!string.IsNullOrEmpty(model.strArticleExtendReads))
        //    {
        //        foreach (var item in model.strArticleExtendReads.Split(','))
        //        {
        //            if (!string.IsNullOrEmpty(item.Trim()))
        //            {
        //                int eId = Convert.ToInt32(item);
        //                int aId = model.Id;
        //                if (model.ArticleExtendReads.FirstOrDefault(q => q.ArticleId == aId && q.ExtendReadId == eId) == null)
        //                {
        //                    ArticleExtendRead extM = new ArticleExtendRead();
        //                    extM.ArticleId = aId;
        //                    extM.ExtendReadId = eId;
        //                    model.ArticleExtendReads.Add(extM);
        //                }
        //            }
        //        }

        //    }
        //}

        /// <summary>
        /// like查询含关链字的文章
        /// </summary>
        /// <returns></returns>
        //public ContentResult GetArticle()
        //{
        //    string q = MyRequest.GetQueryString("q");
        //    var list = bll.GetList(t => t.Title.Contains(q));
        //    string strJson = JsonHelper.ObjectToJSON(list.Select("new(Id,Title)"));
        //    strJson = strJson.Replace("\"Id\":", "\"id\":").Replace("\"Title\":", "\"name\":");
        //    return Content(strJson);
        //}


        //public ContentResult GetArticleShili()
        //{
        //    string q = MyRequest.GetQueryString("q");
        //    var list = bll.GetList(t => t.Title.Contains(q) && t.IsHot == true);
        //    string strJson = JsonHelper.ObjectToJSON(list.Select("new(Id,Title)"));
        //    strJson = strJson.Replace("\"Id\":", "\"id\":").Replace("\"Title\":", "\"name\":");
        //    return Content(strJson);
        //}

        //public ContentResult GetArticleShili1(string ids)
        //{
        //    string[] idList = ids.Split(',');
        //    int[] intArray = Array.ConvertAll<string, int>(idList, s => int.Parse(s));
        //    var list = bll.GetList(t => intArray.Contains(t.Id));
        //    StringBuilder strJson = new StringBuilder();
        //    StringBuilder strJson1 = new StringBuilder();
        //    int i = 1;
        //    foreach (var item in list)
        //    {

        //        strJson.Append("<h3 class=title>" + i + "." + item.Title + "</h3>");
        //        strJson.Append("<p><img alt=\"" + item.Title + "\" src=\"http://pic.w2bc.com" + item.ImgUrl + "\" /></p>");
        //        strJson.Append("<p>" + item.ZhaiYao + "</p>");
        //        strJson.Append("<p><a  target=\"_blank\" href=\"http://www.w2bc.com/upload/" + item.LinkUrl + "\">在线预览 </a>&nbsp;&nbsp;&nbsp;");
        //        strJson.Append("<a target=\"_blank\" href=\"http://www.w2bc.com/download/index/" + item.Id + "\">源码下载</a> </p>");

        //        strJson1.Append("[b]" + i + "." + item.Title + "[/b]\r\n");
        //        strJson1.Append("[img]http://pic.w2bc.com" + item.ImgUrl + "[/img]\r\n");
        //        strJson1.Append(item.ZhaiYao + "\r\n");
        //        strJson1.Append("[url=http://www.w2bc.com/upload/" + item.LinkUrl + "]在线预览[/url]     ");
        //        strJson1.Append("[url=http://www.w2bc.com/download/index/" + item.Id + "]源码下载[/url]\r\n");

        //        i++;
        //    }

        //    dynamic strReturn = new { con = strJson, con1 = strJson1 };
        //    string strReturn = //string.Format("{\"con\":\"{0}\",\"con1\":\"{1}\"}", strJson, strJson1); //JsonHelper.ObjectToJSON(con);

        //    return Content(JsonHelper.ObjectToJSON(strReturn));
        //}
        #endregion



    }
}