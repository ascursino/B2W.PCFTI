
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.DataMap
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TipoServicoMap : EntityTypeConfiguration<TipoServico>
    {
        public TipoServicoMap()
        {
            this.ToTable("TipoServico");

            this.HasKey(t => t.TipoServicoId);

            this.Property(t => t.TipoServicoId)
                .HasColumnName("TipoServicoId");

            this.Property(t => t.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar")
                .HasMaxLength(250);
               
            this.Property(t => t.Ativo)
                .HasColumnName("Ativo");
        }

    }
}
