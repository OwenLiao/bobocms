


namespace EfSearchModel.Binders
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.Threading.Tasks;
    using System.Text.Encodings.Web;
    using Microsoft.AspNetCore.Mvc.Internal;

    /// <summary>
    /// 对SearchModel做为Action参数的绑定
    /// </summary>
    public class SearchModelBinder : Controller,IModelBinder
    {


        private readonly IModelBinder _fallbackBinder;

        public SearchModelBinder(IModelBinder fallbackBinder)
        {
            if (fallbackBinder == null)
                throw new ArgumentNullException(nameof(fallbackBinder));

            _fallbackBinder = fallbackBinder;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult.Length > 0)
            {
                var valueAsString = valueProviderResult.FirstValue;

                if (string.IsNullOrEmpty(valueAsString))
                {
                    return _fallbackBinder.BindModelAsync(bindingContext);
                }

                var result = HtmlEncoder.Default.Encode(valueAsString);
                bindingContext.Result = ModelBindingResult.Success(result);
            }

            return TaskCache.CompletedTask;
        }
        //public Task<object> BindModelAsync(ModelBindingContext bindingContext)
        //{
        //    //  ControllerContext controllerContext,
        //    var model = (QueryModel)(bindingContext.Model ?? new QueryModel());
        //    var dict = HttpContext.Items;
        //    var keys = dict.Where(c => c.ToString().StartsWith("["));//我们认为只有[开头的为需要处理的
        //    if (keys.Count() != 0)
        //    {
        //        foreach (var key in keys)
        //        {
        //            if (!key.ToString().StartsWith("[")) continue;
        //            var val = dict[key];
        //            //处理无值的情况
        //            if (string.IsNullOrEmpty(val.ToString())) continue;
        //            AddSearchItem(model, key.ToString(), val.ToString());
        //        }
        //    }
        //    return model;
        //}

        ///// <summary>
        ///// 将一组key=value添加入QueryModel.Items
        ///// </summary>
        ///// <param name="model">QueryModel</param>
        ///// <param name="key">当前项的HtmlName</param>
        ///// <param name="val">当前项的值</param>
        //public static void AddSearchItem(QueryModel model, string key, string val)
        //{
        //    string field = "", prefix = "", orGroup = "", method = "";
        //    var keywords = key.Split(']', ')', '}');
        //    //将Html中的name分割为我们想要的几个部分
        //    foreach (var keyword in keywords)
        //    {
        //        if (Char.IsLetterOrDigit(keyword[0])) field = keyword;
        //        var last = keyword.Substring(1);
        //        if (keyword[0] == '(') prefix = last;
        //        if (keyword[0] == '[') method = last;
        //        if (keyword[0] == '{') orGroup = last;       
        //    }
        //    if (string.IsNullOrEmpty(method)) return;
        //    if (!string.IsNullOrEmpty(field))
        //    {
        //        var item = new ConditionItem
        //                       {
        //                           Field = field,
        //                           Value = val.Trim(),
        //                           Prefix = prefix,
        //                           OrGroup = orGroup,
        //                           Method = (QueryMethod) Enum.Parse(typeof (QueryMethod), method)
        //                       };
        //        model.Items.Add(item);
        //    }
        //}
    }
}
