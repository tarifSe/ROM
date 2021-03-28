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
            aNOrderDetails.Foods = _context.Foods.ToList();
            return View (aNOrderDetails);
        }

        [HttpPost]
        public IActionResult Save(OrderDetails orderDetails)
        {
            if (ModelState.IsValid)
            {
                _context.OrderDetails.Add(orderDetails);
                int isExucuted = _context.SaveChanges();
                return RedirectToAction(nameof(Save));
                //if (isExucuted == 1)
                //{
                //    ViewBag.SuccessMsg = "Save Success.";
                //}
                //else
                //{
                //    ViewBag.ErrorMsg = "Save Faild!";
                //}
            }

            aNOrderDetails.Members = _context.Members.ToList();
            aNOrderDetails.Foods = _context.Foods.ToList();
            return View(aNOrderDetails);
        }
    }
}
