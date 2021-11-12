using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class GenericResult
    {
        public string Message { get; set; }
        public object Errors { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class GenericResult<TResult> : GenericResult
    {
        public TResult Data { get; set; }
    }
}
