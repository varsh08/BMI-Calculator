using MyHealth.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHealth.Controllers
{
  
    public class BmiCalculatorController : Controller
    {

        ApplicationDbContext _context;

            public BmiCalculatorController()
            {
                _context = new ApplicationDbContext();
            }
            protected override void Dispose(bool disposing)
            {
                _context.Dispose();
            }
            // GET: BmiCalculator
            [HttpGet]
            public ActionResult Index()
            {
           
            if(System.Web.HttpContext.Current.Session["Id"]==null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            ViewBag.message = System.Web.HttpContext.Current.Session["Id"];
            return View();
            
        }
        public ActionResult Save(BmiCalculator bmiCalculator)
        {
            if (bmiCalculator.Id == 0)
            {
                bmiCalculator.Date = DateTime.Now;
                _context.BmiCalculators.Add(bmiCalculator);
            }

            _context.SaveChanges();
            _context.BmiCalculators.ToList();

            return View("Index");
        }
        public ActionResult Display()
        {
            if (System.Web.HttpContext.Current.Session["Id"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }

            dynamic mymodel = new ExpandoObject();
            mymodel.Bmi = _context.BmiCalculators.OrderByDescending(m=>m.Id).ToList();
                mymodel.User = _context.Registers.ToList();
                ViewBag.message =Session["Id"];
                return View(mymodel);
            
        }

    }
}
    
