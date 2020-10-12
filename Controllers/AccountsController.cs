using MyHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MyHealth.Controllers
{
    public class AccountsController : Controller
    {
        ApplicationDbContext _context;

        public AccountsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Register
        public ActionResult Register()
        {
           
            return View();
        }
        public ActionResult Save(Register register)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }

            else if (register.Id == 0)
                {
                    _context.Registers.Add(register);
                }
                _context.SaveChanges();
                return View("Login");
            
         //   return View(register);

        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logged(Register user) 
        {

            // var data = _context.Registers.Single(u => u.Email == login.Email && b=>b.Password == login.Password);
            var data = _context.Registers.Where(s => s.Email.Equals(user.Email) && s.Password.Equals(user.Password)).FirstOrDefault();
            if(data!=null)
            {
              System.Web.HttpContext.Current.Session["FirstName"] = data.FirstName.ToString();

                System.Web.HttpContext.Current.Session["Id"] = data.Id.ToString();
                return RedirectToAction("Index");
            }
        
    
            return View(user);//index//user

        }
       
        public ActionResult Index()
        {
            if (Session["Id"] != null)
            {
                // if (Session["FirstName"] != null)
                //{
               ViewBag.message = System.Web.HttpContext.Current.Session["Id"].ToString();
                // return View();
                //   return View("~/Views/Home/Index.cshtml");
                // return View("~/Views/BmiCalculator/Index.cshtml");
                return RedirectToAction("Index", "BmiCalculator");
            }
            
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return View("~/Views/Home/Index.cshtml");
        }

    }

}