using System.Web.Mvc;

namespace B2WTI.PCFTI.APRESENTACAO.Areas.Orcamento
{
    public class OrcamentoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Orcamento";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Orcamento_default",
                "Orcamento/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", area = "Orcamento", id = UrlParameter.Optional },
                new[] { "B2WTI.PCFTI.APRESENTACAO.Areas.Orcamento.Controllers" }
            );
        }
    }
}