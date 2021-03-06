﻿using System.Web.Mvc;

namespace B2WTI.PCFTI.APRESENTACAO.Areas.Cadastro
{
    public class CadastroAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Cadastro";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Cadastro_default",
                "Cadastro/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", area = "Cadastro", id = UrlParameter.Optional },
                new[] { "B2WTI.PCFTI.APRESENTACAO.Areas.Cadastro.Controllers" }
            );
        }
    }
}