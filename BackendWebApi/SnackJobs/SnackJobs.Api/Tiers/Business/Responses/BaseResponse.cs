using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }
        public BaseResponse()
        {
            this.Success = true;
        }
        public BaseResponse(string message)
        {
            this.Success = false;
            this.Message = message;
        }
    }
}
