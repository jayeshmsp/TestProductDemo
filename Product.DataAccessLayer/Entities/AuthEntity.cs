using System;
using System.Collections.Generic;
using System.Text;

namespace Product.DataAccessLayer.Entities
{
    public class AuthEntity
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserMobileNo { get; set; }
        public string UserEmail { get; set; }
        public string UserOTP { get; set; }
        public long CreatedBy { get; set; }
    }

    public class AuthDetailEntity : AuthEntity
    {

    }
}
