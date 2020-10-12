using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHealth.Dto
{
    public class BmiCalculatorDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        
        public float Height { get; set; }
     
        public float Weight { get; set; }

        public float Bmi { get; set; }
        public int UserId { get; set; }
    }
}