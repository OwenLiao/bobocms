using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Category
    {
        public Category()
        {
            this.SortId = 99;
            this.IsGuoYuan = false;
            this.AddTime = DateTime.Now;
        }

        /// <summary>
        /// 自增ID
        /// </summary>
        public int Id
        {
            set;
            get;
        }
        [Display(Name = "类别标题")]
        public string Title
        {
            set;
            get;
        }

        [Display(Name = "调用别名")]
        public string CallIndex
        {
            set;
            get;
        }

        [Display(Name = "父类别ID")]
        public int? ParentId
        {
            set;
            get;
        }

        [Display(Name = "排序数字")]
        public int SortId
        {
            set;
            get;
        }
        /// <summary>
        /// URL跳转地址
        /// </summary>
        [Display(Name = "URL跳转地址")]
        public string LinkUrl
        {
            set;
            get;
        }

        [Display(Name = "图片地址")]
        public string ImgUrl
        {
            set;
            get;
        }

        [Display(Name = "背景图片")]
        public string BackGround { get; set; }

        [Display(Name = "描述")]
        public string Content
        {
            set;
            get;
        }
        [Display(Name = "显示关注人数")]
        public int GuanZhuCount { get; set; }

        [Display(Name = "真实关注人数")]
        public int RealGuanZhuCount { get; set; }

        /// <summary>
        /// 该细分是否是已创建果园
        /// </summary>
        [Display(Name = "是否成为果园")]
        public bool IsGuoYuan
        {
            set;
            get;
        }
        [Display(Name = "平台登录显示")]
        public string PlatformLoginText { get; set; }
        [Display(Name = "平台登录Url")]
        public string PlatformLoginUrl { get; set; }
        [Display(Name = "平台开店显示")]
        public string PlatformSetUpShopText { get; set; }
        [Display(Name = "平台开店Url")]
        public string PlatformSetUpShopUrl { get; set; }

        [Display(Name = "SEO标题")]
        public string SeoTitle
        {
            set;
            get;
        }

        [Display(Name = "SEO关健字")]
        public string SeoKeywords
        {
            set;
            get;
        }

        [Display(Name = "SEO描述")]
        public string SeoDescription
        {
            set;
            get;
        }
        [Display(Name = "是否锁定")]
        public bool IsLock { set; get; }
        /// <summary>
        /// 此字段用于保存该分类下的关联细分。比如果园各个平台下对应的运营干货、平台规则。  用英文下的,号隔开。
        /// </summary>
        [Display(Name = "关联细分")]
        public string CategoryRelation
        {
            get;
            set;
        }


        /// <summary>
        /// 首字母
        /// </summary>
        public string HeadChar
        {
            set;
            get;
        }
        [Display(Name = "点单次数")]
        public string ClickCount
        {
            set;
            get;
        }
        [Display(Name = "英文名")]
        public string Name { get; set; }

        [Display(Name = "创建时间")]
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 文章详情细分下的文章
        /// </summary>

        public virtual ICollection<DetailArticleCategory> DetaileArticles { get; set; }

        /// <summary>
        /// 文章列表细分下的文章
        /// </summary>

        public virtual ICollection<ListArticleCategory> ListArticles { get; set; }

        /// <summary>
        /// 父标签
        /// </summary>
        public virtual Category Parent { get; set; }
        /// <summary>
        /// 父标签下的子标签
        /// </summary>
        public virtual ICollection<Category> Childs { get; set; }


        /// <summary>
        /// 类别类型的Id
        /// </summary>
        [Display(Name = "细分类型Id")]
        public int? CategoryTypeId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 标签不显示
        /// </summary>
        [Display(Name = "标签是否显示")]
        public bool NotTagShow { get; set; }

        [Display(Name = "文章底部微信公众号信息")]
        public string ArticleBottomWechatHtml { get; set; }
    }
}
