/*******************************************************************************
取消引用
*******************************************************************************/

KindEditor.plugin('unquote', function (K) {
    var self = this, name = 'unquote';
    self.clickToolbar(name, function () {

        var self = this, doc = self.doc, range = self.range;
        alert(doc)
        alert(range)
        self.select();
        if (range.collapsed) {
            var a = self.commonNode({ a: '*' });
            if (a) {
                range.selectNode(a.get());
                self.select();
            }
            _nativeCommand(doc, 'unlink', null);
            if (_WEBKIT && K(range.startContainer).name === 'img') {
                var parent = K(range.startContainer).parent();
                if (parent.name === 'a') {
                    parent.remove(true);
                }
            }
        } else {
            _nativeCommand(doc, 'unlink', null);
        }
        return self;



        var a = self.selectedHtml();
        var b = self.extractContents()
        alert(b)
        // self.replaceWith(a);
    });
});
