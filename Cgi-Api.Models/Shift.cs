using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cgi_Api.Models
{
    public class Shift
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [Column("skill")]
        [StringLength(255)]
        public string Skill { get; set; }
        [Column("time", TypeName = "datetime")]
        public DateTime Time { get; set; }
    }
}
