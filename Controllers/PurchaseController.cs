using BookProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Controllers
{
    public class PurchaseController : Controller
    {
        public IActionResult Index()
        {
            return View(new Purchase());
        }
    }
}
