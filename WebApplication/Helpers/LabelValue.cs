using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebApplication.Helpers
{
    public static class LabelValueHelper
    {
        public static MvcHtmlString LabelValue<TModel>(this HtmlHelper<TModel> helper, object value, IDictionary<string, object> htmlAttributes)
        {
            TagBuilder tag = new TagBuilder("label");
            tag.Attributes.Add("for", value.ToString());
            tag.SetInnerText(value.ToString());
            tag.MergeAttributes(htmlAttributes, replaceExisting: true);
            Dictionary<string, object> dict = new Dictionary<string, object>() { {"asd", "dfg"}};
            return new MvcHtmlString(tag.ToString(TagRenderMode.Normal));
        }
    }
}