using System;
using System.Collections.Generic;
using System.Text;

namespace Cgi_Api.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }
}
