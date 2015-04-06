namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PCFTI0001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acumulado",
                c => new
                    {
                        LancamentoId = c.Guid(nullable: false),
                        PeriodoMes = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Lancamento_LancamentoId = c.Guid(),
                    })
                .PrimaryKey(t => new { t.LancamentoId, t.PeriodoMes })
                .ForeignKey("dbo.Lancamento", t => t.Lancamento_LancamentoId)
                .ForeignKey("dbo.Lancamento", t => t.LancamentoId)
                .Index(t => t.LancamentoId)
                .Index(t => t.Lancamento_LancamentoId);
            
            CreateTable(
                "dbo.Lancamento",
                c => new
                    {
                        LancamentoId = c.Guid(nullable: false),
                        FornecedorId = c.Guid(nullable: false),
                        ResponsavelId = c.Guid(nullable: false),
                        Ano = c.Int(nullable: false),
                        TipoServicoId = c.Guid(),
                        TipoBlocoId = c.Guid(),
                        BlocoId = c.Guid(),
                        StatusId = c.Guid(),
                        TipoDePagamentoId = c.Guid(),
                    })
                .PrimaryKey(t => t.LancamentoId)
                .ForeignKey("dbo.Bloco", t => t.BlocoId)
                .ForeignKey("dbo.Fornecedor", t => t.FornecedorId)
                .ForeignKey("dbo.AnoCalendario", t => t.Ano)
                .ForeignKey("dbo.Responsavel", t => t.ResponsavelId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.TipoBloco", t => t.TipoBlocoId)
                .ForeignKey("dbo.TipoDePagamento", t => t.TipoDePagamentoId)
                .ForeignKey("dbo.TipoServico", t => t.TipoServicoId)
                .Index(t => t.FornecedorId)
                .Index(t => t.ResponsavelId)
                .Index(t => t.Ano)
                .Index(t => t.TipoServicoId)
                .Index(t => t.TipoBlocoId)
                .Index(t => t.BlocoId)
                .Index(t => t.StatusId)
                .Index(t => t.TipoDePagamentoId);
            
            CreateTable(
                "dbo.Backlog",
                c => new
                    {
                        LancamentoId = c.Guid(nullable: false),
                        PeriodoMes = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Lancamento_LancamentoId = c.Guid(),
                    })
                .PrimaryKey(t => new { t.LancamentoId, t.PeriodoMes })
                .ForeignKey("dbo.Lancamento", t => t.LancamentoId)
                .ForeignKey("dbo.Lancamento", t => t.Lancamento_LancamentoId)
                .Index(t => t.LancamentoId)
                .Index(t => t.Lancamento_LancamentoId);
            
            CreateTable(
                "dbo.Bloco",
                c => new
                    {
                        BlocoId = c.Guid(nullable: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BlocoId);
            
            CreateTable(
                "dbo.Caixa",
                c => new
                    {
                        LancamentoId = c.Guid(nullable: false),
                        PeriodoMes = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Lancamento_LancamentoId = c.Guid(),
                    })
                .PrimaryKey(t => new { t.LancamentoId, t.PeriodoMes })
                .ForeignKey("dbo.Lancamento", t => t.LancamentoId)
                .ForeignKey("dbo.Lancamento", t => t.Lancamento_LancamentoId)
                .Index(t => t.LancamentoId)
                .Index(t => t.Lancamento_LancamentoId);
            
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        FornecedorId = c.Guid(nullable: false),
                        CNPJ = c.String(maxLength: 20, unicode: false),
                        RazaoSocial = c.String(nullable: false, maxLength: 250, unicode: false),
                        NomeFantasia = c.String(maxLength: 250, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FornecedorId);
            
            CreateTable(
                "dbo.Orcado",
                c => new
                    {
                        LancamentoId = c.Guid(nullable: false),
                        PeriodoMes = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Lancamento_LancamentoId = c.Guid(),
                    })
                .PrimaryKey(t => new { t.LancamentoId, t.PeriodoMes })
                .ForeignKey("dbo.Lancamento", t => t.LancamentoId)
                .ForeignKey("dbo.Lancamento", t => t.Lancamento_LancamentoId)
                .Index(t => t.LancamentoId)
                .Index(t => t.Lancamento_LancamentoId);
            
            CreateTable(
                "dbo.AnoCalendario",
                c => new
                    {
                        Ano = c.Int(nullable: false, identity: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Ano);
            
            CreateTable(
                "dbo.Real",
                c => new
                    {
                        LancamentoId = c.Guid(nullable: false),
                        PeriodoMes = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Lancamento_LancamentoId = c.Guid(),
                    })
                .PrimaryKey(t => new { t.LancamentoId, t.PeriodoMes })
                .ForeignKey("dbo.Lancamento", t => t.LancamentoId)
                .ForeignKey("dbo.Lancamento", t => t.Lancamento_LancamentoId)
                .Index(t => t.LancamentoId)
                .Index(t => t.Lancamento_LancamentoId);
            
            CreateTable(
                "dbo.Responsavel",
                c => new
                    {
                        ResponsavelId = c.Guid(nullable: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ResponsavelId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Guid(nullable: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.TipoBloco",
                c => new
                    {
                        TipoBlocoId = c.Guid(nullable: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoBlocoId);
            
            CreateTable(
                "dbo.TipoDePagamento",
                c => new
                    {
                        TipoDePagamentoId = c.Guid(nullable: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoDePagamentoId);
            
            CreateTable(
                "dbo.TipoServico",
                c => new
                    {
                        TipoServicoId = c.Guid(nullable: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoServicoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Acumulado", "LancamentoId", "dbo.Lancamento");
            DropForeignKey("dbo.Lancamento", "TipoServicoId", "dbo.TipoServico");
            DropForeignKey("dbo.Lancamento", "TipoDePagamentoId", "dbo.TipoDePagamento");
            DropForeignKey("dbo.Lancamento", "TipoBlocoId", "dbo.TipoBloco");
            DropForeignKey("dbo.Lancamento", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Lancamento", "ResponsavelId", "dbo.Responsavel");
            DropForeignKey("dbo.Real", "Lancamento_LancamentoId", "dbo.Lancamento");
            DropForeignKey("dbo.Real", "LancamentoId", "dbo.Lancamento");
            DropForeignKey("dbo.Lancamento", "Ano", "dbo.AnoCalendario");
            DropForeignKey("dbo.Orcado", "Lancamento_LancamentoId", "dbo.Lancamento");
            DropForeignKey("dbo.Orcado", "LancamentoId", "dbo.Lancamento");
            DropForeignKey("dbo.Lancamento", "FornecedorId", "dbo.Fornecedor");
            DropForeignKey("dbo.Caixa", "Lancamento_LancamentoId", "dbo.Lancamento");
            DropForeignKey("dbo.Caixa", "LancamentoId", "dbo.Lancamento");
            DropForeignKey("dbo.Lancamento", "BlocoId", "dbo.Bloco");
            DropForeignKey("dbo.Backlog", "Lancamento_LancamentoId", "dbo.Lancamento");
            DropForeignKey("dbo.Backlog", "LancamentoId", "dbo.Lancamento");
            DropForeignKey("dbo.Acumulado", "Lancamento_LancamentoId", "dbo.Lancamento");
            DropIndex("dbo.Real", new[] { "Lancamento_LancamentoId" });
            DropIndex("dbo.Real", new[] { "LancamentoId" });
            DropIndex("dbo.Orcado", new[] { "Lancamento_LancamentoId" });
            DropIndex("dbo.Orcado", new[] { "LancamentoId" });
            DropIndex("dbo.Caixa", new[] { "Lancamento_LancamentoId" });
            DropIndex("dbo.Caixa", new[] { "LancamentoId" });
            DropIndex("dbo.Backlog", new[] { "Lancamento_LancamentoId" });
            DropIndex("dbo.Backlog", new[] { "LancamentoId" });
            DropIndex("dbo.Lancamento", new[] { "TipoDePagamentoId" });
            DropIndex("dbo.Lancamento", new[] { "StatusId" });
            DropIndex("dbo.Lancamento", new[] { "BlocoId" });
            DropIndex("dbo.Lancamento", new[] { "TipoBlocoId" });
            DropIndex("dbo.Lancamento", new[] { "TipoServicoId" });
            DropIndex("dbo.Lancamento", new[] { "Ano" });
            DropIndex("dbo.Lancamento", new[] { "ResponsavelId" });
            DropIndex("dbo.Lancamento", new[] { "FornecedorId" });
            DropIndex("dbo.Acumulado", new[] { "Lancamento_LancamentoId" });
            DropIndex("dbo.Acumulado", new[] { "LancamentoId" });
            DropTable("dbo.TipoServico");
            DropTable("dbo.TipoDePagamento");
            DropTable("dbo.TipoBloco");
            DropTable("dbo.Status");
            DropTable("dbo.Responsavel");
            DropTable("dbo.Real");
            DropTable("dbo.AnoCalendario");
            DropTable("dbo.Orcado");
            DropTable("dbo.Fornecedor");
            DropTable("dbo.Caixa");
            DropTable("dbo.Bloco");
            DropTable("dbo.Backlog");
            DropTable("dbo.Lancamento");
            DropTable("dbo.Acumulado");
        }
    }
}
