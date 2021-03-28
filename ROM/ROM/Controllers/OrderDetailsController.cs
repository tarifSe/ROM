using Microsoft.AspNetCore.Mvc;
using ROM.DBContext;
using ROM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROM.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly ROMDatabaseContext _context;
        OrderDetails aNOrderDetails = new OrderDetails();
        public OrderDetailsController(ROMDatabaseContext rOMDatabaseContext)
        {
            _context = rOMDatabaseContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Save()
        {
            aNOrderDetails.Members = _context.Members.ToList();
            return View (aNOrderDetails);
        }
    }
}
