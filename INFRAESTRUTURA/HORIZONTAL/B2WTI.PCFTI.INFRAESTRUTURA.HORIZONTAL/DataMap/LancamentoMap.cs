


namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.DataMap
{
    using B2WTI.PCFTI.DOMINIO.Model.Orcamento;
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LancamentoMap : EntityTypeConfiguration<Lancamento>
    {
        public LancamentoMap()
        {
            this.ToTable("Lancamento");

            this.HasKey(t => t.LancamentoId);

            this.Property(t => t.LancamentoId)
                .HasColumnName("LancamentoId");


        }

    }
}
