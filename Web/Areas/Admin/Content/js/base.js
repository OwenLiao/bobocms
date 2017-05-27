/// <reference path="base.js" />

//================添加、修改、删除===============
//添加
function add(title, url, param) {
    alert(url)
    window.parent.addTab(title, url + "?" + param, "icon-page");
}

//修改事件
function eidt(title, url, param) {
    var rows = $("#data_list").datagrid("getSelections");
    if (!rows || rows.length < 1) {
        $.messager.alert("提示", "请选择要修改的行!");
        return;
    }
    else if (rows.length != 1) {
        $.messager.alert("提示", "仅能选择一行!");
        return;
    }
    else {
        window.parent.addTab(title, url + "/" + rows[0].Id + "?" + param, "icon-page");
    }
}
//删除
function del() {
    var rows = $("#data_list").datagrid("getSelections");
    if (!rows || rows.length < 1) {
        $.messager.alert("提示", "未选择任何行!");
        return;
    }
    else if (rows.length > 0) {
        $.messager.confirm("确认", "您确定要删除所选行吗？", function (r) {
            if (r) {
                $.messager.progress();
                $.each(rows, function (index, value) {
                    $.ajax({
                        type: "post",
                        url: "Delete",
                        data: { id: value.Id },
                        async: false,
                        success: function (data) {
                        }
                    });
                });

                setTimeout(function () {
                    $.messager.progress('close');
                }, 100)

                //清除选择行
                rows.length = 0;
                $("#data_list").datagrid('reload');
            }
        });
        return;
    }
}

//================添加、修改、删除 结束===============

//================获取easyui datagrid里需要查询的字段，传到后台===============
//(function ($) {

//    $.fn.fieldSelect = function (attr) {
//        alert(1);
//        var str = Array();
//        if (attr != undefined) {
//            //循环增加属性值
//            $(this).each(function (index, e) {
//                var value = $(this).attr(attr);
//                //防止重复
//                if (jQuery.inArray(value, str) == -1)
//                    str.push(value);
//            });
//            str = str.join(",");
//        }
//        return str;
//    }
//})(jQuery);
//================获取easyui datagrid 字段结束===============





