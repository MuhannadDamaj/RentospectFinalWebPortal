using Refit;
using RentospectWebApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectWebApp.API
{
    [Headers("Authorization: Bearer ")]
    public interface IUserApi
    {
        [Post("/api/users")]
        Task<CustomApiResponce> SaveUserAsync(UserDto userDto);
        [Get("/api/users")]
        Task<UserDto[]> GetUsersAsync();
    }
}
