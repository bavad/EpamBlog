using System.Collections.Generic;
using System.Web.Mvc;

namespace EpamPractice1.Helpers
{
    public static class ListHelper
    {
        public static MvcHtmlString CreateList(this HtmlHelper html, IDictionary<int, string> items)
        {
            TagBuilder ul = new TagBuilder("ul");
            foreach (var item in items)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder input = new TagBuilder("input");
                TagBuilder label = new TagBuilder("label");

                input.MergeAttribute("type", "checkbox");
                input.MergeAttribute("id", "check" + item.Key);
                input.MergeAttribute("name", "articleId");
                input.MergeAttribute("value", item.Key.ToString());
                
                label.MergeAttribute("for", "check" + item.Key);
                label.SetInnerText(item.Value);

                li.InnerHtml += input.ToString(TagRenderMode.SelfClosing);
                li.InnerHtml += label.ToString();
                ul.InnerHtml += li.ToString();
            }
            return new MvcHtmlString(ul.ToString());
        }
    }
}