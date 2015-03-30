
namespace B2WTI.PCFTI.APLICACAO.SERVICO
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using System.Web.Http;
    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;

    public class WebApiApplication : System.Web.HttpApplication
    {
        public static void Register(HttpConfiguration config)
        {

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            #region Entidades Mapeadas ODATA

            builder.EntitySet<Fornecedor>("MinhaEntidade");
            //...

            #endregion

            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
