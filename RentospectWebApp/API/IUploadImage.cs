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
    public interface IUploadImage
    {
        [Multipart]
        [Post("/api/upload/photo")]
        Task<CustomApiResponce> UploadImage([AliasAs("file")] StreamPart file);
    }
}
