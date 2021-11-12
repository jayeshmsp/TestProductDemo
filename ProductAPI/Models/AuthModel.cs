using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Product.DataAccessLayer.Entities;
using ProductAPI.Utils;

namespace ProductAPI.Models
{
    public class AuthModel
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserMobileNo { get; set; }
        public string UserEmail { get; set; }
        public string UserOTP { get; set; }
        public long CreatedBy { get; set; }

        public string Message { get; set; }
    }

    public class AuthDetailModel : AuthModel
    {

    }

    public class AuthenticationModel
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }

    public class OTPModel
    {
        public string UserOTP { get; set; }
        public long UserId { get; set; }
    }
}
