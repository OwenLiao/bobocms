//using EfSearchModel.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Common;
//using Model;
//using System.Net;
//using System.IO;
//using IBLL;
//using Microsoft.Practices.Unity;
//using System.Linq.Dynamic;
//using Upyun;
//using MySolr;
//using System.Text;
//using Enyim.Caching;

//namespace Web.Areas.Admin.Controllers
//{
//    public class ArticleController : Controller
//    {
//        [Dependency]
//        public IArticleService bll { get; set; }
//        [Dependency]
//        public ICategoryService bllCategory { get; set; }
//        [Dependency]
//        public IDownloadAttachService bllDownloadAttach { get; set; }
//        [Dependency]
//        public ICategoryNavService bllCategoryNav { get; set; }

//        public ActionResult List()
//        {
//            return View();
//        }
//        public ActionResult Edit(int? id)
//        {
//            ViewBag.TitleMessage = id == null ? "添加文章" : "修改文章";
//            ViewBag.Category = new SelectList(bllCategory.GetList(q => q.Id > 0), "id", "title");
//            ViewBag.CategoryNav = new SelectList(bllCategoryNav.GetList(q => q.Id > 0), "id", "title");

//            Article m = bll.GetModel(Convert.ToInt32(id));
//            string strVal = string.Empty;
//            string strText = string.Empty;
//            if (m != null)
//            {
//                foreach (var item in m.Categorys)
//                {
//                    strVal += string.IsNullOrEmpty(strVal) ? "" : ",";
//                    strText += string.IsNullOrEmpty(strText) ? "" : ",";
//                    strVal += item.Id;
//                    strText += item.Title;
//                }

//                扩展阅读文章
//                List<int> li = new List<int>();
//                foreach (var item in m.ArticleExtendReads)
//                {
//                    li.Add(Convert.ToInt32(item.ExtendReadId));
//                }
//                var list = bll.GetList(q => li.Contains(q.Id));  //q => q.ArticleExtendReads.All(t => t.ArticleId == id)
//                string strJson = JsonHelper.ObjectToJSON(list.Select("new(Id,Title)"));
//                strJson = strJson.Replace("\"Id\":", "\"id\":").Replace("\"Title\":", "\"name\":");
//                m.strArticleExtendReads = strJson;

//                组合的文章
//                if (!string.IsNullOrEmpty(m.ArticleIds))
//                {
//                    string[] aryArticles = m.ArticleIds.Split(',');
//                    int[] articles = Array.ConvertAll<string, int>(aryArticles, s => int.Parse(s));
//                    var list1 = bll.GetList(q => articles.Contains(q.Id));
//                    string strJson1 = JsonHelper.ObjectToJSON(list1.Select("new(Id,Title)"));
//                    strJson1 = strJson1.Replace("\"Id\":", "\"id\":").Replace("\"Title\":", "\"name\":");
//                    m.ArticleIds = strJson1;
//                }


//            }


//            ViewBag.TagValue = strVal;
//            ViewBag.TagText = strText;
//            return id == null ? View() : View(m);
//        }
//        / <summary>
//        / 获取标签数据
//        / </summary>
//        / <param name = "id" > 文章id </ param >
//        / < returns ></ returns >
//        public ActionResult JsonCategory(int? id)
//        {

//            var _data = bllCategory.GetList(q => q.CallIndex == "shili");
//            List<EasyuiTreeModel> listM = new List<EasyuiTreeModel>();
//            foreach (var item in _data)
//            {
//                EasyuiTreeModel m = new EasyuiTreeModel();
//                m.id = item.Id;
//                m.text = item.Title;
//                m.state = "close";
//                bool b1 = false;
//                if (id != null)
//                {
//                    Category m1 = bll.GetModel(Convert.ToInt32(id)).Categorys.FirstOrDefault(q => q.Id == item.Id);
//                    if (m1 != null)
//                    {
//                        b1 = true;
//                    }
//                }
//                m.Checked = b1;
//                m.children = new List<EasyuiTreeModel>();
//                foreach (var item1 in _data.Where(q => q.parentId == item.Id))
//                {
//                    EasyuiTreeModel m1 = new EasyuiTreeModel();
//                    m1.id = item1.Id;
//                    m1.text = item1.Title;
//                    bool b = false;
//                    if (id != null)
//                    {
//                        Category m2 = bll.GetModel(Convert.ToInt32(id)).Categorys.FirstOrDefault(q => q.Id == item1.Id);
//                        if (m2 != null)
//                        {
//                            b = true;
//                        }
//                    }
//                    m1.Checked = b;
//                    m.children.Add(m1);
//                }
//                listM.Add(m);
//            }
//            return Content(JsonHelper.ObjectToJSON((listM)).Replace("Checked", "checked"));
//        }

