using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Enums
{
    public enum HttpStatusCode
    {
        OK = 200,
        Created = 201,
        Accepted = 202,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401, 
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500,
    }
}
