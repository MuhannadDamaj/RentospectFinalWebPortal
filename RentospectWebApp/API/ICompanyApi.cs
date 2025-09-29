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
    public interface ICompanyApi
    {
        [Post("/api/companies")]
        Task<CustomApiResponce> SaveCompanyAsync(CompanyDto companyDto);
        [Get("/api/companies")]
        Task<CompanyDto[]> GetCompaniesAsync();
        [Get("/api/companies/{id}")]
        Task<CompanyDto> GetCompanyByIDAsync(int id);
    }
}
