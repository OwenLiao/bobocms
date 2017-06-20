

/*******************************************************************************
引用
*******************************************************************************/

KindEditor.plugin('quote', function (K) {
    var self = this, name = 'quote';
    self.clickToolbar(name, function () {

        var a = self.selectedHtml();
        var newHtml = "<span class='quote' style='background-color:#F1F1F1;display:block'>"+a+"</span>"
        self.insertHtml(newHtml);
    });
});
