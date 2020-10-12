using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyHealth.Models
{
    public class BmiCalculator
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public float Height { get; set; }
        [Required]
        public float Weight { get; set; }

        public float Bmi { get; set; }
        public int UserId { get; set; }
    }
}