using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Linq;
using Common;

namespace DAL
{
    public class ManagerService : BaseRepository<Manager>, IManagerService
    {
        ISysChannelService bllSys;
        IManagerRoleService bllManRol;
        public ManagerService(MyDbContext context, ISysChannelService _bllSys, IManagerRoleService _bllManRol)
            : base(context)
       {

            bllSys = _bllSys;
           bllManRol = _bllManRol;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="user_name">实体user_name</param>
        /// <returns></returns>
        public Manager GetModel(string userName)
        {
            return GetModel(q => q.UserName == userName);

        }


        /// <summary>
        /// 获取一个管理员的菜单
        /// </summary>
        /// <param name="user_name">管理员用户名</param>
        /// <returns></returns>
        public List<SysChannel> GetMenu(string userName)
        {
            var manager = GetModel(userName);
            List<SysChannel> channels = new List<SysChannel>();
            // if (manager.ManagerRole.RoleType == 1)//超级管理员


             if (bllManRol.GetModel(q=>q.Id==manager.roleId).RoleType == 1)//超级管理员
           // if (nContext.Manager.FirstOrDefault().ManagerRole.RoleType==1)
     
            {
                var list = bllSys.GetList(q => q.Id > 0, "SortId", true);
                foreach (var item in list)
                {
                    channels.Add(item);
                }
            }
            else
            {
                var mrvs = manager.ManagerRole.ManagerRoleValues.Where(q => q.ActionType == MyEnums.ActionEnum.View.ToString());
                foreach (var item in mrvs)
                {
                    channels.Add(item.SysChannel);
                }
            }
            return channels;

        }
    }
}
