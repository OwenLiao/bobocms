using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Model
{
    /// <summary>
    /// 添加或修改成功 返回到成功页面的model
    /// </summary>
    public class MessageModel
    {
        public MessageModel(string _title, string _controller,string _tabName)
        {
            this.title = _title;
            this.controller = _controller;
            this.tabName = _tabName;
        }
        /// <summary>
        /// 提示消息
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 继续添加的控制器名称
        /// </summary>
        public string controller { get; set; }

        /// <summary>
        /// 选项卡名称
        /// </summary>
        public string tabName { get; set; }
    }
}
