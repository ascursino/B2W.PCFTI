namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PCFTI0006 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Guid(nullable: false),
                        LoginWindows = c.String(maxLength: 100, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        AlteradoPor = c.String(maxLength: 250, unicode: false),
                        CriadoEm = c.DateTime(),
                        AlteradoEm = c.DateTime(),
                        Descartado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Regra",
                c => new
                    {
                        RegraId = c.Guid(nullable: false),
                        ResponsavelId = c.String(nullable: false, maxLength: 100, unicode: false),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        AlteradoPor = c.String(maxLength: 250, unicode: false),
                        CriadoEm = c.DateTime(),
                        AlteradoEm = c.DateTime(),
                        Descartado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RegraId);
            
            CreateTable(
                "dbo.UsuarioRegra",
                c => new
                    {
                        UsuarioId = c.Guid(nullable: false),
                        RegraId = c.Guid(nullable: false),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        AlteradoPor = c.String(maxLength: 250, unicode: false),
                        CriadoEm = c.DateTime(),
                        AlteradoEm = c.DateTime(),
                        Descartado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UsuarioId, t.RegraId })
                .ForeignKey("dbo.Regra", t => t.RegraId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.RegraId);
            
            CreateTable(
                "dbo.RegraUsuario",
                c => new
                    {
                        Regra_RegraId = c.Guid(nullable: false),
                        Usuario_UsuarioId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Regra_RegraId, t.Usuario_UsuarioId })
                .ForeignKey("dbo.Regra", t => t.Regra_RegraId)
                .ForeignKey("dbo.Usuario", t => t.Usuario_UsuarioId)
                .Index(t => t.Regra_RegraId)
                .Index(t => t.Usuario_UsuarioId);
            
            AddColumn("dbo.Responsavel", "UsuarioId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Responsavel", "UsuarioId");
            AddForeignKey("dbo.Responsavel", "UsuarioId", "dbo.Usuario", "UsuarioId");
            DropColumn("dbo.Responsavel", "Descricao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Responsavel", "Descricao", c => c.String(maxLength: 250, unicode: false));
            DropForeignKey("dbo.UsuarioRegra", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioRegra", "RegraId", "dbo.Regra");
            DropForeignKey("dbo.Responsavel", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.RegraUsuario", "Usuario_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.RegraUsuario", "Regra_RegraId", "dbo.Regra");
            DropIndex("dbo.RegraUsuario", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.RegraUsuario", new[] { "Regra_RegraId" });
            DropIndex("dbo.UsuarioRegra", new[] { "RegraId" });
            DropIndex("dbo.UsuarioRegra", new[] { "UsuarioId" });
            DropIndex("dbo.Responsavel", new[] { "UsuarioId" });
            DropColumn("dbo.Responsavel", "UsuarioId");
            DropTable("dbo.RegraUsuario");
            DropTable("dbo.UsuarioRegra");
            DropTable("dbo.Regra");
            DropTable("dbo.Usuario");
        }
    }
}
