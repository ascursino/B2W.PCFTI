
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.DOMINIO.Model.Orcamento;
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.DataMap;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

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
            this.Configuration.LazyLoadingEnabled = false; 
        }

        //Cadastro
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Responsavel> Responsavel { get; set; }
        public DbSet<AnoCalendario> Propriedade { get; set; }
        public DbSet<TipoServico> TipoServico { get; set; }
        public DbSet<TipoBloco> TipoBloco { get; set; }
        public DbSet<Bloco> Bloco { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<TipoDePagamento> TipoDePagamento { get; set; }

        //Orcamento
        public DbSet<Lancamento> Lancamento { get; set; }
        public DbSet<Orcado> Orcado { get; set; }
        public DbSet<Backlog> Backlog { get; set; }
        public DbSet<Caixa> Caixa { get; set; }
        public DbSet<Real> Real { get; set; }
        public DbSet<Acumulado> Acumulado { get; set; }

        //Sistema
        public DbSet<Versao> Versao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Regra> Regra { get; set; }
        public DbSet<UsuarioRegra> UsuarioRegra { get; set; }

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

            modelBuilder.Properties<decimal>()
                .Configure(c => c.HasPrecision(18, 3));

            modelBuilder.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime"));


            //...........................

            //Cadastro
            modelBuilder.Configurations.Add(new AnoCalendarioMap());
            modelBuilder.Configurations.Add(new BlocoMap());
            modelBuilder.Configurations.Add(new FornecedorMap());
            modelBuilder.Configurations.Add(new ResponsavelMap());
            modelBuilder.Configurations.Add(new StatusMap());
            modelBuilder.Configurations.Add(new TipoBlocoMap());
            modelBuilder.Configurations.Add(new TipoDePagamentoMap());
            modelBuilder.Configurations.Add(new TipoServicoMap());

            //Orcamento
            modelBuilder.Configurations.Add(new LancamentoMap());
            modelBuilder.Configurations.Add(new AcumuladoMap());
            modelBuilder.Configurations.Add(new BacklogMap());
            modelBuilder.Configurations.Add(new RealMap());
            modelBuilder.Configurations.Add(new CaixaMap());
            modelBuilder.Configurations.Add(new OrcadoMap());
            
            //Sistema
            modelBuilder.Configurations.Add(new VersaoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new RegraMap());
            modelBuilder.Configurations.Add(new UsuarioRegraMap());
        }

    }
}
