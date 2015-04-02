namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PCFTIDB0002 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Backlog");
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
                "dbo.Propriedade",
                c => new
                    {
                        Ano = c.Int(nullable: false, identity: true),
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
            
            AddColumn("dbo.Lancamento", "FornecedorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Lancamento", "ResponsavelId", c => c.Guid(nullable: false));
            AddColumn("dbo.Lancamento", "Ano", c => c.Int(nullable: false));
            AddColumn("dbo.Lancamento", "TipoServicoId", c => c.Guid());
            AddColumn("dbo.Lancamento", "TipoBlocoId", c => c.Guid());
            AddColumn("dbo.Lancamento", "BlocoId", c => c.Guid());
            AddColumn("dbo.Lancamento", "StatusId", c => c.Guid());
            AddColumn("dbo.Lancamento", "TipoDePagamentoId", c => c.Guid());
            AddPrimaryKey("dbo.Backlog", new[] { "LancamentoId", "PeriodoMes" });
            CreateIndex("dbo.Lancamento", "FornecedorId");
            CreateIndex("dbo.Lancamento", "ResponsavelId");
            CreateIndex("dbo.Lancamento", "Ano");
            CreateIndex("dbo.Lancamento", "TipoServicoId");
            CreateIndex("dbo.Lancamento", "TipoBlocoId");
            CreateIndex("dbo.Lancamento", "BlocoId");
            CreateIndex("dbo.Lancamento", "StatusId");
            CreateIndex("dbo.Lancamento", "TipoDePagamentoId");
            AddForeignKey("dbo.Lancamento", "BlocoId", "dbo.Bloco", "BlocoId");
            AddForeignKey("dbo.Lancamento", "FornecedorId", "dbo.Fornecedor", "FornecedorId");
            AddForeignKey("dbo.Lancamento", "Ano", "dbo.Propriedade", "Ano");
            AddForeignKey("dbo.Lancamento", "ResponsavelId", "dbo.Responsavel", "ResponsavelId");
            AddForeignKey("dbo.Lancamento", "StatusId", "dbo.Status", "StatusId");
            AddForeignKey("dbo.Lancamento", "TipoBlocoId", "dbo.TipoBloco", "TipoBlocoId");
            AddForeignKey("dbo.Lancamento", "TipoDePagamentoId", "dbo.TipoDePagamento", "TipoDePagamentoId");
            AddForeignKey("dbo.Lancamento", "TipoServicoId", "dbo.TipoServico", "TipoServicoId");
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
            DropForeignKey("dbo.Lancamento", "Ano", "dbo.Propriedade");
            DropForeignKey("dbo.Orcado", "Lancamento_LancamentoId", "dbo.Lancamento");
            DropForeignKey("dbo.Orcado", "LancamentoId", "dbo.Lancamento");
            DropForeignKey("dbo.Lancamento", "FornecedorId", "dbo.Fornecedor");
            DropForeignKey("dbo.Caixa", "Lancamento_LancamentoId", "dbo.Lancamento");
            DropForeignKey("dbo.Caixa", "LancamentoId", "dbo.Lancamento");
            DropForeignKey("dbo.Lancamento", "BlocoId", "dbo.Bloco");
            DropForeignKey("dbo.Acumulado", "Lancamento_LancamentoId", "dbo.Lancamento");
            DropIndex("dbo.Real", new[] { "Lancamento_LancamentoId" });
            DropIndex("dbo.Real", new[] { "LancamentoId" });
            DropIndex("dbo.Orcado", new[] { "Lancamento_LancamentoId" });
            DropIndex("dbo.Orcado", new[] { "LancamentoId" });
            DropIndex("dbo.Caixa", new[] { "Lancamento_LancamentoId" });
            DropIndex("dbo.Caixa", new[] { "LancamentoId" });
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
            DropPrimaryKey("dbo.Backlog");
            DropColumn("dbo.Lancamento", "TipoDePagamentoId");
            DropColumn("dbo.Lancamento", "StatusId");
            DropColumn("dbo.Lancamento", "BlocoId");
            DropColumn("dbo.Lancamento", "TipoBlocoId");
            DropColumn("dbo.Lancamento", "TipoServicoId");
            DropColumn("dbo.Lancamento", "Ano");
            DropColumn("dbo.Lancamento", "ResponsavelId");
            DropColumn("dbo.Lancamento", "FornecedorId");
            DropTable("dbo.TipoServico");
            DropTable("dbo.TipoDePagamento");
            DropTable("dbo.TipoBloco");
            DropTable("dbo.Status");
            DropTable("dbo.Responsavel");
            DropTable("dbo.Real");
            DropTable("dbo.Propriedade");
            DropTable("dbo.Orcado");
            DropTable("dbo.Fornecedor");
            DropTable("dbo.Caixa");
            DropTable("dbo.Bloco");
            DropTable("dbo.Acumulado");
            AddPrimaryKey("dbo.Backlog", "PeriodoMes");
        }
    }
}
