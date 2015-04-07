namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PCFTI0005 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lancamento", "CriadoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Lancamento", "AlteradoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Lancamento", "CriadoEm", c => c.DateTime());
            AddColumn("dbo.Lancamento", "AlteradoEm", c => c.DateTime());
            AddColumn("dbo.Lancamento", "Descartado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Bloco", "Descartado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Fornecedor", "CriadoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Fornecedor", "AlteradoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Fornecedor", "CriadoEm", c => c.DateTime());
            AddColumn("dbo.Fornecedor", "AlteradoEm", c => c.DateTime());
            AddColumn("dbo.Fornecedor", "Descartado", c => c.Boolean(nullable: false));
            AddColumn("dbo.AnoCalendario", "CriadoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.AnoCalendario", "AlteradoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.AnoCalendario", "CriadoEm", c => c.DateTime());
            AddColumn("dbo.AnoCalendario", "AlteradoEm", c => c.DateTime());
            AddColumn("dbo.AnoCalendario", "Descartado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Responsavel", "CriadoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Responsavel", "AlteradoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Responsavel", "CriadoEm", c => c.DateTime());
            AddColumn("dbo.Responsavel", "AlteradoEm", c => c.DateTime());
            AddColumn("dbo.Responsavel", "Descartado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Status", "CriadoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Status", "AlteradoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Status", "CriadoEm", c => c.DateTime());
            AddColumn("dbo.Status", "AlteradoEm", c => c.DateTime());
            AddColumn("dbo.Status", "Descartado", c => c.Boolean(nullable: false));
            AddColumn("dbo.TipoBloco", "CriadoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.TipoBloco", "AlteradoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.TipoBloco", "CriadoEm", c => c.DateTime());
            AddColumn("dbo.TipoBloco", "AlteradoEm", c => c.DateTime());
            AddColumn("dbo.TipoBloco", "Descartado", c => c.Boolean(nullable: false));
            AddColumn("dbo.TipoDePagamento", "CriadoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.TipoDePagamento", "AlteradoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.TipoDePagamento", "CriadoEm", c => c.DateTime());
            AddColumn("dbo.TipoDePagamento", "AlteradoEm", c => c.DateTime());
            AddColumn("dbo.TipoDePagamento", "Descartado", c => c.Boolean(nullable: false));
            AddColumn("dbo.TipoServico", "CriadoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.TipoServico", "AlteradoPor", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.TipoServico", "CriadoEm", c => c.DateTime());
            AddColumn("dbo.TipoServico", "AlteradoEm", c => c.DateTime());
            AddColumn("dbo.TipoServico", "Descartado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TipoServico", "Descartado");
            DropColumn("dbo.TipoServico", "AlteradoEm");
            DropColumn("dbo.TipoServico", "CriadoEm");
            DropColumn("dbo.TipoServico", "AlteradoPor");
            DropColumn("dbo.TipoServico", "CriadoPor");
            DropColumn("dbo.TipoDePagamento", "Descartado");
            DropColumn("dbo.TipoDePagamento", "AlteradoEm");
            DropColumn("dbo.TipoDePagamento", "CriadoEm");
            DropColumn("dbo.TipoDePagamento", "AlteradoPor");
            DropColumn("dbo.TipoDePagamento", "CriadoPor");
            DropColumn("dbo.TipoBloco", "Descartado");
            DropColumn("dbo.TipoBloco", "AlteradoEm");
            DropColumn("dbo.TipoBloco", "CriadoEm");
            DropColumn("dbo.TipoBloco", "AlteradoPor");
            DropColumn("dbo.TipoBloco", "CriadoPor");
            DropColumn("dbo.Status", "Descartado");
            DropColumn("dbo.Status", "AlteradoEm");
            DropColumn("dbo.Status", "CriadoEm");
            DropColumn("dbo.Status", "AlteradoPor");
            DropColumn("dbo.Status", "CriadoPor");
            DropColumn("dbo.Responsavel", "Descartado");
            DropColumn("dbo.Responsavel", "AlteradoEm");
            DropColumn("dbo.Responsavel", "CriadoEm");
            DropColumn("dbo.Responsavel", "AlteradoPor");
            DropColumn("dbo.Responsavel", "CriadoPor");
            DropColumn("dbo.AnoCalendario", "Descartado");
            DropColumn("dbo.AnoCalendario", "AlteradoEm");
            DropColumn("dbo.AnoCalendario", "CriadoEm");
            DropColumn("dbo.AnoCalendario", "AlteradoPor");
            DropColumn("dbo.AnoCalendario", "CriadoPor");
            DropColumn("dbo.Fornecedor", "Descartado");
            DropColumn("dbo.Fornecedor", "AlteradoEm");
            DropColumn("dbo.Fornecedor", "CriadoEm");
            DropColumn("dbo.Fornecedor", "AlteradoPor");
            DropColumn("dbo.Fornecedor", "CriadoPor");
            DropColumn("dbo.Bloco", "Descartado");
            DropColumn("dbo.Lancamento", "Descartado");
            DropColumn("dbo.Lancamento", "AlteradoEm");
            DropColumn("dbo.Lancamento", "CriadoEm");
            DropColumn("dbo.Lancamento", "AlteradoPor");
            DropColumn("dbo.Lancamento", "CriadoPor");
        }
    }
}
