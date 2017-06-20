using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Linq;

namespace DAL
{
    public class ManagerRoleService : BaseRepository<ManagerRole>, IManagerRoleService
    {
        public ManagerRoleService(MyDbContext context)
            : base(context)
       { }


        /// <summary>
        /// 检查是否有权限
        /// </summary>
        public bool Exists(int role_id, int channel_id)
        {
            ManagerRole model = GetModel(role_id);
            if (model != null)
            {
                if (model.RoleType == 1)
                {
                    return true;
                }
                var modelt = model.ManagerRoleValues.Where(p => p.channelId == channel_id);
                if (modelt.Count() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        ///// <summary>
        ///// 检查是否有权限
        ///// </summary>
        public bool Exists(int role_id, int channel_id, string action_type)
        {
            ManagerRole model = GetModel(role_id);
            if (model != null)
            {
                if (model.RoleType == 1)
                {
                    return true;
                }
                ManagerRoleValue modelt = model.ManagerRoleValues.Single(p => p.channelId == channel_id && p.ActionType == action_type);
                if (modelt != null)
                {
                    return true;
                }
            }
            return false;
        }

        ///// <summary>
        ///// 检查是否有权限
        ///// </summary>
        public bool Exists(int role_id, string channel_name, string action_type)
        {
            ManagerRole model = GetModel(role_id);
            if (model != null)
            {
                if (model.RoleType == 1)
                {
                    return true;
                }
                ManagerRoleValue modelt = model.ManagerRoleValues.Single(p => p.ChannelName == channel_name && p.ActionType == action_type);
                if (modelt != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
