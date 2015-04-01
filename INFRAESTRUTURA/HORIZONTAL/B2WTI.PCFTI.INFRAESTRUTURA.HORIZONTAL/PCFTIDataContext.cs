
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL
{
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.DataMap;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using B2WTI.PCFTI.DOMINIO.Model.Orcamento;

    public partial class PCFTIDataContext : DataContext
    {
        const string ConnectionName = "Name=PCFTIDB";
        static PCFTIDataContext() 
        {
            Database.SetInitializer<PCFTIDataContext>(null);
        }

        public PCFTIDataContext()
            : base(ConnectionName)
        {
        }

        public DbSet<Lancamento> Lancamento { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Responsavel> Responsavel { get; set; }
        public DbSet<Propriedade> Propriedade { get; set; }
        public DbSet<TipoServico> TipoServico { get; set; }
        public DbSet<TipoBloco> TipoBloco { get; set; }
        public DbSet<Bloco> Bloco { get; set; }

        public DbSet<Status> Status { get; set; }
        public DbSet<TipoDePagamento> TipoDePagamento { get; set; }
        public DbSet<Orcado> Orcado { get; set; }
        public DbSet<Backlog> Backlog { get; set; }
        public DbSet<Caixa> Caixa { get; set; }
        public DbSet<Real> Real { get; set; }
        public DbSet<Acumulado> Acumulado { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
               .Where(p => p.Name == p.ReflectedType.Name + "Id")
               .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(250));

            modelBuilder.Configurations.Add(new FornecedorMap());
        }

    }
}
