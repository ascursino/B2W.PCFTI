
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.DataMap
{
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using System.Data.Entity.ModelConfiguration;

    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            this.ToTable("Usuario");

            this.HasKey(t => t.UsuarioId);

            this.Property(t => t.UsuarioId)
                .HasColumnName("UsuarioId");

            this.Property(t => t.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(150);

            this.Property(t => t.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(150);

            this.Property(t => t.LoginWindows)
                .IsOptional()
                .HasColumnName("LoginWindows")
                .HasColumnType("varchar")
                .HasMaxLength(100);
            
            this.Property(t => t.Ativo)
            .HasColumnName("Ativo");
        }

    }
}
