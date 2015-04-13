namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Migrations
{
    using DOMINIO.Model.Orcamento;
    using DOMINIO.Model.Global;
    using DOMINIO.Model.Sistema;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PCFTIDataContext>
    {
        private readonly bool _pendingMigrations;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PCFTIDataContext context)
        {
            if(!_pendingMigrations) return;

            List<Regra> regras = new List<Regra>()
            {
                new Regra() { RegraId = Guid.Parse("f1a89281-6c33-4be3-9424-fe8f72c33b60"), Nome = "SUPER-ADMINISTRADOR", Descartado = false, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
                new Regra() { RegraId = Guid.Parse("019e6d49-2482-42e7-8a13-a6d438f1d3c5"), Nome = "ADMINISTRADOR", Descartado = false, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
                new Regra() { RegraId = Guid.Parse("bbbd9ee6-0a4e-48c5-b316-c88527ac3601"), Nome = "COLABORADOR", Descartado = false, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
                new Regra() { RegraId = Guid.Parse("c678af8e-adb1-4ee5-8bed-109d2dd06021"), Nome = "SUPER-BENIFICIARIO", Descartado = false, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
                new Regra() { RegraId = Guid.Parse("faf49f33-daf6-461e-bb72-977375a34eab"), Nome = "BENIFICIARIO", Descartado = false, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now }
            };

            Configurar_Regras(context, regras);

            //List<Usuario> uSUPERADMINISTRADOR = new List<Usuario>()
            //{
            //    new Usuario() { UsuarioId = Guid.Parse("35e4ae75-7b41-43ba-9e42-3f7b2df04974"), Nome = "Andrea Cardozo", LoginWindows = @"LAB2W\andrea.cardozo", Email = "andrea.cardozo@b2wdigital.com", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
            //    new Usuario() { UsuarioId = Guid.Parse("5a972278-d5b1-49a2-a8c3-4bd3141207be"), Nome = "Mônica Lourenço Junger de Assis", LoginWindows = @"LAB2W\monica.lourenco", Email = "monica.lourenco@b2wdigital.com", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now }
            //};

            //List<UsuarioRegra> urSUPERADMINISTRADOR = new List<UsuarioRegra>()
            //{
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("35e4ae75-7b41-43ba-9e42-3f7b2df04974"), RegraId = Guid.Parse("f1a89281-6c33-4be3-9424-fe8f72c33b60") },
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("5a972278-d5b1-49a2-a8c3-4bd3141207be"), RegraId = Guid.Parse("f1a89281-6c33-4be3-9424-fe8f72c33b60") }
            //};

            //context.Usuario.AddRange(uSUPERADMINISTRADOR);
            //context.SaveChanges();

            //context.UsuarioRegra.AddRange(urSUPERADMINISTRADOR);
            //context.SaveChanges();

            //List<Usuario> uSUPERBENEFICIARIO = new List<Usuario>()
            //{
            //    new Usuario() { UsuarioId = Guid.Parse("8db65c40-3107-452b-98e6-0d80192a6a24"), Nome = "Jean Lessa", LoginWindows = @"LAB2W\jean.lessa", Email = "jean.lessa@b2wdigital.com", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
            //    new Usuario() { UsuarioId = Guid.Parse("2eb490db-79d0-4c3d-a075-6fa462a04300"), Nome = "Carlos Gatto", LoginWindows = @"LAB2W\carlos.gatto", Email = "carlos.gatto@b2wdigital.com", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now }
            //};

            //List<UsuarioRegra> urSUPERBENEFICIARIO = new List<UsuarioRegra>()
            //{
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("8db65c40-3107-452b-98e6-0d80192a6a24"), RegraId = Guid.Parse("c678af8e-adb1-4ee5-8bed-109d2dd06021") },
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("2eb490db-79d0-4c3d-a075-6fa462a04300"), RegraId = Guid.Parse("c678af8e-adb1-4ee5-8bed-109d2dd06021") }
            //};

            //context.Usuario.AddRange(uSUPERBENEFICIARIO);
            //context.SaveChanges();

            //context.UsuarioRegra.AddRange(urSUPERBENEFICIARIO);
            //context.SaveChanges();

            //List<Usuario> uBENEFICIARIO = new List<Usuario>()
            //{
            //    new Usuario() { UsuarioId = Guid.Parse("27ef84f5-f59a-4d3d-b661-e48e85b4c102"), Nome = "Mariana Fullen", LoginWindows = @"LAB2W\mariana.fullen", Email = "mariana.fullen@b2wdigital.com", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
            //    new Usuario() { UsuarioId = Guid.Parse("863f9752-0b5d-4fdc-b8c7-655b085f8d57"), Nome = "Lucas Melman", LoginWindows = @"LAB2W\lucas.melman", Email = "lucas.melman@b2wdigital.com", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
            //    new Usuario() { UsuarioId = Guid.Parse("6e47abec-34d3-4565-bd61-7b9c8cf1c84a"), Nome = "Eduardo Fullen", LoginWindows = @"LAB2W\edu.fullen", Email = "edu.fullen@b2wdigital.com", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
            //    new Usuario() { UsuarioId = Guid.Parse("3fc2273c-e636-4c6f-b3ac-4f498919a0cc"), Nome = "Jean Carlo Pereira", LoginWindows = @"LAB2W\jean.pereira", Email = "jean.pereira@lasa.com.br", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
            //    new Usuario() { UsuarioId = Guid.Parse("82a98627-509d-4872-83ae-1a5a853ad7a3"), Nome = "Samantha Jones", LoginWindows = @"LAB2W\samantha.jones", Email = "samantha.jones@b2wdigital.com", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
            //    new Usuario() { UsuarioId = Guid.Parse("64bab965-e98c-49f9-8c69-010ba2321764"), Nome = "José Figueiredo", LoginWindows = @"LAB2W\jose.figueiredo", Email = "jose.figueiredo@b2wdigital.com", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
            //    new Usuario() { UsuarioId = Guid.Parse("5f7f0251-5673-4bf1-ad8e-908238768c71"), Nome = "Iano Lopes", LoginWindows = @"LAB2W\iano.lopes", Email = "iano.lopes@b2wdigital.com", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
            //    new Usuario() { UsuarioId = Guid.Parse("b6ae0fb4-ab42-4f27-87dc-d91de8224e55"), Nome = "Bruno Villela", LoginWindows = @"LAB2W\bruno.villela", Email = "bruno.villela@b2wdigital.com", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
            //    new Usuario() { UsuarioId = Guid.Parse("92db43a7-31a5-42b0-903c-7a1ec810b9e3"), Nome = "Caio Paulino", LoginWindows = @"LAB2W\caio.paulino", Email = "caio.paulino@b2wdigital.com", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
            //    new Usuario() { UsuarioId = Guid.Parse("a096f584-c07f-4b7c-a498-b4d0c88b6108"), Nome = "Rafael Catoto Dias", LoginWindows = @"LAB2W\rafael.catoto", Email = "rafael.catoto@submarino.com.br", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
            //    new Usuario() { UsuarioId = Guid.Parse("c13c464f-b792-40f8-864d-5f1c07df28f8"), Nome = "Valmir Andrade", LoginWindows = @"LAB2W\valmir.andrade", Email = "valmir.andrade@b2wdigital.com", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
            //    new Usuario() { UsuarioId = Guid.Parse("2ba32683-6737-4201-8540-b94d24d378f5"), Nome = "Jair Costa", LoginWindows = @"LAB2W\jair.costa", Email = "3rd.jair.costa@b2wdigital.com", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now },
            //    new Usuario() { UsuarioId = Guid.Parse("ce51cef5-925a-4e2b-8fd7-38681d3155db"), Nome = "Jair Joao Viegas Filho", LoginWindows = @"LAB2W\jair.filho", Email = "jair.filho@b2wdigital.com", Descartado = false, Ativo = true, CriadoPor = @"LAB2W\fabio.braga", CriadoEm = DateTime.Now }
            //};

            //List<UsuarioRegra> urBENEFICIARIO = new List<UsuarioRegra>()
            //{
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("27ef84f5-f59a-4d3d-b661-e48e85b4c102"), RegraId = Guid.Parse("faf49f33-daf6-461e-bb72-977375a34eab") },
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("863f9752-0b5d-4fdc-b8c7-655b085f8d57"), RegraId = Guid.Parse("faf49f33-daf6-461e-bb72-977375a34eab") },
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("6e47abec-34d3-4565-bd61-7b9c8cf1c84a"), RegraId = Guid.Parse("faf49f33-daf6-461e-bb72-977375a34eab") },
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("3fc2273c-e636-4c6f-b3ac-4f498919a0cc"), RegraId = Guid.Parse("faf49f33-daf6-461e-bb72-977375a34eab") },
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("82a98627-509d-4872-83ae-1a5a853ad7a3"), RegraId = Guid.Parse("faf49f33-daf6-461e-bb72-977375a34eab") },
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("64bab965-e98c-49f9-8c69-010ba2321764"), RegraId = Guid.Parse("faf49f33-daf6-461e-bb72-977375a34eab") },
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("5f7f0251-5673-4bf1-ad8e-908238768c71"), RegraId = Guid.Parse("faf49f33-daf6-461e-bb72-977375a34eab") },
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("b6ae0fb4-ab42-4f27-87dc-d91de8224e55"), RegraId = Guid.Parse("faf49f33-daf6-461e-bb72-977375a34eab") },
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("92db43a7-31a5-42b0-903c-7a1ec810b9e3"), RegraId = Guid.Parse("faf49f33-daf6-461e-bb72-977375a34eab") },
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("a096f584-c07f-4b7c-a498-b4d0c88b6108"), RegraId = Guid.Parse("faf49f33-daf6-461e-bb72-977375a34eab") },
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("c13c464f-b792-40f8-864d-5f1c07df28f8"), RegraId = Guid.Parse("faf49f33-daf6-461e-bb72-977375a34eab") },
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("2ba32683-6737-4201-8540-b94d24d378f5"), RegraId = Guid.Parse("faf49f33-daf6-461e-bb72-977375a34eab") },
            //    new UsuarioRegra() { UsuarioId = Guid.Parse("ce51cef5-925a-4e2b-8fd7-38681d3155db"), RegraId = Guid.Parse("faf49f33-daf6-461e-bb72-977375a34eab") }
            //};

            //context.Usuario.AddRange(uBENEFICIARIO);
            //context.SaveChanges();

            //context.UsuarioRegra.AddRange(urBENEFICIARIO);
            //context.SaveChanges();

            base.Seed(context);
        }

        private void Configurar_Regras(PCFTIDataContext context, List<Regra> regras)
        {

            context.Regra.AddOrUpdate<Regra>(regras.ToArray());
            context.SaveChanges();

        }


    }
}
