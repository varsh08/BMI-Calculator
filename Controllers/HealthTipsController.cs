﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHealth.Controllers
{
    public class HealthTipsController : Controller
    {
        // GET: HealthTips
        public ActionResult Underweight()
        {
            return View();
        }
        public ActionResult Overweight()
        {
            return View();
        }
    }
}