//        public ActionResult SelectTag()
//        {
//            return PartialView();

//        }


//        public ActionResult DialogAttach()
//        {
//            return PartialView();

//        }


//        public ActionResult JsonList(QueryModel model)
//        {
//            Response.AppendHeader("Access-Control-Allow-Origin", "http://localhost:23696");
//            int pageIndex = int.Parse(Request["page"]);
//            int pageSize = int.Parse(Request["rows"]);
//            int _total;
//            var _rows = bll.GetList(pageSize, pageIndex, model, "id", false, out _total)
//                .Select("new (" + MyRequest.GetFormString("fieldSelect") + ")");
//            var returnJson = new { total = _total, rows = _rows };
//            return Content(JsonHelper.ObjectToJSON(returnJson));
//            return Json(new { total = _total, rows = _rows.ToList() });
//        }

//        [ValidateInput(false)]
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Add(Article model)
//        {
//            if (ModelState.IsValid)
//            {
//                视频附件
//                if (!string.IsNullOrEmpty(MyRequest.GetFormString("hid_attach_id").Trim()))
//                {
//                    附件
//                    for (int i = 0; i < MyRequest.GetFormString("hid_attach_id").Split(',').Length; i++)
//                    {
//                        DownloadAttach vaM = new DownloadAttach();
//                        vaM.Title = MyRequest.GetFormString("hid_attach_filename").Split(',')[i];
//                        vaM.FileExt = Utils.GetFileExt(vaM.Title);
//                        vaM.FilePath = MyRequest.GetFormString("hid_attach_filepath").Split(',')[i];
//                        vaM.FileSize = Convert.ToInt32(MyRequest.GetFormString("hid_attach_filesize").Split(',')[i]);
//                        model.DownloadAttachs.Add(vaM);

//                        解压压缩包
//                        if (vaM.FileExt.ToLower() == "rar" || vaM.FileExt.ToLower() == "zip")
//                        {
//                            string oFilePath = Utils.GetMapPath(vaM.FilePath.Remove(vaM.FilePath.LastIndexOf('/')));
//                            string oRARFileName = vaM.FilePath.Substring(vaM.FilePath.LastIndexOf('/'));
//                            string oToFilePath = Utils.GetMapPath("../../demo/" + DateTime.Now.ToString("yyyyMM"));
//                            检查有该路径是否就创建
//                            if (!Directory.Exists(oToFilePath))
//                            {
//                                Directory.CreateDirectory(oToFilePath);
//                            }

//                            Utils.UnRAR(oFilePath, oRARFileName, oToFilePath);
//                            model.LinkUrl = DateTime.Now.ToString("yyyyMM") + "/" + vaM.Title.Remove(vaM.Title.Length - 4) + "/index.html";
//                        }
//                    }
//                }

//                model.parent_id = model.parent_id ?? 0;
//                foreach (var str in MyRequest.GetString("txtVals").Trim().Split(','))//权限
//                {
//                    if (!string.IsNullOrEmpty(str.Trim()))
//                    {
//                        Category mmm = bllCategory.GetModel(Convert.ToInt32(str.Trim()));
//                        model.Categorys.Add(bllCategory.GetModel(Convert.ToInt32(str.Trim())));
//                    }

//                }
//                自动提取摘要
//                if (!string.IsNullOrEmpty(model.ZhaiYao))
//                {
//                    model.ZhaiYao = Utils.DropHTML(model.ZhaiYao, 250);
//                }
//                else
//                {
//                    model.ZhaiYao = Utils.DropHTML(model.Content, 250);
//                }
//                model.channelId = 8;
//                model.Content = bll.ContentAddPicurl(model.Content);
//                model.ImgUrl = bll.GenerateImg(model.ImgUrl, true);
//                model = bll.Add(model);
//                if (model.Id > 0)
//                {
//                    RemoveArticleCache(model.VisitUrl, model.Id);
//                    AddSolr(model);
//                    if (model.IsRed != null && (bool)model.IsRed)
//                    {
//                        string url = "http://www.w2bc.com/article/" + model.Id;
//                        推到百度收录
//                        string result = Utils.HttpPost("http://data.zz.baidu.com/urls?site=www.w2bc.com&token=vvK6lc2oTGa2PJRl", "text/plain", url);
//                    }

