
namespace B2WTI.PCFTI.APLICACAO.SERVICO
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            #region Entidades Mapeadas ODATA

            builder.EntitySet<Fornecedor>("Fornecedor");
            //...

            #endregion

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "odata",
                model: builder.GetEdmModel());
            
        }
    }
}
