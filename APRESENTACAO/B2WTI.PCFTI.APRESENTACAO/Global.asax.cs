
namespace B2WTI.PCFTI.APRESENTACAO
{
    using B2WTI.PCFTI.APRESENTACAO.App_Start;
    using B2WTI.PCFTI.APRESENTACAO.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            Aplicacao app = Aplicacao.Iniciar();
        }
    }
}