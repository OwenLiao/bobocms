
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{

    public partial class Manager
    {
        public Manager()
        {
            this.AddTime = DateTime.Now;
        }

        /// <summary>ss
        ///
        /// </summary>

        public int Id { get; set; }

        /// <summay>
        ///½ÇÉ«id
        /// </summary>
        [Display(Name = "½ÇÉ«")]
        [Required]
        public int roleId { get; set; }

        /// <summary>
        ///
        /// </summary>

        public Nullable<int> RoleType { get; set; }

        /// <summary>
        ///ÕÊºÅ
        /// </summary>
        [Display(Name = "ÕÊºÅ")]
        [Required]
        public string UserName { get; set; }

        /// <summary>
        ///ÃÜÂë
        /// </summary>
        [Display(Name = "ÃÜÂë")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "ÖÁÉÙ{2}¸ö×Ö·û")]
        [Required]
        public string UserPwd { get; set; }

        /// <summary>
        ///ĞÕÃû
        /// </summary>
        [Display(Name = "ĞÕÃû")]
        public string RealName { get; set; }

        /// <summary>
        ///
        /// </summary>

        public string Telephone { get; set; }

        /// <summary>
        ///
        /// </summary>

        public string Email { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "×´Ì¬")]
        public Nullable<int> IsLock { get; set; }

        /// <summary>
        ///
        /// </summary>

        public Nullable<System.DateTime> AddTime { get; set; }

        
        public virtual ManagerRole ManagerRole { get; set; }
    }
}
