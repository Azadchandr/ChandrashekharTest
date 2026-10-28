using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChandrashekharTest.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string RoleName { get; set; }

        public bool IsActive { get; set; }

        public System.DateTime CreatedDate { get; set; }
    }
}