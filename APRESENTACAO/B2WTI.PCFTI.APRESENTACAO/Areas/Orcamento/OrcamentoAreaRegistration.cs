﻿using System.Web.Mvc;

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
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}