using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Responses
{
    public class BasexResponse<T> : BaseResponse where T : class
    {
        public T Extra { get; set; }

        //Success
        public BasexResponse(T extra)
        {
            this.Extra = extra;
        }
        //Fail
        public BasexResponse(string message) : base(message)
        {
            base.Message = message;
        }
    }
}
