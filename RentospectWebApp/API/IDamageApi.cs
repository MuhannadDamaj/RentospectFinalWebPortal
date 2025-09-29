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
    public interface IDamageApi
    {
        [Post("/api/damages")]
        Task<CustomApiResponce> SaveDamageAsync(DamageDto damageDto);
        [Get("/api/damages")]
        Task<DamageDto[]> GetDamagesAsync();
    }
}
