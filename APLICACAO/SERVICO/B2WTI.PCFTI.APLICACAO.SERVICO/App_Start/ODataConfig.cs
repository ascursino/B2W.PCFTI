
namespace B2WTI.PCFTI.APLICACAO.SERVICO
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;

    public static class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var builder = new ODataConventionModelBuilder();

            #region Entidades Mapeadas ODATA

            builder.EntitySet<Fornecedor>("Fornecedor");
            //...
            

            #endregion

            config.MapODataServiceRoute(
                routeName: "odata",
                routePrefix: "odata",
                model: builder.GetEdmModel());


            config.EnableQuerySupport();

            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling =
                  Newtonsoft.Json.PreserveReferencesHandling.All;

        }
    }
}