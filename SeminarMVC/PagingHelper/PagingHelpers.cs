using SeminarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SeminarMVC.PagingHelper
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html , PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            for(int i=1; i <= pagingInfo.TotalPage; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                TagBuilder li = new TagBuilder("li");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if(i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("active");
                    tag.AddCssClass("act");
                    tag.AddCssClass("btn-primary");
                }

                tag.AddCssClass("btn btn-outline-secondary nonact");
                li.InnerHtml = tag.ToString() ;
                result.Append(li);
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}