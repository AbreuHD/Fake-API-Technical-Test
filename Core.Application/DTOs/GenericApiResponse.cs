using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs
{
    public class GenericApiResponse<DTO>
    {
        public HttpStatusCode StatusCode { get; set; }
        public DTO Data { get; set; }
        public string Message { get; set; }
    }
}
