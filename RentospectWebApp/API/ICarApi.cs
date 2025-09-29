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
    public interface ICarApi
    {
        [Post("/api/cars")]
        Task<CustomApiResponce> SaveCarAsync(CarDto carDto);
        [Get("/api/cars")]
        Task<CarDto[]> GetCarsAsync();
    }
}
