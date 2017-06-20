using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface ICategoryService : IBaseService<Category> { }

    public interface IArticleService : IBaseService<Article> { }
    public interface IManagerService : IBaseService<Manager>
    {
        Manager GetModel(string userName);

        /// <summary>
        /// 获取一个管理员的菜单
        /// </summary>
        /// <param name="user_name">管理员用户名</param>
        /// <returns></returns>
        List<SysChannel> GetMenu(string userName);

    }

    public interface IManagerRoleService : IBaseService<ManagerRole> {
        /// <summary>
        /// 检查是否有权限
        /// </summary>
        bool Exists(int role_id, int channel_id);

        ///// <summary>
        ///// 检查是否有权限
        ///// </summary>
        bool Exists(int role_id, int channel_id, string action_type);

        ///// <summary>
        ///// 检查是否有权限
        ///// </summary>
        bool Exists(int role_id, string channel_name, string action_type);
    }
    public interface IManagerRoleValueService : IBaseService<ManagerRoleValue> { }
    
    public interface ISysChannelService : IBaseService<SysChannel> { }


}
