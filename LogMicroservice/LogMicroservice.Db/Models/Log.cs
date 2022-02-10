using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeeMicroservice.Db.Models
{
    public class Log : BaseModel
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public DateTime CurrentDateTime { get; set; }
        [Required]
        public string IpAddress { get; set; }
        [Required]
        public string Operation { get; set; }
  
        public DateTime CurrentServerDateTime = DateTime.Now;
        public string Message { get; set; }

    }
}