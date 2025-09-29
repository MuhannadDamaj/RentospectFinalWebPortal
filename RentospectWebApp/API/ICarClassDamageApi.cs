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
    public interface ICarClassDamageApi
    {
        [Post("/api/carclassdamages")]
        Task<CustomApiResponce> SaveCarClassDamageAsync(CarClassDamageDto carClassDamageDto);
        [Get("/api/carclassdamages/{carClassID}")]
        Task<CarClassDamageDto[]> GetCarClassDamagesByCarClassIDAsync(int carClassID);
    }
}
