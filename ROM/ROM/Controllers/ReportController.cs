using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return View();
        }

        public IActionResult Show()
        {
            aNOrderDetails.Members = _context.Members.ToList();
            return View(aNOrderDetails);
        }

        public JsonResult OrderDetails(int memberId, DateTime date)
        {
            var orderItem = _context.OrderDetails.Where(c => c.MemberId == memberId && c.DateTime==date).Include(f=>f.Food).ToList();
            return Json(orderItem);
        }
    }
}
