namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PCFTIDB0001 : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.PeriodoMes)
                .ForeignKey("dbo.Lancamento", t => t.Lancamento_LancamentoId)
                .ForeignKey("dbo.Lancamento", t => t.LancamentoId)
                .Index(t => t.LancamentoId)
                .Index(t => t.Lancamento_LancamentoId);
            
            CreateTable(
                "dbo.Lancamento",
                c => new
                    {
                        LancamentoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LancamentoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Backlog", "LancamentoId", "dbo.Lancamento");
            DropForeignKey("dbo.Backlog", "Lancamento_LancamentoId", "dbo.Lancamento");
            DropIndex("dbo.Backlog", new[] { "Lancamento_LancamentoId" });
            DropIndex("dbo.Backlog", new[] { "LancamentoId" });
            DropTable("dbo.Lancamento");
            DropTable("dbo.Backlog");
        }
    }
}
