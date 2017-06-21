
using System;
using System.Collections.Generic;

namespace Model
{

    public partial class ManagerRole
    {
        public ManagerRole()
        {
            this.Managers = new List<Manager>();
            this.ManagerRoleValues = new List<ManagerRoleValue>();
        }


        /// <summary>
        ///
        /// </summary>

        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>

        public string RoleName { get; set; }

        /// <summary>
        ///
        /// </summary>

        public Nullable<int> RoleType { get; set; }
        
        public virtual ICollection<Manager> Managers { get; set; }

        
        public virtual ICollection<ManagerRoleValue> ManagerRoleValues { get; set; }
    }
}
