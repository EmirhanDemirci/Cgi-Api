using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cgi_Api.Models
{
    [NotMapped]
    public class JwtUser
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
