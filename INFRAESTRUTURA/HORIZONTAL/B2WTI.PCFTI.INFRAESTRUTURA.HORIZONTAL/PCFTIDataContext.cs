﻿
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL
{
    using DataMap;
    using DOMINIO.Model.Global;
    using DOMINIO.Model.Orcamento;
    using DOMINIO.Model.Sistema;
    using Migrations;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using TRANSVERSAL.DataContexts;

    public partial class PCFTIDataContext : DataContext
    {
        const string ConnectionName = "Name=PCFTIDB";
        
        static PCFTIDataContext() 
        {
        }

        public PCFTIDataContext()
            : base(ConnectionName)
        {
            //string cnn = this.Database.Connection.ConnectionString;
            Database.SetInitializer<PCFTIDataContext>(new MigrateDatabaseToLatestVersion<PCFTIDataContext, Configuration>()); 
        }

        public ObjectContext ObjectContext
        {
            get
            {
                return ((IObjectContextAdapter)this).ObjectContext;
            }
        }

        private static readonly Object syncObj = new Object();
        public static bool InitializeDatabase()
        {
            lock (syncObj)
            {
                using (var temp = new PCFTIDataContext())
                {
                    if (temp.Database.Exists()) return true;

                    var initializer = new MigrateDatabaseToLatestVersion<PCFTIDataContext, Configuration>();
                    Database.SetInitializer(initializer);
                    try
                    {
                        temp.Database.Initialize(true);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
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

            //...........................

            base.OnModelCreating(modelBuilder);
        }

    }
}
