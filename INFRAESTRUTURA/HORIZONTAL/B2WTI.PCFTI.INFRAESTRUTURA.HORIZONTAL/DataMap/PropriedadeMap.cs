
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.DataMap
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PropriedadeMap : EntityTypeConfiguration<Propriedade>
    {
        public PropriedadeMap()
        {
            this.ToTable("Propriedade");

            this.HasKey(t => t.Ano);
            
            this.Property(t => t.Ano)
                .HasColumnName("Ano");
            
            this.Property(t => t.Ativo)
            .HasColumnName("Ativo");
        }

    }
}
