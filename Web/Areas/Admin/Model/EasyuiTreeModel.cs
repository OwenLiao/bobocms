using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Model
{
    /// <summary>
    /// Easyui Tree Model
    /// </summary>
  public  class EasyuiTreeModel
    {
        public int id { get; set; }//节点的id值
      public string text { get; set; }//节点显示的名称
      public string state { get; set; }//节点的状态

      // 请在整个树转换成jsonString时,将字符串Checked换成checked，否则easyui不认
      public bool Checked { get; set; } //注意：转成JsonTreeString时，将"Checked"替换成"checked",否则选中效果出不来的
      public List<EasyuiTreeModel> children { get; set; }//集合属性，可以保存子节点
    }
}
