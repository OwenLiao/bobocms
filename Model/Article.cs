using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Article
    {
        public Article()
        {
            this.SortId = 99;
            this.Click = 0;
            this.RealClick = 0;
            this.IsMsg = false;
            this.IsTop = false;
            this.IsRed = false;
            this.IsHot = false;
            this.IsSlide = false;
            this.IsLock = false;
            this.IsBig = false;
            this.DiggGood = 0;
            this.DiggBad = 0;
            this.CommentCount = 0;
            this.ShareCount = 0;
            this.AddTime = DateTime.Now;
            this.ArticleCategories = new List<ArticleCategory>();
        }

        /// <summary>
        /// 自增ID
        /// </summary>
        public int Id
        {
            set;
            get;
        }
        /// <summary>
        /// 标题
        /// </summary>
        [Display(Name = "标题")]
        public string Title
        {
            set;
            get;
        }
        /// <summary>
        /// 另取标题
        /// </summary>
        public string Title1
        {
            set;
            get;
        }
        /// <summary>
        /// 作者
        /// </summary>

        public string Author
        {
            set;
            get;
        }
        /// <summary>
        /// 录入员
        /// </summary>
        public string InputAuthor
        {
            set;
            get;
        }

        /// <summary>
        /// 文章来源
        /// </summary>
        public string From
        {
            set;
            get;
        }
        [Display(Name = "摘要")]
        /// <summary>
        /// 文章摘要
        /// </summary>        
        public string Description
        {
            set;
            get;
        }
        [Display(Name = "外部链接")]
        /// <summary>
        /// 外部链接
        /// </summary>
        public string LinkUrl
        {
            set;
            get;
        }
        [Display(Name = "封面链接")]
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgUrl
        {
            set;
            get;
        }
        /// <summary>
        /// SEO标题
        /// </summary>
        public string SeoTitle
        {
            set;
            get;
        }
        /// <summary>
        /// SEO关健字
        /// </summary>
        public string SeoKeywords
        {
            set;
            get;
        }
        /// <summary>
        /// SEO描述
        /// </summary>
        public string SeoDescription
        {
            set;
            get;
        }
        /// <summary>
        /// 详细内容
        /// </summary>
        public string Content
        {
            set;
            get;
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int SortId
        {
            set;
            get;
        }
        /// <summary>
        /// 显示点击量，后台可以修改
        /// </summary>
        public int Click
        {
            set;
            get;
        }
        /// <summary>
        /// 点击量
        /// </summary>
        public int RealClick
        {
            set;
            get;
        }
        /// <summary>
        /// 是否显示阅读量
        /// </summary>
        public bool IsMsg
        {
            set;
            get;
        }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool IsTop
        {
            set;
            get;
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsRed
        {
            set;
            get;
        }
        /// <summary>
        /// 是否热门
        /// </summary>
        public bool IsHot
        {
            set;
            get;
        }
        /// <summary>
        /// 是否幻灯片
        /// </summary>
        public bool IsSlide
        {
            set;
            get;
        }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool IsLock
        {
            set;
            get;
        }
        /// <summary>
        /// 观察员用户ID
        /// </summary>
        public int? UserId
        {
            set;
            get;
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime AddTime
        {
            set;
            get;
        }

        /// <summary>
        /// 顶一下
        /// </summary>
        public int DiggGood
        {
            set;
            get;
        }
        /// <summary>
        /// 踩一下
        /// </summary>
        public int DiggBad
        {
            set;
            get;
        }
        /// <summary>
        /// 分享数
        /// </summary>
        public int ShareCount
        {
            set;
            get;
        }
        /// <summary>
        /// 是否头条文章 1是; 0否
        /// </summary>

        public bool IsBig
        {
            set;
            get;
        }
        /// <summary>
        /// 是否首页显示 0:不显示 1显示
        /// </summary>
        public bool IsShow
        {
            set;
            get;
        }






        /// <summary>
        ///评论数
        /// </summary>
        public int CommentCount
        {
            set;
            get;
        }

        /// <summary>
        ///所属专题Id
        /// </summary>
        public int? ThemeId { get; set; }

        /// <summary>
        /// 是否加入RSS
        /// </summary>
        public bool IsAddRSS { get; set; }






        /// <summary>
        /// 文章的标签
        /// </summary>
        public virtual ICollection<ArticleCategory> ArticleCategories { get; set; }


    }
}
