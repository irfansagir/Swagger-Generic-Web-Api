using Microsoft.AspNetCore.Mvc;
using SwaggerGenericWebApi.Models.Dtos;
using SwaggerGenericWebApi.Models.Entities;
using SwaggerGenericWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerGenericWebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public abstract class GenericController<TEntity, TDto, TService> : Controller
        where TEntity : class, IEntity
        where TDto : class, IDto
        where TService : class, IService<TEntity, TDto>
    {
        public TService Service { get; private set; }

        public GenericController(TService service)
            => Service = service;

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var result = await Service.GetAsync(id);

            if (result == null)
            {
                return NotFound($"{nameof(TDto)} not found!");
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        public virtual async Task<IActionResult> Post([FromBody]TDto item)
        {
            await Service.CreateAsync(item);
            return Ok($"{nameof(TDto)} saved!");
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), 200)]
        public virtual async Task<IActionResult> Put([FromBody]TDto item)
        {
            await Service.UpdateAsync(item);
            return Ok($"{nameof(TDto)} updated!");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await Service.DeleteAsync(id);
            return Ok($"{nameof(TDto)} deleted!");
        }
    }
}
