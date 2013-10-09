using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;

namespace EbayApplication.Web.HelperExtensions
{
    public static class Extensions
    {
        public static MvcHtmlString Pager<T>(this HtmlHelper helper,
            int pageLinks, IPagedList<T> pagedList, string actionName, object routeParams = null)
        {
            Type type = null;
            IList<PropertyInfo> routeProps = new List<PropertyInfo>();

            if (routeParams != null)
            {
                type = routeParams.GetType();
                routeProps = new List<PropertyInfo>(type.GetProperties());
            }

            int pagesCount = pagedList.PageCount;
            if (pagesCount < pageLinks)
            {
                pageLinks = pagesCount;
            }

            int activePage = pagesCount > 0 ? pagedList.PageNumber : 0;

            int leftPagerLinks = (pageLinks / 2);
            int rightPagerLinks = pageLinks - leftPagerLinks;

            StringBuilder html = new StringBuilder();
            html.AppendFormat("<div class='lead'>Page {0} of {1}</div>", activePage, pagesCount);
            //html.Append("<div class='pagination pagination-large'>");
            html.Append("<ul>");

            if (activePage != 1)
            {
                int page = 1;
                html.AppendFormat("<li><a href='{0}?page={1}", actionName, page);
                foreach (var prop in routeProps)
                {
                    if (prop.Name != "page")
                    {
                        html.AppendFormat("&{0}={1}", prop.Name, prop.GetValue(routeParams));
                    }
                }

                html.AppendFormat("'>&laquo;</a></li>", actionName);
            }
            else
            {
                html.Append("<li class='active'><a>&laquo;</a></li>");
            }

            if (activePage >= 1 && activePage <= leftPagerLinks)
            {
                for (int i = 1; i < pageLinks + 1; i++)
                {
                    GeneratePageButton(activePage, i, actionName, html, routeProps, routeParams);
                }
            }
            else if (activePage > leftPagerLinks && pagesCount - activePage >= rightPagerLinks)
            {
                for (int i = activePage - leftPagerLinks; i < activePage + rightPagerLinks; i++)
                {
                    GeneratePageButton(activePage, i, actionName, html, routeProps, routeParams);
                }
            }
            else if (pagesCount - activePage < rightPagerLinks)
            {
                for (int i = pagesCount - pageLinks + 1; i < pagesCount + 1; i++)
                {
                    GeneratePageButton(activePage, i, actionName, html, routeProps, routeParams);
                }
            }

            if (pagesCount >= pageLinks && activePage != pagesCount)
            {
                int page = pagesCount;
                html.AppendFormat("<li><a href='{0}?page={1}", actionName, page);
                foreach (var prop in routeProps)
                {
                    if (prop.Name != "page")
                    {
                        html.AppendFormat("&{0}={1}", prop.Name, prop.GetValue(routeParams));
                    }
                }

                html.AppendFormat("'>&raquo;</a></li>", actionName);
            }
            else
            {
                html.Append("<li class='active'><a>&raquo;</a></li>");
            }

            html.Append("</ul>");
            //html.Append("</div>");

            return new MvcHtmlString(html.ToString());
        }
  
        private static void GeneratePageButton(int activePage, int currentPage, string actionName, StringBuilder html, IList<PropertyInfo> routeProps, object routeParams)
        {
            if (activePage != currentPage)
            {
                html.AppendFormat("<li><a href='{0}?page={1}", actionName, currentPage);
                foreach (var prop in routeProps)
                {
                    if (prop.Name != "page")
                    {
                        html.AppendFormat("&{0}={1}", prop.Name, prop.GetValue(routeParams));
                    }
                }

                html.AppendFormat("'>{0}</a></li>", currentPage);
            }
            else
            {
                html.AppendFormat("<li class='active'><a>{0}</a></li>", currentPage);
            }
        }
    }
}