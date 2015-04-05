
namespace B2WTI.PCFTI.APRESENTACAO.Views.Helpers
{
    using B2WTI.PCFTI.APRESENTACAO.Extensions;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class ApplicationHelpers
    {
        public static string BuildBreadcrumbNavigation(this HtmlHelper helper)
        {
            // optional condition: I didn't wanted it to show on home and account controller
            if (helper.ViewContext.RouteData.Values["controller"].ToString() == "Home" ||
                helper.ViewContext.RouteData.Values["controller"].ToString() == "Account")
            {
                return string.Empty;
            }

            string Area = helper.ViewContext.RouteData.Values["area"].ToString();

            StringBuilder breadcrumb = new StringBuilder("<h2>" + helper.ViewContext.RouteData.Values["controller"].ToString().Titleize() + "</h2><ol class=\"breadcrumb\"><li>").Append(helper.ActionLink("Home", "Index", "Home", new { Area = "" }, new { }).ToHtmlString()).Append("</li>");

            if (helper.ViewContext.RouteData.Values["area"].ToString() != "")
            {
                breadcrumb.Append("<li>");
                breadcrumb.Append(helper.ActionLink(helper.ViewContext.RouteData.Values["area"].ToString().Titleize(),
                    "", "",
                   new { Area = Area }, new { }));
                breadcrumb.Append("</li>");
            }

            breadcrumb.Append("<li>");
            breadcrumb.Append(helper.ActionLink(helper.ViewContext.RouteData.Values["controller"].ToString().Titleize(), "Index", helper.ViewContext.RouteData.Values["controller"].ToString()));
            breadcrumb.Append("</li>");

            if (helper.ViewContext.RouteData.Values["action"].ToString() != "Index")
            {
                breadcrumb.Append("<li>");
                breadcrumb.Append(helper.ActionLink(helper.ViewContext.RouteData.Values["action"].ToString().Titleize(),
                                                    helper.ViewContext.RouteData.Values["action"].ToString(),
                                                    helper.ViewContext.RouteData.Values["controller"].ToString()));
                breadcrumb.Append("</li>");
            }

            return breadcrumb.Append("</ol>").ToString();
        }
    }
}