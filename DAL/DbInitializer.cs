using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider service)
        {
            var context = service.GetService<MyDbContext>();
            // context.Database.EnsureCreated();

            // Look for any students.
            if (!context.Category.Any())
            {
                var categories = new Category[]
                {
                    new Category{Title="十佳球",Name="shijiaqiu"},
                    new Category{Title="十佳球",Name="shijiaqiu"}
                };
                foreach (Category s in categories)
                {
                    context.Category.Add(s);
                }
            }

            if (!context.Manager.Any())
            {
                Manager m = new Manager
                {
                    UserName = "admin",
                    UserPwd = Common.DESEncrypt.Md5("admin888"),
                    roleId = 1
                };
                context.Manager.Add(m);
            }
            #region 后台菜单
            AddSys("资讯管理","zixunguanli","","");
            AddSys("文章管理", "article", "Article/List", "资讯管理");
            AddSys("分类管理", "article", "Category/List", "资讯管理");
            AddSys("系统管理", "xitongguangli", "", "");
            AddSys("频道管理", "syschannel", "Syschannel/List", "系统管理");
            AddSys("参数设置", "sys_config", "Syschannel/List", "系统管理");

            #endregion
            context.SaveChanges();


             void AddSys(string Title, string Name, string LinkUrl,string partentTitle)
            {
                if (context.SysChannel.FirstOrDefault(q => q.Title == Title) == null)
                {
                    var sys = new SysChannel();
                    sys.Title = Title;
                    sys.Name = Name;
                    sys.LinkUrl = LinkUrl;
                    var sysParent = context.SysChannel.FirstOrDefault(q => q.Title == partentTitle);
                    if (sysParent!=null)
                    {
                        sys.parentId = sysParent.Id;
                    }
                    context.SysChannel.Add(sys);
                }
            }

        }
      
    }
}
