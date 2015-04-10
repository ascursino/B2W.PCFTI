
namespace B2WTI.PCFTI.DOMINIO.Model.Sistema
{
    using System;
    using System.Collections.Generic;

    public class UsuarioRegra : CadastroBase
    {

        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public Guid RegraId { get; set; }
        public virtual Regra Regra { get; set; }

    }
}
