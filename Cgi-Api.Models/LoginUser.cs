using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cgi_Api.Models
{
    [NotMapped]
    public class LoginUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
