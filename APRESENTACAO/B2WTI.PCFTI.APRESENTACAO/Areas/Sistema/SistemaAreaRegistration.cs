using System.Web.Mvc;

namespace B2WTI.PCFTI.APRESENTACAO.Areas.Sistema
{
    public class SistemaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Sistema";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Sistema_default",
                "Sistema/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", area = "Sistema", id = UrlParameter.Optional },
                new[] { "B2WTI.PCFTI.APRESENTACAO.Areas.Sistema.Controllers" }
            );
        }
    }
}