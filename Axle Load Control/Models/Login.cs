using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axle_Load_Control.Models
{
    public class Login
    {
        public string email { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
    }
}