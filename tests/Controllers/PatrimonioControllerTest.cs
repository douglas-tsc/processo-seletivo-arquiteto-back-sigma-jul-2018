using Moq;
using Sigma.PatrimonioApi.Contracts;
using Sigma.PatrimonioApi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TestToolsToXunitProxy;

namespace Sigma.PatrimonioApi.Tests.Controllers
{
    [TestClass]
    public class PatrimonioControllerTest
    {
        /// <summary>
        /// Repositório Mock de Patrimônios para uso em testes
        /// </summary>
        public readonly IPatrimonioRepository MockPatrimonioRepository;

        public PatrimonioControllerTest()
        {
            DateTime now = DateTime.Now;

            // Repositório falso de patrimônios
            Mock<IPatrimonioRepository> mockPatrimonioRepository = new Mock<IPatrimonioRepository>();

            // Criando alguns dados falsos para testar
            IList<Patrimonio> patrimonios = new List<Patrimonio> {
                new Patrimonio {
                    PatrimonioId = 1,
                    Nome = "Patrimonio-1",
                    Descricao = "Descrição-1",
                    DataCriacao = now,
                    NroTombo = 1,
                    MarcaId = 1,
                    ModeloId = 1
                },
                new Patrimonio {
                    PatrimonioId = 2,
                    Nome = "Patrimonio-2",
                    Descricao = "Descrição-2",
                    DataCriacao = now,
                    NroTombo = 2,
                    MarcaId = 2,
                    ModeloId = 1
                }
            };


            // Retorna todos os dados
            mockPatrimonioRepository.Setup(x => x.FindAll()).Returns(patrimonios);

            // Retorna um patrimônio pelo Id
            mockPatrimonioRepository.Setup(x => x.GetById(
                It.IsAny<int>())).Returns((int i) => patrimonios.Where(x => x.PatrimonioId == i).Single());

            // Configuração completa do repositório Moq
            MockPatrimonioRepository = mockPatrimonioRepository.Object;

        }


        /// <summary>
        /// Podemos retornar todos os Patrimônios?
        /// </summary>
        [TestMethod]
        public void GetAll_Get_ObterTodosPatrimonios()
        {
            IEnumerable<Patrimonio> testPatrimonio = MockPatrimonioRepository.FindAll();

            // Testa se o retorno é nulo
            Assert.IsNotNull(testPatrimonio);

            // Verifique se o total está correto
            Assert.AreEqual(2, testPatrimonio.Count());
        }

        /// <summary>
        /// Podemos retornar um Patrimônio por Id?
        /// </summary>
        [TestMethod]
        public void GetById_Get_ObterUmPatrimonio()
        {
            Patrimonio testPatrimonio = MockPatrimonioRepository.GetById(2);

            // Testa se o retorno é nulo
            Assert.IsNotNull(testPatrimonio);

            // Verifique se é o patrimônio certo
            Assert.AreEqual("Patrimonio-2", testPatrimonio.Nome);
        }

        /// <summary>
        /// Podemos atualizar um Patrimônio?
        /// </summary>
        [TestMethod]
        public void Update_Put_AtualizaUmPatrimonio()
        {
            // Encontre um patrimônio por id
            Patrimonio testPatrimonio = MockPatrimonioRepository.GetById(1);

            // Altere os valores
            testPatrimonio.Nome = "Patrimônio 5";

            // Salve as alterações
            MockPatrimonioRepository.Create(testPatrimonio);

            // Verifique a mudança
            Assert.AreEqual("Patrimônio 5", MockPatrimonioRepository.GetById(1).Nome);
        }

    }
}