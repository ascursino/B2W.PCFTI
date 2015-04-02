


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

            this.HasRequired(t => t.Fornecedor)
                .WithMany()
                .HasForeignKey(t => t.FornecedorId);

            this.HasRequired(t => t.Responsavel)
                .WithMany()
                .HasForeignKey(t => t.ResponsavelId);

            this.HasRequired(t => t.Propriedade)
                .WithMany()
                .HasForeignKey(t => t.Ano);

            this.HasOptional(t => t.TipoServico)
                .WithMany()
                .HasForeignKey(t => t.TipoServicoId);

            this.HasOptional(t => t.TipoBloco)
                .WithMany()
                .HasForeignKey(t => t.TipoBlocoId);
            
            this.HasOptional(t => t.Bloco)
                .WithMany()
                .HasForeignKey(t => t.BlocoId);

            this.HasOptional(t => t.Status)
                .WithMany()
                .HasForeignKey(t => t.StatusId);

            this.HasOptional(t => t.TipoDePagamento)
                .WithMany()
                .HasForeignKey(t => t.TipoDePagamentoId);

        }

    }
}
