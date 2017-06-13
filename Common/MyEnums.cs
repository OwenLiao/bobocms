
namespace Common
{
    public class MyEnums
    {
     

        //
        // 摘要:
        //     统一管理操作枚举
        public enum ActionEnum
        {
            //
            // 摘要:
            //     所有
            All = 0,
            //
            // 摘要:
            //     查看
            View = 1,
            //
            // 摘要:
            //     添加
            Add = 2,
            //
            // 摘要:
            //     修改
            Edit = 3,
            //
            // 摘要:
            //     删除
            Delete = 4,
            //
            // 摘要:
            //     审核
            Audit = 5,
            //
            // 摘要:
            //     回复
            Reply = 6,
            //
            // 摘要:
            //     取消
            Cancel = 7,
            //
            // 摘要:
            //     作废
            Invalid = 8
        }
        public enum AlertMessage
        {
            //
            // 摘要:
            //     警告提示
            AlertWarning = 0,
            //
            // 摘要:
            //     成功提示
            AlertSuccess = 1
        }
        //
        // 摘要:
        //     金额类型枚举
        public enum AmountTypeEnum
        {
            //
            // 摘要:
            //     系统赠送
            SysGive = 0,
            //
            // 摘要:
            //     在线充值
            Recharge = 1,
            //
            // 摘要:
            //     用户消费
            Consumption = 2,
            //
            // 摘要:
            //     购买商品
            BuyGoods = 3,
            //
            // 摘要:
            //     积分兑换
            Convert = 4
        }
        //
        // 摘要:
        //     属性类型枚举
        public enum AttributeEnum
        {
            //
            // 摘要:
            //     输入框
            Text = 0,
            //
            // 摘要:
            //     下拉框
            Select = 1,
            //
            // 摘要:
            //     单选框
            Radio = 2,
            //
            // 摘要:
            //     复选框
            CheckBox = 3
        }
        //
        // 摘要:
        //     用户生成码枚举
        public enum CodeEnum
        {
            //
            // 摘要:
            //     邮箱验证注册
            RegVerify = 0,
            //
            // 摘要:
            //     邀请注册
            Register = 1,
            //
            // 摘要:
            //     取回密码
            Password = 2,
            //
            // 摘要:
            //     订阅邮件验证
            EmailSub = 3,
            //
            // 摘要:
            //     修改注册邮箱
            UpdateEmail = 4
        }
        public enum MessageTypeEnum
        {
            //
            // 摘要:
            //     系统消息
            Sys = 0,
            //
            // 摘要:
            //     收件箱
            Accept = 1,
            //
            // 摘要:
            //     发件箱
            Send = 2
        }
        //
        // 摘要:
        //     付款方式
        public enum PayType
        {
            //
            // 摘要:
            //     支付宝
            Alipay = 1,
            //
            // 摘要:
            //     银联
            Chinapay = 2,
            //
            // 摘要:
            //     移动付款
            Mobilepay = 3,
            //
            // 摘要:
            //     货到付款
            Arrivalpay = 4,
            //
            // 摘要:
            //     线下付款
            Xianpay = 5
        }
    }
}