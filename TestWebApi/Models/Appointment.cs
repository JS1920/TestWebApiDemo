using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestWebApi.Models
{
    /// <summary>
    /// Appointment class.
    /// </summary>
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentTime { get; set; }
        [MaxLength(200)]
        public string Notes { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
    }
}
