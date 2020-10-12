using AutoMapper;
using MyHealth.Dto;
using MyHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace MyHealth.Controllers.Api
{
    public class BmiCalculatorController : ApiController
    {
        private ApplicationDbContext _context;
        public BmiCalculatorController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<BmiCalculatorDto> GetCustomers()
        {
            return _context.BmiCalculators.ToList().Select(Mapper.Map<BmiCalculator, BmiCalculatorDto>);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var BmiInDb = _context.BmiCalculators.SingleOrDefault(c => c.Id == id);
            if (BmiInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.BmiCalculators.Remove(BmiInDb);
            _context.SaveChanges();

            //  return Ok();
        }

        [HttpPost]
        public IHttpActionResult Create(BmiCalculatorDto bmiCalculatorDto)
        {
            //  var Session = HttpContext.Current.Session;
            //Console.WriteLine(Session["Id"]);
          
               if(!ModelState.IsValid)
            {
                return RedirectToRoute("BmiCalculator",null);
              
            }
                var bmi = Mapper.Map<BmiCalculatorDto, BmiCalculator>(bmiCalculatorDto);
                bmi.Date = DateTime.Now;
                _context.BmiCalculators.Add(bmi);
                _context.SaveChanges();

                bmiCalculatorDto.Id = bmi.Id;
            
                return Created(new Uri(Request.RequestUri + "/" + bmi.Id), bmiCalculatorDto);
            
        }
    }
}

    