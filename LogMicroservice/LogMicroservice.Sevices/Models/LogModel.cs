using System;

namespace LogMicroservice.Sevices.Models
{
    public class LogModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public string IpAddress { get; set; }
        public string Operation { get; set; }
        public DateTime CurrentServerDateTime { get; set; }
        public string Message { get; set; }
    }
}