using SwaggerGenericWebApi.Models.Dtos;
using SwaggerGenericWebApi.Models.Entities;
using SwaggerGenericWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerGenericWebApi.Controllers
{
    public class ProductController : GenericController<Product, ProductDto, ProductService>
    {
        public ProductController(ProductService service) : base(service)
        {
        }
    }
}