//                    添加扩展阅读
//                    AddExtend(ref model);
//                    bll.Update(model);

//                    return View("AddSucess", new MessageModel(model.Title, "Article", "添加文章"));
//                }
//            }
//            return View(model);
//        }

//        [HttpPost]
//        [ValidateInput(false)]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(FormCollection collection)
//        {
//            int _id = int.Parse(ControllerContext.RouteData.GetRequiredString("id"));
//            var model = bll.GetModel(_id);
//            TryUpdateModel(model, collection.AllKeys);

//            if (ModelState.IsValid)
//            {
//                删除移除的附件
//                for (int i = 0; i < model.DownloadAttachs.Count; i++)
//                {
//                    string strId = "," + MyRequest.GetFormString("hid_attach_id") + ",";
//                    if (!strId.Contains("," + model.DownloadAttachs.ElementAt(i).Id + ","))
//                    {
//                        UpYunHelper.DelFile(model.DownloadAttachs.ElementAt(i).FilePath);//上传到upyun
//                        model.DownloadAttachs.Remove(model.DownloadAttachs.ElementAt(i));

//                    }
//                }

//                视频附件
//                if (!string.IsNullOrEmpty(MyRequest.GetFormString("hid_attach_id").Trim()))
//                {
//                    for (int i = 0; i < MyRequest.GetFormString("hid_attach_id").Split(',').Length; i++)
//                    {
//                        int id = Convert.ToInt32(MyRequest.GetFormString("hid_attach_id").Split(',')[i]);
//                        DownloadAttach vaM;
//                        string path = MyRequest.GetFormString("hid_attach_filepath").Split(',')[i];
//                        if (id == 0)//添加的附件
//                        {
//                            vaM = new DownloadAttach();

//                            UpYunHelper.Upload(Utils.GetMapPath(path), path);//上传到upyun
//                        }
//                        else //之前添加的附件
//                        {
//                            vaM = model.DownloadAttachs.Single(q => q.Id == id);
//                            if (path != vaM.FilePath)
//                            {
//                                UpYunHelper.Upload(Utils.GetMapPath(path), path);//上传到upyun
//                            }
//                        }
//                        vaM.Title = MyRequest.GetFormString("hid_attach_filename").Split(',')[i];
//                        vaM.FileExt = Utils.GetFileExt(vaM.Title);
//                        vaM.FilePath = path;
//                        vaM.FileSize = Convert.ToInt32(MyRequest.GetFormString("hid_attach_filesize").Split(',')[i]);

//                        model.DownloadAttachs.Add(vaM);
//                    }
//                }


//                分类
//                string category_ids = MyRequest.GetFormString("txtVals");
//                移除标签
//                for (int i = 0; i < model.Categorys.Count; i++)
//                {
//                    if (!("," + category_ids + ",").Contains("," + model.Categorys.ElementAt(i).Id + ","))
//                    {
//                        model.Categorys.Remove(model.Categorys.ElementAt(i));
//                    }
//                }

//                添加新增的标签
//                foreach (string item in category_ids.Trim().Split(','))
//                {
//                    if (!string.IsNullOrEmpty(item))
//                    {
//                        model.Categorys.Add(bllCategory.GetModel(Convert.ToInt32(item)));
//                    }
//                }

//                model.Content = bll.ContentAddPicurl(model.Content);
//                model.ImgUrl = bll.GenerateImg(model.ImgUrl, true);

//                添加扩展阅读


//                AddExtend(ref model);

//                if (bll.Update(model))
//                {
//                    RemoveArticleCache(model.VisitUrl, model.Id);
//                    UpdateSolr(model);
//                    if (model.IsRed != null && (bool)model.IsRed)
//                    {
//                        string url = "http://www.w2bc.com/article/" + model.Id;
//                        推到百度收录
//                        string result = Utils.HttpPost("http://data.zz.baidu.com/urls?site=www.w2bc.com&token=vvK6lc2oTGa2PJRl", "text/plain", url);
//                    }
//                    return View("EditSucess", new MessageModel(model.Title, "article", "修改文章"));
//                }
//            }
//            else
//            {
//                ModelState.AddModelError("", "验证失败");
//            }
//            return View(model);
//        }


//        / <summary>
//        / 删除
//        / </summary>
//        / <param name = "id" > id </ param >
//        / < returns ></ returns >
//        public JsonResult Delete(int id)
//        {

//            删除
//            if (bll.Delete(id))
//            {

//                return Json(true);
//            }
//            else return Json(false);
//        }

