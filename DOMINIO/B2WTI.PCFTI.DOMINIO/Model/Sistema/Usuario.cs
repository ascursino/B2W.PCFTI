
namespace B2WTI.PCFTI.DOMINIO.Model.Sistema
{
    using System;
    using System.Collections.Generic;

    public class Usuario : CadastroBase
    {

        public Guid UsuarioId { get; set; }
        public string LoginWindows { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Regra> Regras { get; set; }

    }
}
