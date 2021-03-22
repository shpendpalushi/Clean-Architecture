using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Web.Errors
{
    public class APIException
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public APIException(int statusCode, string message=null, string details=null)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }
    }
}
