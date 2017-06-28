
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{

    public partial class SysChannel
    {
        public SysChannel()
        {
            this.ManagerRoleValues = new List<ManagerRoleValue>();
           // this.parentId = 0;
            this.SortId = 99;
        }


        /// <summary>
        ///
        /// </summary>

        public int Id { get; set; }


        /// <summary>
        ///频道名称
        /// </summary>
        [Required]
        [Display(Name = "频道名称")]
        public string Name { get; set; }

        /// <summary>
        ///频道标题
        /// </summary>
        [Required]
        [Display(Name = "频道标题")]
        public string Title { get; set; }

        /// <summary>
        ///上级频道
        /// </summary>
        [Display(Name = "上级频道")]
        public Nullable<int> parentId { get; set; }

        public SysChannel Parent { get; set; }
        public ICollection<SysChannel> Children { get; set; }

        /// <summary>
        ///管理地址
        /// </summary>
        [Display(Name = "管理地址")]
        public string LinkUrl { get; set; }

        /// <summary>
        ///
        /// </summary>

        public string ImgUrl { get; set; }

        /// <summary>
        ///
        /// </summary>

        public string Description { get; set; }

        /// <summary>
        ///排序
        /// </summary>
        [Display(Name = "排序")]
        [Required]
        public Nullable<int> SortId { get; set; }


        public virtual ICollection<ManagerRoleValue> ManagerRoleValues { get; set; }

    }
}
