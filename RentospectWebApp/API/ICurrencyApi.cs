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
    public interface ICurrencyApi
    {
        [Post("/api/currencies")]
        Task<CustomApiResponce> SaveCurrencyAsync(CurrencyDto currencyDto);
        [Get("/api/currencies")]
        Task<CurrencyDto[]> GetCurrenciesAsync();
    }
}
