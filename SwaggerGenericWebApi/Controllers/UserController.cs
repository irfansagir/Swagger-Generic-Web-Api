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
    public class UserController : GenericController<User, UserDto, UserService>
    {
        public UserController(UserService service) : base(service)
        {
        }
    }
}
