
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.DataMap
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ResponsavelMap : EntityTypeConfiguration<Responsavel>
    {
        public ResponsavelMap()
        {
            this.ToTable("Responsavel");

            this.HasKey(t => t.ResponsavelId);
            
            this.Property(t => t.ResponsavelId)
                .HasColumnName("ResponsavelId");

            this.HasRequired(t => t.Usuario)
                .WithMany()
                .HasForeignKey(t => t.UsuarioId);
            
            this.Property(t => t.Ativo)
            .HasColumnName("Ativo");
        }

    }
}
