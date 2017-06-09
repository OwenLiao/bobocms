using System;
using System.Collections.Generic;
using System.Text;



namespace Common
{
    public class MyKeys
    {

        //File======================================================
        /// <summary>
        /// 插件配制文件名
        /// </summary>
        public const string FILE_PLUGIN_XML_CONFING = "plugin.config";
        /// <summary>
        /// 站点配置文件名
        /// </summary>
        public const string FILE_SITE_XML_CONFING = "Configpath";
        /// <summary>
        /// URL配置文件名
        /// </summary>
        public const string FILE_URL_XML_CONFING = "Urlspath";
        /// <summary>
        /// 用户配置文件名
        /// </summary>
        public const string FILE_USER_XML_CONFING = "Userpath";


        //Directory==================================================
        /// <summary>
        /// ASPX目录
        /// </summary>
        public const string DIRECTORY_REWRITE_ASPX = "aspx";
        /// <summary>
        /// HTML目录
        /// </summary>
        public const string DIRECTORY_REWRITE_HTML = "html";

        //Cache======================================================
        /// <summary>
        /// 站点配置
        /// </summary>
        public const string CACHE_SITE_CONFIG = "my_cache_site_config";
        /// <summary>
        /// 用户配置
        /// </summary>
        public const string CACHE_USER_CONFIG = "my_cache_user_config";
        /// <summary>
        /// 用户配置
        /// </summary>
        public const string CACHE_ARTICLE_CONFIG = "my_cache_article_config";
        /// <summary>
        /// 客户端站点配置
        /// </summary>
        public const string CACHE_SITE_CONFIG_CLIENT = "my_cache_site_client_config";
        /// <summary>
        /// HttpModule映射类
        /// </summary>
        public const string CACHE_SITE_HTTP_MODULE = "my_cache_http_module";
        /// <summary>
        /// URL重写映射表
        /// </summary>
        public const string CACHE_SITE_URLS = "my_cache_site_urls";

        //Session=====================================================
        /// <summary>
        /// 验证码
        /// </summary>
        public const string SESSION_CODE = "my_session_code";
        /// <summary>
        /// 后台管理员
        /// </summary>
        public const string SESSION_ADMIN_INFO = "my_session_admin_info";
        /// <summary>
        /// 会员用户
        /// </summary>
        public const string SESSION_USER_INFO = "my_session_user_info";

        //Cookies=====================================================
        /// <summary>
        /// 防重复顶踩KEY
        /// </summary>
        public const string COOKIE_DIGG_KEY = "cookie_digg_key";
        /// <summary>
        /// 防重复评论KEY
        /// </summary>
        public const string COOKIE_COMMENT_KEY = "cookie_comment_key";
        /// <summary>
        /// 防止下载重复扣各分
        /// </summary>
        public const string COOKIE_DOWNLOAD_KEY = "download_attach_key";
        /// <summary>
        /// 记住会员用户名
        /// </summary>
        public const string COOKIE_USER_NAME_REMEMBER = "cookie_user_name_remember";
        /// <summary>
        /// 记住会员密码
        /// </summary>
        public const string COOKIE_USER_PWD_REMEMBER = "cookie_user_pwd_remember";
        /// <summary>
        /// 购物车
        /// </summary>
        public const string COOKIE_SHOPPING_CART = "cookie_shop_cart";


    }
}
