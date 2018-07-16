using SwaggerGenericWebApi.Models.Dtos;
using SwaggerGenericWebApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerGenericWebApi.Services
{
    public class ProductService : IService<Product, ProductDto>
    {
        public Task CreateAsync(ProductDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
