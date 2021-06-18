using Microsoft.AspNetCore.Mvc;
using ROM.DBContext;
using ROM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROM.Controllers
{
    public class ReportController : Controller
    {
        private readonly ROMDatabaseContext _context;
        OrderDetails aNOrderDetails = new OrderDetails();

        public ReportController(ROMDatabaseContext rOMDatabaseContext)
        {
            _context = rOMDatabaseContext;
        }

        public IActionResult Index()
        {
            //aNOrderDetails.Members = _context.Members.ToList();
            //return View(aNOrderDetails);
            return View();
        }

        public IActionResult Show()
        {
            aNOrderDetails.Members = _context.Members.ToList();
            return View(aNOrderDetails);
        }
    }
}
