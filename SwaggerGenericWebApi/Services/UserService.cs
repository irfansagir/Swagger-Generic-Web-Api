using SwaggerGenericWebApi.Models.Dtos;
using SwaggerGenericWebApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerGenericWebApi.Services
{
    public class UserService : IService<User, UserDto>
    {
        public Task CreateAsync(UserDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