//================上传文件JS函数开始，需和jquery.form.js一起使用===============
//文件上传
function Upload(action, repath, uppath, iswater, isthumbnail, filepath) {
    var sendUrl = "/tools/upload_ajax.ashx?action=" + action + "&ReFilePath=" + repath + "&UpFilePath=" + uppath;
    //判断是否打水印
    if (arguments.length == 4) {
        sendUrl = "/tools/upload_ajax.ashx?action=" + action + "&ReFilePath=" + repath + "&UpFilePath=" + uppath + "&IsWater=" + iswater;
    }
    //判断是否生成宿略图
    if (arguments.length == 5) {
        sendUrl = "/tools/upload_ajax.ashx?action=" + action + "&ReFilePath=" + repath + "&UpFilePath=" + uppath + "&IsWater=" + iswater + "&IsThumbnail=" + isthumbnail;
    }
    //自定义上传路径
    if (arguments.length == 6) {
        sendUrl = filepath + "tools/upload_ajax.ashx?action=" + action + "&ReFilePath=" + repath + "&UpFilePath=" + uppath + "&IsWater=" + iswater + "&IsThumbnail=" + isthumbnail;
    }
    //开始提交
    $("#form1").ajaxSubmit({
        beforeSubmit: function (formData, jqForm, options) {

            //隐藏上传按钮
            $("#" + repath).nextAll(".files").eq(0).hide();
            //显示LOADING图片
            $("#" + repath).nextAll(".uploading").eq(0).show();
        },
        success: function (data, textStatus) {
            if (data.msg == 1) {
                $("#" + repath).val(data.msgbox);
            } else {
                alert(data.msgbox);
            }
            $("#" + repath).nextAll(".files").eq(0).show();
            $("#" + repath).nextAll(".uploading").eq(0).hide();
        },
        error: function (data, status, e) {
            alert("上传失败，错误信息：" + e);
            $("#" + repath).nextAll(".files").eq(0).show();
            $("#" + repath).nextAll(".uploading").eq(0).hide();
        },
        url: sendUrl,
        type: "post",
        dataType: "json",
        timeout: 600000
    });
};
//附件上传
function AttachUpload(repath, uppath) {
    var submitUrl = "/tools/upload_ajax.ashx?action=AttachFile&UpFilePath=" + uppath;
    //开始提交
    $("#form1").ajaxSubmit({
        beforeSubmit: function (formData, jqForm, options) {
            //隐藏上传按钮
            $("#" + uppath).parent().hide();
            //显示LOADING图片
            $("#" + uppath).parent().nextAll(".uploading").eq(0).show();
        },
        success: function (data, textStatus) {
            if (data.msg == 1) {
                var listBox = $("#" + repath + " ul");
                var newLi = '<li>'
                + '<input name="hidFileName" type="hidden" value="0|' + data.mstitle + "|" + data.msgbox + '" />'
                + '<b class="close" title="删除" onclick="DelAttachLi(this);"></b>'
                + '<span class="right">下载积分：<input name="txtPoint" type="text" class="input2" value="0" onkeydown="return checkNumber(event);" /></span>'
                + '<span class="title">附件：' + data.mstitle + '</span>'
                + '<span>人气：0</span>'
                + '<a href="javascript:;" class="upfile"><input type="file" name="FileUpdate" onchange="AttachUpdate(\'hidFileName\',this);" /></a>'
                + '<span class="uploading">正在更新...</span>'
                + '</li>';
                listBox.append(newLi);
                //alert(data.mstitle);
            } else {
                alert(data.msgbox);
            }
            $("#" + uppath).parent().show();
            $("#" + uppath).parent().nextAll(".uploading").eq(0).hide();
        },
        error: function (data, status, e) {
            alert("上传失败，错误信息：" + e);
            $("#" + uppath).parent().show();
            $("#" + uppath).parent().nextAll(".uploading").eq(0).hide();
        },
        url: submitUrl,
        type: "post",
        dataType: "json",
        timeout: 600000
    });
};
//更新附件上传
function AttachUpdate(repath, uppath) {
    var btnOldName = $(uppath).attr("name");
    var btnNewName = "NewFileUpdate";
    $(uppath).attr("name", btnNewName);
    var submitUrl = "/tools/upload_ajax.ashx?action=AttachFile&UpFilePath=" + btnNewName;
    //开始提交
    $("#form1").ajaxSubmit({
        beforeSubmit: function (formData, jqForm, options) {
            //隐藏上传按钮
            $(uppath).parent().hide();
            //显示LOADING图片
            $(uppath).parent().nextAll(".uploading").eq(0).show();
        },
        success: function (data, textStatus) {
            if (data.msg == 1) {
                var ArrFileName = $(uppath).parent().prevAll("input[name='" + repath + "']").val().split("|");
                $(uppath).parent().prevAll("input[name='" + repath + "']").val(ArrFileName[0] + "|" + data.mstitle + "|" + data.msgbox);
                $(uppath).parent().prevAll(".title").html("附件：" + data.mstitle);
            } else {
                alert(data.msgbox);
            }
            $(uppath).parent().show();
            $(uppath).parent().nextAll(".uploading").eq(0).hide();
            $(uppath).attr("name", btnOldName);
        },
        error: function (data, status, e) {
            alert("上传失败，错误信息：" + e);
            $(uppath).parent().show();
            $(uppath).parent().nextAll(".uploading").eq(0).hide();
            $(uppath).attr("name", btnOldName);
        },
        url: submitUrl,
        type: "post",
        dataType: "json",
        timeout: 600000
    });
};
//===========================上传文件JS函数结束================================