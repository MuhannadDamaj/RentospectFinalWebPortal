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
    public interface ICarClassApi
    {
        [Post("/api/carclasses")]
        Task<CustomApiResponce> SaveCarClassesAsync(CarClassDto carClassDto);
        [Get("/api/carclasses")]
        Task<CarClassDto[]> GetCarClassesAsync();
    }
}
