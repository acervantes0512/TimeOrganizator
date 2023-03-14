using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeOrganizatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudGenericoController<T> : ControllerBase where T : class
    {
        private readonly IGenericService<T> _genericService;
        public CrudGenericoController(IGenericService<T> genericService)
        {
            this._genericService = genericService;
        }

        /// <summary>
        /// Obtener todos los registros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            return (await _genericService.GetAllAsync()).ToList();
        }

        /// <summary>
        /// Obtener registro por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(int id)
        {
            var entity = await _genericService.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        /// <summary>
        /// Eliminar registro por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _genericService.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Actualizar Registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(T entity)
        {
            await _genericService.UpdateAsync(entity);

            return NoContent();
        }

        /// <summary>
        /// Crear un nuevo registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _genericService.CreateAsync(entity);
            return Ok();
        }
    }

    }
