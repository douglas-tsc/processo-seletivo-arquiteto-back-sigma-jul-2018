using Microsoft.AspNetCore.Mvc;
using Sigma.PatrimonioApi.Contracts;
using Sigma.PatrimonioApi.Entities.Models;
using System;

namespace Sigma.PatrimonioApi.Controllers
{
    /// <summary>
    /// Modelo
    /// </summary>
    //[Authorize(Roles = "Gestor")]
    [Route("api/[controller]")]
    [ProducesResponseType(200)] // Success
    [ProducesResponseType(400)] // BadRequest
    [ProducesResponseType(401)] // Unauthorized
    public class ModeloController : Controller
    {
        private IRepositoryWrapper _wrapper;


        public ModeloController(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        // GET api/Modelo
        /// <summary>
        /// Exibe uma lista de Modelos
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _wrapper.Modelos.FindAll();

            return Ok(model);
        }

        // GET api/Modelo/5
        /// <summary>
        /// Exibe um Modelo pelo Id
        /// </summary>
        /// <param name="id">Id do Modelo</param>
        /// <response code="404">Modelo não encontrado</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var model = _wrapper.Modelos.GetById(id);
            if (model == null)
                throw new NotFoundException("Modelo não encontrado.");

            return Ok(model);
        }

        // POST api/Modelo
        /// <summary>
        /// Cadastra um novo Modelo
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /Modelo
        ///     {
        ///        "Nome": "Nome do Modelo"
        ///     }
        ///
        /// </remarks>
        /// <param name="item">Dados do Modelo</param>
        [HttpPost]
        public void Create(Modelo item)
        {
            try
            {
                _wrapper.Modelos.Create(item);
                _wrapper.Modelos.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/Modelo/5
        /// <summary>
        /// Atualiza os dados de um Modelo pelo Id
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /Modelo/5
        ///     {
        ///        "Nome": "Nome do Modelo"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Id do Modelo</param>
        /// <param name="item">Dados do Modelo</param>
        /// <response code="404">Modelo não encontrado</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(404)]
        public void Update(int id, Modelo item)
        {
            try
            {
                var model = _wrapper.Modelos.GetById(id);
                if (model == null)
                    throw new NotFoundException("Modelo não encontrado.");

                model.Nome = item.Nome;

                _wrapper.Modelos.Update(model);
                _wrapper.Modelos.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/Modelo/5
        /// <summary>
        /// Apaga o registro de um Modelo pelo Id
        /// </summary>
        /// <param name="id">Id do Modelo</param>
        /// <response code="404">Modelo não encontrado</response>
        /// <response code="409">Restrição de exclusão</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public void Delete(int id)
        {
            try
            {
                var model = _wrapper.Modelos.GetById(id);
                if (model == null)
                    throw new NotFoundException("Modelo não encontrado.");

                _wrapper.Modelos.Delete(model);
                _wrapper.Modelos.Save();
            }
            catch (ConstraintException)
            {
                throw new ConstraintException("Não é possível excluir este Modelo, pois o mesmo possui relacionamentos.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
