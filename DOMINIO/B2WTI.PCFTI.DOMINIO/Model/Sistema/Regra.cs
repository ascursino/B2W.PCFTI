
namespace B2WTI.PCFTI.DOMINIO.Model.Sistema
{
    using System;
    using System.Collections.Generic;

    public class Regra : CadastroBase
    {

        public Guid RegraId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

    }
}
