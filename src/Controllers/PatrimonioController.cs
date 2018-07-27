using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sigma.PatrimonioApi.Contracts;
using Sigma.PatrimonioApi.Entities.Models;
using System;
using System.Linq;

namespace Sigma.PatrimonioApi.Controllers
{
    /// <summary>
    /// Patrimônio
    /// </summary>
    //[Authorize(Roles = "Gestor")]
    [Route("api/[controller]")]
    [ProducesResponseType(200)] // Success
    [ProducesResponseType(400)] // BadRequest
    [ProducesResponseType(401)] // Unauthorized
    public class PatrimonioController : Controller
    {
        private IRepositoryWrapper _wrapper;


        public PatrimonioController(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        // GET api/Patrimonio
        /// <summary>
        /// Exibe uma lista de Patrimônios
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            string[] entities = { "Marca", "Modelo" };

            var model = _wrapper.Patrimonios.FindAll(entities);

            return Ok(model);
        }

        // GET api/Patrimonio/5
        /// <summary>
        /// Exibe um Patrimônio pelo Id
        /// </summary>
        /// <param name="id">Id do Patrimônio</param>
        /// <response code="404">Patrimônio não encontrado</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            string[] entities = { "Marca", "Modelo" };

            var model = _wrapper.Patrimonios.FindAll(entities).Where(x => x.PatrimonioId == id);
            if (model.Count() == 0)
                throw new NotFoundException("Patrimônio não encontrado.");

            return Ok(model.FirstOrDefault());
        }

        // POST api/Patrimonio
        /// <summary>
        /// Cadastra um novo Patrimônio
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /Patrimonio
        ///     {
        ///        "MarcaId": 1,
        ///        "ModeloId": 1,
        ///        "Nome": "Nome do Patrimônio",
        ///        "Descricao": "Descrição do Patrimônio"
        ///     }
        ///
        /// </remarks>
        /// <param name="item">Dados do Patrimônio</param>
        [HttpPost]
        public void Create(Patrimonio item)
        {
            try
            {
                var model = _wrapper.Patrimonios.FindAll().OrderByDescending(x => x.PatrimonioId);

                item.NroTombo = (model.Count() == 0) ? 1 : model.FirstOrDefault().NroTombo + 1;

                _wrapper.Patrimonios.Create(item);
                _wrapper.Patrimonios.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/Patrimonio/5
        /// <summary>
        /// Atualiza os dados de um Patrimônio pelo Id
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /Patrimonio/5
        ///     {
        ///        "MarcaId": 1,
        ///        "ModeloId": 1,
        ///        "Nome": "Nome do Patrimônio",
        ///        "Descricao": "Descrição do Patrimônio"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Id do Patrimônio</param>
        /// <param name="item">Dados do Patrimônio</param>
        /// <response code="404">Patrimônio não encontrado</response>
        [HttpPut("{id:int}")]
        public void Update(int id, Patrimonio item)
        {
            try
            {
                var model = _wrapper.Patrimonios.GetById(id);
                if (model == null)
                    throw new NotFoundException("Patrimônio não encontrado.");

                model.MarcaId = item.MarcaId;
                model.ModeloId = item.ModeloId;
                model.Nome = item.Nome;
                model.Descricao = item.Descricao;

                _wrapper.Patrimonios.Update(model);
                _wrapper.Patrimonios.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/Patrimonio/5
        /// <summary>
        /// Apaga o registro de um Patrimônio pelo Id
        /// </summary>
        /// <param name="id">Id do Patrimônio</param>
        /// <response code="404">Patrimônio não encontrado</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(404)]
        public void Delete(int id)
        {
            try
            {
                var model = _wrapper.Patrimonios.GetById(id);
                if (model == null)
                    throw new NotFoundException("Patrimônio não encontrado.");

                _wrapper.Patrimonios.Delete(model);
                _wrapper.Patrimonios.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // GET api/Patrimonio/Marca/NomeDaMarca
        /// <summary>
        /// Exibe uma lista de Patrimônios pelo Nome da Marca
        /// </summary>
        /// <param name="nome">Nome da Marca de Patrimônio</param>
        /// <response code="404">Não há Patrimônio com a Marca informada</response>
        [HttpGet("Marca/{nome}")]
        [ProducesResponseType(404)]
        public IActionResult GetByMarca(string nome)
        {
            string[] entities = { "Marca", "Modelo" };

            var model = _wrapper.Patrimonios.FindAll(entities).Where(x => x.Marca.Nome.Equals(nome, StringComparison.CurrentCultureIgnoreCase));
            if (model.Count() == 0)
                throw new NotFoundException("Não há Patrimônio com a Marca informada.");

            return Ok(model);
        }

        // GET api/Patrimonio/Modelo/NomeDoModelo
        /// <summary>
        /// Exibe uma lista de Patrimônios pelo Nome do Modelo
        /// </summary>
        /// <param name="nome">Nome do Modelo de Patrimônio</param>
        /// <response code="404">Não há Patrimônio com o Modelo informado</response>
        [HttpGet("Modelo/{nome}")]
        [ProducesResponseType(404)]
        public IActionResult GetByModelo(string nome)
        {
            string[] entities = { "Marca", "Modelo" };

            var model = _wrapper.Patrimonios.FindAll(entities).Where(x => x.Modelo.Nome.Equals(nome, StringComparison.CurrentCultureIgnoreCase));
            if (model.Count() == 0)
                throw new NotFoundException("Não há Patrimônio com o Modelo informado.");

            return Ok(model);
        }

    }
}
