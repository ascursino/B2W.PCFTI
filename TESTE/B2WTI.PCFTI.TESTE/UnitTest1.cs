
namespace B2WTI.PCFTI.TESTE
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using DOMINIO.Model.Global;
    using INFRAESTRUTURA.HORIZONTAL;
    using B2WTI.PCFTI.APLICACAO.Modulo.Cadastro;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesteDoCRUDFornecedor()
        {
            bool teste = true;

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Fornecedor> fornecedorRepository = new Repository<Fornecedor>(context, unitOfWork);
                    IFornecedorService fornecedorService = new FornecedorService(fornecedorRepository);

                    //CREATE

                    var fornecedor = fornecedorService.NovoFornecedor(
                        new Fornecedor() 
                        { 
                            FornecedorId = Guid.NewGuid(), 
                            CNPJ = "00000000000", 
                            NomeFantasia = "NomeFantasia de Teste", 
                            RazaoSocial = "Razão Social de Teste LTDA", 
                            Ativo = true 
                        });

                    unitOfWork.SaveChanges();

                    if (fornecedor == null)
                        Assert.IsNull(fornecedor, "O fornecedor retornou nulo ao criar um novo.");

                    //READ
                    
                    var fornecedores = fornecedorService.ListarTodosOsFornecedores();

                    if (fornecedores == null)
                        Assert.IsNull(fornecedores, "A leitura de fornecedores retornou nulo.");

                    if (fornecedores.Count() == 0)
                        Assert.IsNotNull(fornecedores, "O objeto foi instanciado, mas não contém nenhum fornecedor definido.");

                    //UPDATE

                    var query = from item in fornecedores
                                where item.CNPJ == fornecedor.CNPJ
                                select item;


                    Fornecedor temp = query.ToList<Fornecedor>().FirstOrDefault<Fornecedor>();
                    temp.CNPJ = "111111111";

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                    fornecedorService.Update(temp);
                    unitOfWork.SaveChanges();


                    //DELETE

                    var queryDelete = from item in fornecedores
                                      where item.FornecedorId == fornecedor.FornecedorId
                                      select item;


                    Fornecedor tempDelete = query.ToList<Fornecedor>().FirstOrDefault<Fornecedor>();

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    fornecedorService.Delete(tempDelete);
                    unitOfWork.SaveChanges();



                }
            }
            catch (Exception Ex)
            {
                Assert.Fail(Ex.Message);
            }
            

        }
    }
}
