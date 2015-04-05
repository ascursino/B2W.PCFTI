
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
            if (helper.ViewContext.RouteData.Values["controller"].ToString() == "Home" ||
                helper.ViewContext.RouteData.Values["controller"].ToString() == "Account")
            {
                return "<h2>PCFTI</h2><ol class=\"breadcrumb\"><li>Início</li></ol>";
            }

            string Area = helper.ViewContext.RouteData.Values["area"].ToString();

            StringBuilder breadcrumb = new StringBuilder("<h2>" + helper.ViewContext.RouteData.Values["controller"].ToString().Titleize() + "</h2><ol class=\"breadcrumb\"><li>").Append(helper.ActionLink("PCFTI", "Index", "Home", new { Area = "" }, new { }).ToHtmlString()).Append("</li>");

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

        public static string BuildTitle(this HtmlHelper helper)
        {
            if (helper.ViewContext.RouteData.Values["controller"].ToString() == "Home" ||
                helper.ViewContext.RouteData.Values["controller"].ToString() == "Account")
            {
                return "PCFTI";
            }

            string Area = helper.ViewContext.RouteData.Values["area"].ToString();

            StringBuilder title = new StringBuilder("").Append("PCFTI").Append("");

            if (helper.ViewContext.RouteData.Values["area"].ToString() != "")
            {
                title.Append(" - " + helper.ViewContext.RouteData.Values["area"].ToString().Titleize());
            }

            title.Append(" - " + helper.ViewContext.RouteData.Values["controller"].ToString().Titleize());

            if (helper.ViewContext.RouteData.Values["action"].ToString() != "Index")
            {

                title.Append(" - " + helper.ViewContext.RouteData.Values["action"].ToString().Titleize());
            }

            return title.ToString();
        }
    }
}