//        #region 添加扩展阅读

//        private void AddExtend(ref Article model)
//        {
//            if (!string.IsNullOrEmpty(model.strArticleExtendReads))
//            {
//                foreach (var item in model.strArticleExtendReads.Split(','))
//                {
//                    if (!string.IsNullOrEmpty(item.Trim()))
//                    {
//                        int eId = Convert.ToInt32(item);
//                        int aId = model.Id;
//                        if (model.ArticleExtendReads.FirstOrDefault(q => q.ArticleId == aId && q.ExtendReadId == eId) == null)
//                        {
//                            ArticleExtendRead extM = new ArticleExtendRead();
//                            extM.ArticleId = aId;
//                            extM.ExtendReadId = eId;
//                            model.ArticleExtendReads.Add(extM);
//                        }
//                    }
//                }

//            }
//        }

//        / <summary>
//        / like查询含关链字的文章
//        / </summary>
//        / <returns></returns>
//        public ContentResult GetArticle()
//        {
//            string q = MyRequest.GetQueryString("q");
//            var list = bll.GetList(t => t.Title.Contains(q));
//            string strJson = JsonHelper.ObjectToJSON(list.Select("new(Id,Title)"));
//            strJson = strJson.Replace("\"Id\":", "\"id\":").Replace("\"Title\":", "\"name\":");
//            return Content(strJson);
//        }


//        public ContentResult GetArticleShili()
//        {
//            string q = MyRequest.GetQueryString("q");
//            var list = bll.GetList(t => t.Title.Contains(q) && t.IsHot == true);
//            string strJson = JsonHelper.ObjectToJSON(list.Select("new(Id,Title)"));
//            strJson = strJson.Replace("\"Id\":", "\"id\":").Replace("\"Title\":", "\"name\":");
//            return Content(strJson);
//        }

//        public ContentResult GetArticleShili1(string ids)
//        {
//            string[] idList = ids.Split(',');
//            int[] intArray = Array.ConvertAll<string, int>(idList, s => int.Parse(s));
//            var list = bll.GetList(t => intArray.Contains(t.Id));
//            StringBuilder strJson = new StringBuilder();
//            StringBuilder strJson1 = new StringBuilder();
//            int i = 1;
//            foreach (var item in list)
//            {

//                strJson.Append("<h3 class=title>" + i + "." + item.Title + "</h3>");
//                strJson.Append("<p><img alt=\"" + item.Title + "\" src=\"http://pic.w2bc.com" + item.ImgUrl + "\" /></p>");
//                strJson.Append("<p>" + item.ZhaiYao + "</p>");
//                strJson.Append("<p><a  target=\"_blank\" href=\"http://www.w2bc.com/upload/" + item.LinkUrl + "\">在线预览 </a>&nbsp;&nbsp;&nbsp;");
//                strJson.Append("<a target=\"_blank\" href=\"http://www.w2bc.com/download/index/" + item.Id + "\">源码下载</a> </p>");

//                strJson1.Append("[b]" + i + "." + item.Title + "[/b]\r\n");
//                strJson1.Append("[img]http://pic.w2bc.com" + item.ImgUrl + "[/img]\r\n");
//                strJson1.Append(item.ZhaiYao + "\r\n");
//                strJson1.Append("[url=http://www.w2bc.com/upload/" + item.LinkUrl + "]在线预览[/url]     ");
//                strJson1.Append("[url=http://www.w2bc.com/download/index/" + item.Id + "]源码下载[/url]\r\n");

//                i++;
//            }

//            dynamic strReturn = new { con = strJson, con1 = strJson1 };
//            string strReturn = //string.Format("{\"con\":\"{0}\",\"con1\":\"{1}\"}", strJson, strJson1); //JsonHelper.ObjectToJSON(con);

//            return Content(JsonHelper.ObjectToJSON(strReturn));
//        }
//        #endregion

//        #region 博客同步

//        public string GetW3cplusContent(string content)
//        {
//            string strReturn = string.Empty;

//            strReturn = content.Replace("<h3 class=\"title\">", "[b]").Replace("</h3>", "[/b]").Replace("<p>", "")
//                .Replace("</p>", "").Replace("<a target=\"_blank\" href=\"", "[url=").Replace("\"", "]").Replace("\"", "]");
//            return "";
//        }
//        public void W3cplusSyn()
//        {
//            int isw3cplus = MyRequest.GetQueryInt("IsW3cplus");
//            string content = MyRequest.GetQueryString("contentW3cplus");
//            string cookieStr = MyRequest.GetQueryString("cookieW3cplus");

