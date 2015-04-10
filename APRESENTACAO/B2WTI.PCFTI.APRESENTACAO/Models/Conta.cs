
namespace B2WTI.PCFTI.APRESENTACAO.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Conta
    {
        public Guid UsuarioId { get; set; }
        public string ContaWindows { get; set; }
        public string Nome { get; set; }
        public List<string> Regras { get; set; }

        public bool Permitir(string regra)
        {
            bool ret = false;

            if (Regras != null)
                if (Regras.Count() > 0)
                    ret = (from item in Regras 
                           where item.Equals(regra) 
                           select item)
                           .Count() > 0;

            return ret;
        }

    }
}