using System;
using System.Collections.Generic;

namespace Model
{
 
    public partial class ManagerLog
    {
        public ManagerLog()
        {
            LoginTime = DateTime.Now;
        }
        /// <summary>
        ///
        /// </summary>
     
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
     
        public Nullable<int> userId { get; set; }

        /// <summary>
        ///
        /// </summary>
     
        public string UserName { get; set; }

        /// <summary>
        ///
        /// </summary>
     
        public string ActionType { get; set; }

        /// <summary>
        ///
        /// </summary>
     
        public string Note { get; set; }

        /// <summary>
        ///
        /// </summary>
     
        public string LoginIp { get; set; }

        /// <summary>
        ///
        /// </summary>
     
        public Nullable<System.DateTime> LoginTime { get; set; }
    }
}