//            if (isw3cplus > 0 && !string.IsNullOrEmpty(content))
//            {
//                CookieContainer cookie = new CookieContainer();
//                cookie.Add(new Cookie("duoshuo_unique", cookieStr, "", ".duoshuo.com"));
//                string postStr = "";
//                GetContent(postStr, cookie, "");
//            }
//        }

//        public CookieContainer GetCookie(string postString, string postUrl)
//        {

//            CookieContainer cookie = new CookieContainer();
//            HttpWebRequest httpRequset = (HttpWebRequest)HttpWebRequest.Create(postUrl);//创建http 请求
//            httpRequset.CookieContainer = cookie;//设置cookie
//            httpRequset.Method = "POST";//POST 提交
//            httpRequset.KeepAlive = true;
//            httpRequset.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
//            httpRequset.Accept = "text/html, application/xhtml+xml, */*";
//            httpRequset.ContentType = "application/x-www-form-urlencoded";//以上信息在监听请求的时候都有的直接复制过来
//            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(postString);
//            httpRequset.ContentLength = bytes.Length;
//            Stream stream = httpRequset.GetRequestStream();
//            stream.Write(bytes, 0, bytes.Length);
//            stream.Close();//以上是POST数据的写入

//            HttpWebResponse httpResponse = (HttpWebResponse)httpRequset.GetResponse();//获得 服务端响应
//            return cookie;//拿到cookie
//        }
//        static string GetContent(string postString, CookieContainer cookie, string url)
//        {
//            string content;
//            HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(url);
//            httpRequest.CookieContainer = cookie;
//            httpRequest.Referer = url;
//            httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
//            httpRequest.Accept = "text/html, application/xhtml+xml, */*";
//            httpRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
//            httpRequest.Method = "POST";

//            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(postString);
//            httpRequest.ContentLength = bytes.Length;
//            Stream stream = httpRequest.GetRequestStream();
//            stream.Write(bytes, 0, bytes.Length);
//            stream.Close();//以上是POST数据的写入

//            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

//            using (Stream responsestream = httpResponse.GetResponseStream())
//            {

//                using (StreamReader sr = new StreamReader(responsestream, System.Text.Encoding.UTF8))
//                {
//                    content = sr.ReadToEnd();
//                }
//            }

//            return content;
//        }
//        #endregion

//        #region 下载查看
//        public ActionResult Down()
//        {
//            return View();
//        }

//        public ActionResult JsonListDown(QueryModel model)
//        {
//            int pageIndex = int.Parse(Request["page"]);
//            int pageSize = int.Parse(Request["rows"]);
//            int _total;
//            var _rows = bllDownloadAttach.GetList(pageSize, pageIndex, model, "id", false, out _total);
//            string fieldSelect = MyRequest.GetFormString("fieldSelect");//指定的查询字段
//            var returnJson = new { total = _total, rows = _rows.ToList().Select(string.Format("new({0})", fieldSelect)) };
//            return Content(JsonHelper.ObjectToJSON(returnJson));

//            return Json(new { total = _total, rows = _rows.ToList() });
//        }
//        #endregion

//        #region 清缓存

//        static MemcachedClient memCached = MyCache.OCSMemcached.getInstance(); //阿里云分布式缓存ocs
//        / <summary>
//        / 添加、修改文章清除缓存
//        / </summary>
//        private void RemoveArticleCache(string VisitUrl, int id)
//        {
//            MyCache.EnyimMemcachedContext memCached = new MyCache.EnyimMemcachedContext();
//            for (int i = 1; i < 10; i++)
//            {
//                memCached.Remove("home_index_" + i);
//                memCached.Remove("shili__" + i);
//                memCached.Remove("shili_index_" + i);
//            }
//            memCached.Remove("article_" + VisitUrl);
//            memCached.Remove("article_" + id);
//        }
//        #endregion

//        #region solr
//        void AddSolr(Article m)
//        {
//            SolrModel m1 = new SolrModel();
//            m1.Add_time = Convert.ToDateTime(m.AddTime);
//            m1.Channel_id = Convert.ToInt32(m.channelId);
//            m1.Content = Common.Utils.DropHTML(m.Content);
//            m1.Id = m.Id.ToString();
//            m1.Title = m.Title;
//            SolrHelper.AddIndex(m1);
//        }
//        void UpdateSolr(Article m)
//        {
//            SolrHelper.DeleteIndex(m.Id);
//            AddSolr(m);
//        }

//        #endregion
//    }
//}