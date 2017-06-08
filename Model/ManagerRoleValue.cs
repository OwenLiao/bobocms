
using System;
using System.Collections.Generic;

namespace Model
{

    public partial class ManagerRoleValue
    {

        /// <summary>
        ///
        /// </summary>
     
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
     
        public Nullable<int> roleId { get; set; }

        /// <summary>
        ///
        /// </summary>
     
        public string ChannelName { get; set; }

        /// <summary>
        ///
        /// </summary>
     
        public Nullable<int> channelId { get; set; }

        /// <summary>
        ///
        /// </summary>
     
        public string ActionType { get; set; }
        [JsonIgnoreAttribute]
        public virtual ManagerRole ManagerRole { get; set; }
     
        [JsonIgnoreAttribute]
        public virtual SysChannel SysChannel { get; set; }
    }
}
