using SwaggerGenericWebApi.Models.Dtos;
using SwaggerGenericWebApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerGenericWebApi.Services
{
    public interface IService<TEntity, TDto>
        where TEntity : class, IEntity
        where TDto : class, IDto
    {
        Task<TDto> GetAsync(long id);
        Task<List<TDto>> GetAllAsync();
        Task CreateAsync(TDto dto);
        Task UpdateAsync(TDto dto);
        Task DeleteAsync(long id);
    }
}
