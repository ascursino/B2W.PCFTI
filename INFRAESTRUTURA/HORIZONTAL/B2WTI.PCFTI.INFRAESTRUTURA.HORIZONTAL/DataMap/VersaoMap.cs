
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.DataMap
{
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using System.Data.Entity.ModelConfiguration;

    public class VersaoMap : EntityTypeConfiguration<Versao>
    {
        public VersaoMap()
        {
            this.ToTable("Versao");

            this.HasKey(t => t.VersaoId);

            this.Property(t => t.VersaoId)
                .HasColumnName("VersaoId");

            this.Property(t => t.EnitdadeId)
                .HasColumnName("EnitdadeId")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            this.Property(t => t.Momento)
                .HasColumnName("Momento");

            this.Property(t => t.Operacao)
                .HasColumnName("Operacao")
                .HasColumnType("varchar")
                .HasMaxLength(3);

            this.Property(t => t.Promotor)
                .HasColumnName("Promotor")
                .HasColumnType("varchar")
                .HasMaxLength(150);

            this.Property(t => t.Entidade)
                .HasColumnName("Entidade")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            this.Property(t => t.Dados)
                .HasColumnName("Dados")
                .HasColumnType("varchar")
                .HasMaxLength(4000);
               
        }

    }
}
