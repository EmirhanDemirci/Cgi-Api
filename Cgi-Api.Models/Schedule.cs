using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cgi_Api.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
