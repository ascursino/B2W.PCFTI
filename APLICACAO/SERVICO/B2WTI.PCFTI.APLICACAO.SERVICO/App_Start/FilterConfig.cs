using System.Web;
using System.Web.Mvc;

namespace B2WTI.PCFTI.APLICACAO.SERVICO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
