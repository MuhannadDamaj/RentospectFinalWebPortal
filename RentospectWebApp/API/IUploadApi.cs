﻿using Refit;
using RentospectWebApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectWebApp.API
{
    [Headers("Authorization: Bearer ")]
    public interface IUploadApi
    {
        [Multipart]
        [Post("/api/upload/excel/{id}")]
        Task<UploadResultDto> UploadExcel(int id,[AliasAs("file")] MultipartFormDataContent file);
    }
}
