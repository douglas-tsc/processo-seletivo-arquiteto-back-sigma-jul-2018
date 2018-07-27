using Microsoft.AspNetCore.Mvc;
using Sigma.PatrimonioApi.Contracts;
using Sigma.PatrimonioApi.Entities.Models;
using System;
using System.Linq;

namespace Sigma.PatrimonioApi.Controllers
{
    /// <summary>
    /// Marca
    /// </summary>
    //[Authorize(Roles = "Gestor")]
    [Route("api/[controller]")]
    [ProducesResponseType(200)] // Success
    [ProducesResponseType(400)] // BadRequest
    [ProducesResponseType(401)] // Unauthorized
    public class MarcaController : Controller
    {
        private IRepositoryWrapper _wrapper;


        public MarcaController(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        // GET api/Marca
        /// <summary>
        /// Exibe uma lista de Marcas
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _wrapper.Marcas.FindAll();

            return Ok(model);
        }

        // GET api/Marca/5
        /// <summary>
        /// Exibe uma Marca pelo Id
        /// </summary>
        /// <param name="id">Id da Marca</param>
        /// <response code="404">Marca não encontrada</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var model = _wrapper.Marcas.GetById(id);
            if (model == null)
                throw new NotFoundException("Marca não encontrada.");

            return Ok(model);
        }

        // POST api/Marca
        /// <summary>
        /// Cadastra uma nova Marca
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /Marca
        ///     {
        ///        "Nome": "Nome da Marca"
        ///     }
        ///
        /// </remarks>
        /// <param name="item">Dados da Marca</param>
        [HttpPost]
        public void Create(Marca item)
        {
            try
            {
                var model = _wrapper.Marcas.FindBy(x => x.Nome.Equals(item.Nome));
                if (model.Count() == 1)
                    throw new ArgumentException("Já existe uma Marca com este nome.");

                _wrapper.Marcas.Create(item);
                _wrapper.Marcas.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/Marca/5
        /// <summary>
        /// Atualiza os dados de uma Marca pelo Id
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /Marca/5
        ///     {
        ///        "Nome": "Nome da Marca"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Id da Marca</param>
        /// <param name="item">Dados da Marca</param>
        /// <response code="404">Marca não encontrada</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(404)]
        public void Update(int id, Marca item)
        {
            try
            {
                var model = _wrapper.Marcas.GetById(id);
                if (model == null)
                    throw new NotFoundException("Marca não encontrada.");

                model.Nome = item.Nome;

                _wrapper.Marcas.Update(model);
                _wrapper.Marcas.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/Marca/5
        /// <summary>
        /// Apaga o registro de uma Marca pelo Id
        /// </summary>
        /// <param name="id">Id da Marca</param>
        /// <response code="404">Marca não encontrada</response>
        /// <response code="409">Restrição de exclusão</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public void Delete(int id)
        {
            try
            {
                var model = _wrapper.Marcas.GetById(id);
                if (model == null)
                    throw new NotFoundException("Marca não encontrada.");

                _wrapper.Marcas.Delete(model);
                _wrapper.Marcas.Save();
            }
            catch (ConstraintException)
            {
                throw new ConstraintException("Não é possível excluir esta Marca, pois o mesmo possui relacionamentos.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
