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
    public interface ICarModelApi
    {
        [Post("/api/carmodels")]
        Task<CustomApiResponce> SaveCarModelAsync(CarModelDto carModelDto);
        [Get("/api/carmodels")]
        Task<CarModelDto[]> GetCarModelAsync();
    }
}
